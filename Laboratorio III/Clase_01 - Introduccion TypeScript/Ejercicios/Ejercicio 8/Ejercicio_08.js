"use strict";
/*Crear una función que realice el cálculo factorial del número que recibe como parámetro.
Nota: Utilizar console.log()*/
function Factorial(numero) {
    var retorno = 1;
    for (var i = 1; i <= numero; i++) {
        retorno *= i;
    }
    return retorno;
}
var test = Factorial;
var factorial = 4;
console.log("El factorial del numero " + factorial + " es: " + test(factorial));
//# sourceMappingURL=Ejercicio_08.js.map