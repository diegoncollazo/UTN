<?php
require "./clases/ufologo.php";

//Recibo por post todas las variables de la clase
$pais = isset($_POST['pais']) ? $_POST['pais'] : NULL;
$legajo = isset($_POST['legajo']) ? $_POST['legajo'] : NULL;
$clave = isset($_POST['clave']) ? $_POST['clave'] : NULL;

//creo un nuevo ufologo con lo que recibi por post
$ufologo = new Ufologo($pais, $legajo, $clave);
//invoco al metodo guardar en archivo
$alta = $ufologo->GuardarEnArchivo();

//verifico si guardo con exito y guardo en json
if($alta->exito==true)
{
    echo json_encode($alta);
}