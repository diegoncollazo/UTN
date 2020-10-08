<?php
require_once "./clases/Televisor.php";

$tipo = isset($_POST['tipo']) ? $_POST['tipo'] : NULL;
$precio = isset($_POST['precio']) ? $_POST['precio'] : NULL;
$pais = isset($_POST['pais']) ? $_POST['pais'] : NULL;
$foto = isset($_FILES["foto"]["name"]) ? $_FILES["foto"]["name"] : NULL;
$id = isset($_POST['id']) ? $_POST['id'] :NULL;

$extension = pathinfo($foto, PATHINFO_EXTENSION);
$nombreFotoNueva = $tipo . "." . $pais. "." . date("Gis") . "." . $extension;
$destino = "./televisores/imagenes/" . $nombreFoto;

$televisor= new Televisor($tipo, $precio, $pais, $foto);
$televisorAnterior = $televisor->TraerId();

if($televisor->Modificar($id, $televisor))
{
    if(move_uploaded_file($_FILES["foto"]["tmp_name"], $destino))
    {  
        //me falto hacer lo de la foto vieja y tampoco probe si andaba el modificar de esta manera
        header("location:Listado.php");
    }

}
else
{
    echo "no se pudo modificar";
}