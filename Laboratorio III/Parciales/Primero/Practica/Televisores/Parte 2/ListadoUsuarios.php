<?php
//(GET) Se mostrará el listado de todos los empleados en formato JSON.

require_once "./clases/Usuario.php";

$arrayUsuarios= Usuario::TraerTodos();
$retorno="";

foreach($arrayUsuarios as $item)
{
    $retorno.=$item->ToString()."<br>"; //llamo a tojson para que los formatee y los guardo en el retorno
}
echo $retorno;