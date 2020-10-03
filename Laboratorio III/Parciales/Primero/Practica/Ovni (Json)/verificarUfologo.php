<?php
require "./clases/ufologo.php";

$legajo = isset($_POST['legajo']) ? $_POST['legajo'] : NULL;
$clave = isset($_POST['clave']) ? $_POST['clave'] : NULL;

$ufologo = new Ufologo("p", $legajo, $clave);

// crear una COOKIE nombrada con el legajo del ufólogo, que guardará la fecha actual (con
// horas, minutos y segundos) más el retorno del mensaje del método VerificarExistencia. Luego ir a
// ListadoUfologos.php.
$verficar = Ufologo::VerificarExistencia($ufologo);

if($verficar->exito)
{
    //seteo la cookie con el legajo, fecha y 10seg de duracion
    $cookie = setcookie($legajo, date("d/m/Y - G:i:s"));
    echo $verficar->mensaje;
    //luego redirecteo al listado
    header("location:listadoUfologos.php");
}

else
{  //Caso contrario, retornar un JSON que contendrá: éxito(bool) y mensaje(string) indicando lo acontecido
    // (agregar el mensaje obtenido del método de clase).
    $retornoJson = new stdClass();
    $retornoJson->exito=false;
    echo $verficar->mensaje;
    echo json_encode($retornoJson);
}
