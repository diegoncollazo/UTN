<?php
require_once "./clases/Televisor.php";

$tipo = isset($_POST['tipo']) ? $_POST['tipo'] : NULL;
$precio = isset($_POST['precio']) ? $_POST['precio'] : NULL;
$pais = isset($_POST['pais']) ? $_POST['pais'] : NULL;
$foto = isset($_FILES["foto"]["name"]) ? $_FILES["foto"]["name"] : NULL;

$extension = pathinfo($foto, PATHINFO_EXTENSION);
$nombreFoto= $tipo . "." . $pais. "." . date("Gis") . "." . $extension;
$destino = "./televisores/imagenes/" . $nombreFoto;

$televisor = new Televisor($tipo, $precio, $pais, $nombreFoto);

if($tipo != "" && $precio != "" && $pais != "" && $foto != "")
{
    if($televisor->Agregar())
    {
        if(move_uploaded_file($_FILES["foto"]["tmp_name"], $destino))
        {
            header('Location:Listado.php');
        }
    }
}

else
{
    echo "no se pudo agregar";
}
