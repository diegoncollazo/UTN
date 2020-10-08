<?php

require_once "./clases/Usuario.php";

$arrayUsuarios= Usuario::TraerTodos();
$retorno="";

foreach($arrayUsuarios as $item)
{
    echo $retorno.=$item->ToString()."<br>"; 
}