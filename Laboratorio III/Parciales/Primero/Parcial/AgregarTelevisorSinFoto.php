<?php
require_once "./clases/Televisor.php";
 
$tipo = isset($_POST['tipo']) ? $_POST['tipo'] : NULL;
$precio = isset($_POST['precio']) ? $_POST['precio'] : NULL;
$pais = isset($_POST['pais']) ? $_POST['pais'] : NULL;

$televisor = new Televisor($tipo, $precio, $pais);

if($tipo != "" && $precio != "" && $pais != "")
{
    if($televisor->Verificar($televisor))
    {
        if($televisor->Agregar())
        {
            echo "El televisor se agrego correctamente.";
        }
    }

    else
    {
        echo "El televisor ya existe.";
    }
}

else
{
    echo "ERROR.";
}
