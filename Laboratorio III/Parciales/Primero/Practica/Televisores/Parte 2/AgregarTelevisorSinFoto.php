<?php
require_once "./clases/Televisor.php";

//Se recibe por POST el tipo, el precio y el paisOrigen. 
$tipo = isset($_POST['tipo']) ? $_POST['tipo'] : NULL;
$precio = isset($_POST['precio']) ? $_POST['precio'] : NULL;
$pais = isset($_POST['pais']) ? $_POST['pais'] : NULL;

$televisor = new Televisor($tipo, $precio, $pais);

if($televisor->tipo != "")
{
    if($televisor->Agregar())
    {
        echo "se agrego a la base de datos";
    }
}

else
{
    echo "error";
}
