<?php

$jsonCookie = isset($_GET['jsonCookie']) ? $_GET['jsonCookie'] : NULL;
$retornoJson = new stdClass();

//y se verificará si existe una cookie con el mismo nombre, 
// de ser así, retornará un JSON que contendrá: éxito(bool) y mensaje(string), dónde se mostrará el contenido de la cookie. 
if(isset($_COOKIE[$jsonCookie])) 
{
    $retornoJson->exito = true;
    $retornoJson->mensaje = $_COOKIE[$jsonCookie];
}

else
{  // Caso contrario, false y el mensaje indicando lo acontecido.
    $retornoJson->exito = false;
    $retornoJson->mensaje = "No hay una cookie con el mismo legajo";
}

echo json_encode($retornoJson);