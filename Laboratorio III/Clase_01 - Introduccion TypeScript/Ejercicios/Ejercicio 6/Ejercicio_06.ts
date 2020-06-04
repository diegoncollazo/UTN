/*Realizar una función que reciba como parámetro un número y que retorne el cubo del
mismo.
Nota: La función retornará el cubo del parámetro ingresado. Realizar una función que
invoque a esta última y permita mostrar por consola el resultado.*/

function AlCubo(numero:number):number
{
    return Math.pow(numero, 3);
}

var cubo:number = 4;
var test : Function = AlCubo;

console.log("El cubo del numero " + cubo + " es: " + test(cubo));