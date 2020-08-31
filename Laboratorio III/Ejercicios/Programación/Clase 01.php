<?php
echo 'Ejercio 01.<br/>';
$nombre = 'Diego';
$apellido = 'Collazo';
echo $apellido.', '.$nombre.'<br/>';

echo '<br/>Ejercio 02.<br/>';
$x = -3;
$y = 15;
$z= $x + $y;
echo 'El resultado de la suma es: '.$z.'<br/>';

echo '<br/>Ejercio 03.<br/>';
$x = -3;
$y = 15;
$z= $x + $y;
echo 'El valor de x es: '.$x.'<br/>';
echo 'El valor de y es: '.$y.'<br/>';
echo 'El resultado de la suma es: '.$z.'<br/>';

echo '<br/>Ejercio 04.<br/>';
$total = 0;
$contador = 0;
do {
    if ($total + $contador <= 1000) {
        $total += $contador;
        $contador++;
    }
    else{
        break;
    }
}while (true);
echo 'Suma total: '.$total.'<br/>';
echo 'Cantidad de enteros: '.$contador.'<br/>';

echo '<br/>Ejercio 05.<br/>';
$a = 6; $b = 9; $c = 8;

if ($a > $b && $b < $c)
    echo 'Es B';
else if ($b > $c && $c < $a)
    echo 'Es C';
else if ($b > $a && $a < $c)
    echo 'Es A';



?>