<?php

require_once "./clases/ovni.php";

//tomo los datos por post
$tipo = isset($_POST["tipo"]) ? $_POST["tipo"] : NULL;
$velocidad = isset($_POST["velocidad"]) ? $_POST["velocidad"] : NULL;
$planeta = isset($_POST["planeta"]) ? $_POST["planeta"] : NULL;


//creo un objeto json para comunicar lo que paso
$objJson =  new stdClass();
$objJson->Exito=false;
$objJson->Mensaje="No se puede agregar el ovni";

//creo un ovni con los datos recibidos
$ovni = new Ovni($tipo,$velocidad,$planeta);

//y los agrego
if($ovni->Agregar())    
{
    $objJson->Exito=true;
    $objJson->Mensaje="Se agrego con exito el ovni!";
}

var_dump($objJson);