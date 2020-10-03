<?php

require_once "./clases/ufologo.php";

$arrayUfolos= Ufologo::TraerTodos();
$retorno="";

foreach($arrayUfolos as $ufologox)
{
    $retorno.=$ufologox->ToJson()."<br>"; 
}

echo $retorno;