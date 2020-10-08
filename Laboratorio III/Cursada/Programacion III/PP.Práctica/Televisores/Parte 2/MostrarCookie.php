<?php

$cookie = isset($_GET['cookie']) ? $_GET['cookie'] : NULL;

//y se verificará si existe una cookie con el mismo nombre, 
// de ser así, retornará un JSON que contendrá: éxito(bool) y mensaje(string), dónde se mostrará el contenido de la cookie. 
if(isset($_COOKIE[$cookie])) 
{
    echo $_COOKIE[$cookie];
}

else
{  // Caso contrario, false y el mensaje indicando lo acontecido.
    echo "no existe la cookie";
}
