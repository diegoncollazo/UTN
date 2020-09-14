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
    } else {
        break;
    }
} while (true);
echo 'Suma total: '.$total.'<br/>';
echo 'Cantidad de enteros: '.$contador.'<br/>';

echo '<br/>Ejercio 05.<br/>';
$a = 5; $b = 9; $c = 8;
if ($a > $b && $b < $c && $a != $c) {
    echo 'Es B.<br/>';
} elseif ($b > $c && $c < $a && $b != $a) {
    echo 'Es C.<br/>';
} elseif ($b > $a && $a < $c && $b != $c) {
    echo 'Es A.<br/>';
} else {
    echo 'No hay valor del medio.<br/>';
}

echo '<br/>Ejercio 06.<br/>';
$operador = '-';
$op1 = 50;
$op2 = 20;
$resultado = 0;
switch ($operador) {
    case '+':
        $resultado = $op1+$op2;
        echo 'La suma es igual a: '.$resultado.'<br/>';
        break;
    case '*':
        $resultado = $op1*$op2;
        echo 'La multiplicación es igual a: '.$resultado.'<br/>';
        break;
    case '-':
        $resultado = $op1-$op2;
        echo 'La resta es igual a: '.$resultado.'<br/>';
        break;
    case '/':
        $resultado = $op1/$op2;
        echo 'La división es igual a: '.$resultado.'<br/>';
        break;
}

echo '<br/>Ejercio 07.<br/>';
// Imprime: July 1, 2000 is on a Saturday
echo "July 1, 2000 is on a " . date("l", mktime(0, 0, 0, 7, 1, 2000));

echo '<br/>Ejercio 08.<br/>';
function number_suffix($number)
{
    // Validate and translate our input
    if (is_numeric($number)) {
        // Get the last two digits (only once)
        $n = $number % 100;
    } else {
        // If the last two characters are numbers
        if (preg_match('/[0-9]?[0-9]$/', $number, $matches)) {
            // Return the last one or two digits
            $n = array_pop($matches);
        } else {
            // Return the string, we can add a suffix to it
            return $number;
        }
    }
    // Skip the switch for as many numbers as possible.
    if ($n > 3 && $n < 21) {
        return $number . 'th';
    }

    // Determine the suffix for numbers ending in 1, 2 or 3, otherwise add a 'th'
    switch ($n % 10) {
      case '1': return $number . 'st';
      case '2': return $number . 'nd';
      case '3': return $number . 'rd';
      default:  return $number . 'th';
    }
}
  echo number_suffix(24);
