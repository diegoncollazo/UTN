<?php
require_once "./clases/Televisor.php";

//ModificarTelevisor.php: Se recibirán por POST todos los valores (incluida una imagen) para 
//modificar un televisor en la base de datos. 
$tipo = isset($_POST['tipo']) ? $_POST['tipo'] : NULL;
$precio = isset($_POST['precio']) ? $_POST['precio'] : NULL;
$pais = isset($_POST['pais']) ? $_POST['pais'] : NULL;
$foto = isset($_FILES["foto"]["name"]) ? $_FILES["foto"]["name"] : NULL;
$id = isset($_POST['id']) ? $_POST['id'] :NULL;

$extension = pathinfo($foto, PATHINFO_EXTENSION);
$nombreFoto= $tipo . "." . $pais. "." . date("Gis") . "." . $extension;
$destino = "./televisores/imagenes/" . $nombreFoto;

$retornoJson = new stdClass();
$televisor= new Televisor($tipo, $precio, $pais, $foto);
unlink("./ovnis/imagenes/" . $televisor->path);
//Invocar al método Modificar.
if($televisor->Modificar($id, $televisor))
{
    if(move_uploaded_file($_FILES["foto"]["tmp_name"], $destino))
    {  
        header("location:Listado.php");
    }

}
else
{//Si no se pudo modificar, se mostrará un JSON que contendrá: éxito(bool) y mensaje(string) indicando lo acontecido.     
    echo "no se pudo modificar";
}