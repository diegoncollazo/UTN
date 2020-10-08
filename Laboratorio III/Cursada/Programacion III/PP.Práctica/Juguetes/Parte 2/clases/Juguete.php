<?php
require "./AccesoDatos.php";
require "IParte1.php";
require "IParte2.php";

class Juguete implements IParte1, IParte2
{
    //atributos privados
    private $_tipo;
    private $_precio;
    private $_paisOrigen;
    private $_pathImagen;

    //constructor con path como opcional
    public function __construct($tipo , $precio , $pais , $path = null)
    {
        $this->_tipo=$tipo;
        $this->_precio = $precio;
        $this->_paisOrigen = $pais;
        $this->_pathImagen = $path != null ? $path : "";
    }

    //Getters para conseguir atributos privados para listado
    public function GetTipo()
    {
        return $this->_tipo;
    }
    public function GetPrecio()
    {
        return $this->_precio;
    }
    public function GetPais()
    {
        return $this->_paisOrigen;
    }
    public function GetPath()
    {
        return $this->_pathImagen;
    }

    //un método de instancia ToString(), que retorna los datos de la instancia (separado por un guión medio).
    public function ToString()
    {
        return $this->_tipo . "-" . $this->_precio . "-" . $this->_paisOrigen . "-" . $this->_pathImagen;
    }

    //I1
    // ● Agregar: agrega, a partir de la instancia actual, un nuevo registro en la tabla juguetes 
    // (id, tipo, precio, pais, foto), de la base de datos juguetes_bd. Retorna true, si se pudo agregar, 
    // false, caso contrario.
    public function Agregar()
    {
        $retorno = false;
        $objetoAccesoDato = AccesoDatos::DameUnObjetoAcceso(); //no inserto el id porque es AI
        $consulta =$objetoAccesoDato->RetornarConsulta("INSERT INTO juguetes (tipo, precio, pais, foto)"
                                                    . "VALUES(:tipo, :precio, :pais, :foto)");                                          
        
        $consulta->bindValue(':tipo', $this->_tipo, PDO::PARAM_STR);
        $consulta->bindValue(':precio', $this->_precio, PDO::PARAM_INT);
        $consulta->bindValue(':pais', $this->_paisOrigen, PDO::PARAM_STR);
        $consulta->bindValue(':foto', $this->_pathImagen, PDO::PARAM_STR);
        $consulta->execute();

        if (($consulta->rowCount())>0) 
        {
            $retorno = true;
        }

        return $retorno;  
    }

    // ● Traer: retorna un array de objetos de tipo Juguete, recuperados de la base de datos.
    public function Traer()
    {
        $juguetes = array();
        $objetoAccesoDato =AccesoDatos::DameUnObjetoAcceso();
        $consulta = $objetoAccesoDato->RetornarConsulta("SELECT * FROM juguetes");
        $consulta->execute();

        while($fila = $consulta->fetch())
        {
            $jugue= new Juguete($fila[1], $fila[2], $fila[3], $fila[4]);    //no guardo el id
            array_push($juguetes, $jugue);
        }
        return $juguetes;
    }

    // ● CalcularIVA: retorna el precio del juguete más el 21%.
    public function CalcularIva()
    {
        if($this->_precio != "")
        {
            return $this->_precio * 1.21;            
        }
    }

        // ● Verificar: retorna true, si la instancia actual no existe en el array de objetos de tipo
    // Juguete que recibe como parámetro. Caso contrario retorna false.
    public function Verificar($arraJuguetes)
    {
        $retorno = true;
        
        foreach ($arraJuguetes as $juguete)
        {
            if($juguete->ToString() == $this->ToString())
            {
                $retorno = false;   //retorna false si la encuentra
                break;
            }
        }
        return $retorno;
    }

    //Agregar un método estático (en Juguete), llamado MostrarLog.
    public static function MostrarLog()
    {
        if(file_exists("./archivos/juguetes_sin_foto.txt"))
        {    //si el archivo existe
            $ar = fopen("./archivos/juguetes_sin_foto.txt", "r");   //lo abro en lectura
            
            while(!feof($ar))
            {  //mientras no llegue al fin
                $cadena = fgets($ar);  

                if($cadena=="")
                {
                    continue;   //no leer lo vacio
                }

                echo $cadena;
            }

            fclose($ar);
        }
    }

    // Modifica en la base de datos el registro coincidente con la instancia actual. Retorna true, si se
    // pudo modificar, false, caso contrario.
    public function Modificar($id, $juguete)  //lo hago haciendo que reciba una id y un juguete
    {
        $retorno = false;
        $objetoAccesoDato = AccesoDatos::dameUnObjetoAcceso();                                                 
        $consulta = $objetoAccesoDato->RetornarConsulta("UPDATE juguetes SET tipo=:tipo, precio=:precio, 
                                                            pais=:pais, foto=:foto WHERE id=:id");
                                                     
        $consulta->bindValue(':id', $id, PDO::PARAM_INT);  

        $consulta->bindValue(':tipo', $juguete->_tipo, PDO::PARAM_STR);
        $consulta->bindValue(':precio', $juguete->_precio, PDO::PARAM_INT);
        $consulta->bindValue(':pais', $juguete->_paisOrigen, PDO::PARAM_STR);
        $consulta->bindValue(':foto', $juguete->_pathImagen, PDO::PARAM_STR);
        $consulta->execute();

        if($consulta->rowCount() > 0)
        {
            $retorno = true;
        }

        return $retorno;
    }

     //creo una funcion para que me traiga un juegute particular para el moficar
     public function TraerId($id)
     {
        $jugueteRet = null;

        $objetoAccesoDato = AccesoDatos::dameUnObjetoAcceso();
        $consulta = $objetoAccesoDato->RetornarConsulta("SELECT * FROM juguetes WHERE id=:id");
        $consulta->bindValue(':id',  $id, PDO::PARAM_INT);
        $consulta->execute();

        $fila = $consulta->fetch();

        if($fila !== null)
        {
            $jugueteRet = new Juguete($fila[1],$fila[2],$fila[3],$fila[4]);
        }
        
        return $jugueteRet;
     }
}