<?php
    $numero = 39;
    echo gettype($numero);
    echo '</br>';
    echo var_dump($numero);
    echo '</br>';

    $texto = '"Edad: '.$numero.'"</br>';
    echo $texto;

    $texto = "\"Edad: $numero \"</br>";
    echo $texto;

    // Constantes
    define('nombre', 'Diego');
    echo nombre.'</br>';

    // Constantes predefinidas
    echo PHP_OS.'</br>';
    echo PHP_VERSION.'</br>';
    echo __LINE__.'</br>';

    