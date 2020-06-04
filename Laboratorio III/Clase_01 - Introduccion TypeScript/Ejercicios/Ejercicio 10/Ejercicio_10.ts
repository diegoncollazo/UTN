/*Definir una función que muestre información sobre una cadena de texto que se le pasa
como argumento. A partir de la cadena que se le pasa, la función determina si esa cadena
está formada sólo por mayúsculas, sólo por minúsculas o por una mezcla de ambas.*/

function Cadena(cadena : string) : string
{
    var retorno : string = "";

    if(cadena == cadena.toUpperCase()) //Todo mayuscula
    {
        retorno = "Solo contiene mayúsculas.";
    }

    else if(cadena == cadena.toLocaleLowerCase())
    {
        retorno = "Solo contiene minúsculas.";
    }

    else
    {
        retorno = "Contiene mayúsculas y minúsculas.";
    }

    return retorno;
}

var test1 : Function = Cadena;
var test2 : Function = Cadena;
var test3 : Function = Cadena;

console.log(test1("Casa"));
console.log(test2("DADO"));
console.log(test3("perla"));
