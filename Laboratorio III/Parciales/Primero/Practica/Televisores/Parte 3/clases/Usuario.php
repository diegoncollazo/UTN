<?php
class Usuario
{
    //atributos privados
    private $_email;
    private $_clave;

    //constructor
    public function __construct($email, $clave)
    {
        $this->_email = $email;
        $this->_clave = $clave;             
    }

    //método de instancia ToJSON(), que retornará los datos de la instancia (en una cadena con formato JSON)
    public function ToString()
    {
        return $this->_email ."-". $this->_clave;
    }

    //Método de instancia GuardarEnArchivo(), que agregará al usuario en ./archivos/usuarios.txt.
    public static function GuardarEnArchivo($obj)
    {
        $ar = fopen("./archivos/usuarios.txt", "a");
        $retorno = false;

        if($ar != false && $obj != null)
        {
            $escrito = fwrite($ar, $obj->ToString()."\r\n");

            if($escrito>0)
            { 
                $retorno =true;
                echo "usuario guardado con exito";
            }

            fclose($ar);
        }

        return $retorno;
    }

    //Método de clase TraerTodos(), que retornará un array de objetos de tipo Usuario.
    public static function TraerTodos()
    {
        $usuariosLeidos = array();
        
        if(file_exists("./archivos/usuarios.txt")) 
        { //si existe
            $ar = fopen("./archivos/usuarios.txt", "r"); //abro archivo

            if($ar != false) 
            {
                while(!feof($ar)) 
                {
                    $linea = trim(fgets($ar)); //obtiene la linea sin espacios
                    $usuarios = explode("-", $linea); 

                    if($usuarios[0] != "") 
                    { 
                        $usuariosLeidos[] = new Usuario($usuarios[0], $usuarios[1]); 
                    }
                }

                fclose($ar); //cierro el archivo
            }
        }

        return $usuariosLeidos;
    }

    //Método de clase VerificarExistencia($usuario), retornará true, 
    //si el usuario está registrado (invocar a TraerTodos), caso contrario retornará false.
    public static function VerificarExistencia($usuario)
    {
        $retorno = false;
        $arrayUsuarios = Usuario::TraerTodos();

        foreach($arrayUsuarios as $item)
        {
          if($usuario->_email == $item->_email && $usuario->_clave == $item->_clave)
            {
                $retorno=true;
                break;
            } 
        }
        return $retorno;
    }
}