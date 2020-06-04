"use strict";
/*Realizar una función que reciba un número y que muestre (por consola) un mensaje
como el siguiente:
El número 5 es impar , siendo 5 el número recibido como parámetro.*/
function ParImpar(numero) {
    var retorno = "";
    if (numero % 2 == 0) {
        retorno = "El número " + numero + " es par";
    }
    else {
        retorno = "El número " + numero + "es impar";
    }
    return retorno;
}
var test = ParImpar;
console.log(test(3));
console.log(test(6));
//# sourceMappingURL=Ejercicio_04.js.map