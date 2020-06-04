/*Realizar una función que solicite (por medio de un parámetro) un número. Si el número
es positivo, se mostrará el factorial de ese número, caso contrario se mostrará el cubo de
dicho número.
Nota: Reutilizar la función que determina el factorial de un número y la que calcula el
cubo de un número.*/

function AlCubo(numero) {
    return Math.pow(numero, 3);
}

function Factorial(numero) {
    var retorno = 1;
    for (var i = 1; i <= numero; i++) {
        retorno *= i;
    }

    return retorno;
}

function Calcular(numero) {
    var resultado = 0;
    if (numero > 0) {
        var factorial = Factorial;
        resultado = factorial(numero);
    }

    else {
        var cubo = AlCubo;
        resultado = cubo(numero);
    }
    return resultado;
}

var test = Calcular;

console.log("Positivo " + test(2));
console.log("Negativo " + test(-2));

