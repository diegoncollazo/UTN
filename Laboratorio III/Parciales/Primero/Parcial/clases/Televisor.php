<?php
require "IParte2.php";
require "IParte3.php";
require "AccesoDatos.php";

class Televisor implements IParte2, IParte3
{
    public $tipo;
    public $precio;
    public $paisOrigen;
    public $path;

    public function __construct($tipo = null, $precio = null, $paisOrigen = null, $path = null)
    {
        $this->tipo = $tipo != null ? $tipo : "";
        $this->precio = $precio != null ? $precio : "";
        $this->paisOrigen = $paisOrigen != null ? $paisOrigen : "";
        $this->path = $path != null ? $path : "";
    }

    public function ToString()
    {
        return $this->tipo ." - ". $this->precio ." - ". $this->paisOrigen ." - ". $this->path;
    }

    //No le paso el id porque es AI
    public function Agregar()
    {
        $retorno = false;
        $objetoAccesoDato = AccesoDatos::DameUnObjetoAcceso(); 
        $consulta =$objetoAccesoDato->RetornarConsulta("INSERT INTO televisores (tipo, precio, pais, foto)"
                                                    . "VALUES(:tipo, :precio, :pais, :foto)"); 
        
        $consulta->bindValue(':tipo', $this->tipo, PDO::PARAM_STR);
        $consulta->bindValue(':precio', $this->precio, PDO::PARAM_INT);
        $consulta->bindValue(':pais', $this->paisOrigen, PDO::PARAM_STR);
        $consulta->bindValue(':foto', $this->path, PDO::PARAM_STR);
        $consulta->execute();

        if (($consulta->rowCount())>0) 
        {
            $retorno = true;
        }

        return $retorno;        
    }

    public function Traer()
    {
        $televisores = array();
        $objetoAccesoDato =AccesoDatos::DameUnObjetoAcceso();
        $consulta = $objetoAccesoDato->RetornarConsulta("SELECT * FROM televisores");
        $consulta->execute();

        while($fila = $consulta->fetch())
        {
            $tele= new Televisor($fila[1], $fila[2], $fila[3], $fila[4]);
            array_push($televisores, $tele);
        }

        return $televisores;
    }

    public function CalcularIva()
    {           
        return $this->precio * 1.21;
    }

    public function Verificar($televisor)
    {
        $retorno = true;
        $arrayTele = $this->Traer();

        foreach($arrayTele as $item)
        {
            if($televisor->tipo == $item->tipo && $televisor->paisOrigen == $item->paisOrigen)
            {
                $retorno=false;
                break;
            } 
        }

        return $retorno;
    }

    //Solo le paso el ID y el televisor para cambiar todo
    public function Modificar($id, $televisor)  
    {
        $retorno = false;
        $objetoAccesoDato = AccesoDatos::dameUnObjetoAcceso();                                                 
        $consulta = $objetoAccesoDato->RetornarConsulta("UPDATE televisores SET tipo=:tipo, precio=:precio, 
                        pais=:pais, foto=:foto WHERE id=:id");
                                                     
        $consulta->bindValue(':id', $id, PDO::PARAM_INT);  

        $consulta->bindValue(':tipo', $televisor->tipo, PDO::PARAM_STR);
        $consulta->bindValue(':precio', $televisor->precio, PDO::PARAM_INT);
        $consulta->bindValue(':pais', $televisor->paisOrigen, PDO::PARAM_STR);
        $consulta->bindValue(':foto', $televisor->path, PDO::PARAM_STR);
        $consulta->execute();

        if($consulta->rowCount() > 0)
        {
            $retorno = true;
        }
        return $retorno;
    }

    public function TraerId($id)
    {
        $ovniRet = null;
        $objetoAccesoDato = AccesoDatos::dameUnObjetoAcceso();
        $consulta = $objetoAccesoDato->RetornarConsulta("SELECT * FROM televisores WHERE id=:id");
        $consulta->bindValue(':id',  $id, PDO::PARAM_INT);
        $consulta->execute();
        $fila=$consulta->fetch();

        if($fila!==null)
        {
            $ovniRet= new Televisor($fila[1],$fila[2],$fila[3],$fila[4]);
        }
        
        return $televisor;
    }
}