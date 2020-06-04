/*Crear una función que realice el cálculo factorial del número que recibe como parámetro.
Nota: Utilizar console.log()*/

function Factorial(numero : number) : number
{
    var retorno : number = 1;

    for(var i : number = 1; i <= numero; i ++)
    {
        retorno *= i;
    }

    return retorno;
}

var test : Function = Factorial;
var factorial : number = 4;

console.log("El factorial del numero " + factorial + " es: " + test(factorial));