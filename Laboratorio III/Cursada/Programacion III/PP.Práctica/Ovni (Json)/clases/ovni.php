<?php
require "IParte2.php";
require "AccesoDatos.php";
class Ovni implements IParte2
{
    //todos los atributos publicos
    public $_tipo;
    public $_velocidad;
    public $_planetaOrigen;
    public $_pathFoto;

    //contructor con todos los parametros opcionales
    public function __construct($tipo = null, $velocidad = null,$planetaOrigen = null, $pathFoto = null)
    {
        $this->_tipo = $tipo!=null ? $tipo : "";
        $this->_velocidad = $velocidad!=null ? $velocidad : "";
        $this->_planetaOrigen = $planetaOrigen!=null ? $planetaOrigen : "";
        $this->_pathFoto = $pathFoto!=null ? $pathFoto : "";
    }

    //metodos instancia
    public function ToJson()
    {
        $retornoJson = new stdClass();
        $retornoJson->tipo = $this->_tipo;
        $retornoJson->velocidad = $this->_velocidad;
        $retornoJson->planeta = $this->_planetaOrigen;
        $retornoJson->path = $this->_pathFoto;

        return json_encode($retornoJson);
    }

    //Agregara un ovni en la base de datos
    public function Agregar()
    {
        $retorno = false;

        $objetoAccesoDato = AccesoDatos::DameUnObjetoAcceso(); //no inserto el id porque es AI
        $consulta =$objetoAccesoDato->RetornarConsulta("INSERT INTO ovnis (tipo, velocidad, planeta, foto)"
                                                    . "VALUES(:tipo, :velocidad, :planeta, :foto)");                                          
        
        $consulta->bindValue(':tipo', $this->_tipo, PDO::PARAM_STR);
        $consulta->bindValue(':velocidad', $this->_velocidad, PDO::PARAM_INT);
        $consulta->bindValue(':planeta', $this->_planetaOrigen, PDO::PARAM_STR);
        $consulta->bindValue(':foto', $this->_pathFoto, PDO::PARAM_STR);
        $consulta->execute();

        if (($consulta->rowCount())>0) 
        {
            $retorno = true;
        }

        return $retorno;  
    }

    //Traera todos los objetos de la base de datos y los cargara en un array
    public function Traer()
    {
        $ovnis = array();
        $objetoAccesoDato =AccesoDatos::DameUnObjetoAcceso();
        $consulta = $objetoAccesoDato->RetornarConsulta("SELECT * FROM ovnis");
        $consulta->execute();

        while($fila = $consulta->fetch())
        {
            $ovn= new Ovni($fila[1], $fila[2], $fila[3], $fila[4]);    //no guardo el id
            array_push($ovnis, $ovn);
        }

        return $ovnis;
    }

    // retorna la velocidad del ovni multiplicada por 10.45 JULES.
    public function ActivarVelocidadWarp()
    {
        return $this->_velocidad * 10.45;
    }

    //retorna true, si la instancia actual está en el array de objetos de tipo Ovni que recibe como
    //parámetro. Caso contrario retorna false.
    public function Existe($arrayOvnis)
    {
        $retorno = false;

        foreach($arrayOvnis as $item)
        {
            if($this->ToJson() == $item->ToJson())
            {
                $retorno=true;
                break;
            }
        }
        return $retorno;
    }
}