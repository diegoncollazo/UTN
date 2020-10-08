<?php
require_once "./clases/Usuario.php";

$email = isset($_POST['email']) ? $_POST['email'] : NULL;
$clave = isset($_POST['clave']) ? $_POST['clave'] : NULL;

$usuario = new Usuario($email, $clave);

if(Usuario::VerificarExistencia($usuario))
{
    $cookieMail = str_replace(".", "_", $email);
    setcookie($cookieMail, date("d/m/Y - G:i:s"), time()+10);
    header("location:ListadoUsuarios.php");
}

else
{ 
    echo "El usuario no existe";
}