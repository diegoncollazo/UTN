<?php
//Se recibe por POST el email y la clave. Invocar al método GuardarEnArchivo.

require_once "./clases/Usuario.php";

$email = isset($_POST['email']) ? $_POST['email'] : NULL;
$clave = isset($_POST['clave']) ? $_POST['clave'] : NULL;

$usuario = new Usuario($email, $clave);

if(Usuario::GuardarEnArchivo($usuario))
{
    echo "se ha dado de alta el usuario";
}
