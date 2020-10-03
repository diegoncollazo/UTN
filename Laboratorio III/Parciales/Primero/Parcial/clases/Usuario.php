<?php
class Usuario
{
    private $_email;
    private $_clave;

    public function __construct($email, $clave)
    {
        $this->_email = $email;
        $this->_clave = $clave;             
    }

    public function ToString()
    {
        return $this->_email ." - ". $this->_clave;
    }

    public function GuardarEnArchivo()
    {
        $ar = fopen("./archivos/usuarios.txt", "a");
        $retorno = false;

        if($ar != false)
        {
            $escrito = fwrite($ar, $this->ToString()."\r\n");

            if($escrito > 0)
            { 
                echo "El usuario se ha guardado.";
                $retorno =true;
            }

            fclose($ar);
        }

        return $retorno;
    }

    public static function TraerTodos()
    {
        $usuariosLeidos = array();
        
        if(file_exists("./archivos/usuarios.txt")) 
        {
            $ar = fopen("./archivos/usuarios.txt", "r"); 

            if($ar != false) 
            {
                while(!feof($ar)) 
                {
                    $linea = trim(fgets($ar)); 
                    $usuarios = explode("-", $linea); 
                    $usuarios[0] = trim($usuarios[0]);

                    if($usuarios[0] != "") 
                    { 
                        $usuariosLeidos[] = new Usuario($usuarios[0], $usuarios[1]); 
                    }
                }

                fclose($ar); 
            }
        }

        return $usuariosLeidos;
    }

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