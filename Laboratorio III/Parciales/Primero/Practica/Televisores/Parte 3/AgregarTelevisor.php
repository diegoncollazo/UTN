<?php
require_once "./clases/Televisor.php";

//Se recibirán por POST todos los valores (incluida una imagen) para registrar un televisor en la base de datos.

$tipo = isset($_POST['tipo']) ? $_POST['tipo'] : NULL;
$precio = isset($_POST['precio']) ? $_POST['precio'] : NULL;
$pais = isset($_POST['pais']) ? $_POST['pais'] : NULL;
$foto = isset($_FILES["foto"]["name"]) ? $_FILES["foto"]["name"] : NULL;

$extension = pathinfo($foto, PATHINFO_EXTENSION);
//con el nombre formado por el tipo punto paisOrigen punto hora, minutos y segundos del alta (Ejemplo: led.china.105905.jpg).
$nombreFoto= $tipo . "." . $pais. "." . date("Gis") . "." . $extension;
// La imagen guardarla en “./televisores/imagenes/”, 
$destino = "./televisores/imagenes/" . $nombreFoto;
$televisor = new Televisor($tipo, $precio, $pais, $nombreFoto);

if($televisor->tipo != "")
{
    if($televisor->Agregar())

    if(move_uploaded_file($_FILES["foto"]["tmp_name"], $destino))
    {
        header('Location:Listado.php');
    }

}

else
{
    echo "no se pudo agregar";
}
