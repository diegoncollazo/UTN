<?php

require "./clases/ovni.php";

$ovniJson = isset($_POST['ovniJson']) ? ($_POST['ovniJson']) : NULL;

$variableJson = json_encode($ovniJson);
echo "var dump";
var_dump($variableJson);

$objOvni = new Ovni($variableJson->tipo,$variableJson->velocidad,$variableJson->planeta);
var_dump($objOvni);
$test = new Ovni("aplanado", "10", "marte");
var_dump($test->ToJSON());

$arrayOvni=$objOvni->Traer();

if($objOvni->Existe($arrayOvni))
{
    echo $objOvni->ToJSON();
}

else
{
    echo "el ovni no existe";
}