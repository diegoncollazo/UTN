"use strict";
/*Realizar una función que reciba un parámetro requerido de tipo numérico y otro opcional
de tipo cadena. Si el segundo parámetro es recibido, se mostrará tantas veces por
consola, como lo indique el primer parámetro. En caso de no recibir el segundo
parámetro, se mostrará el valor inverso del primer parámetro.*/
function Opcional(numero, cadena) {
    var retorno = "";
    if (cadena) {
        for (var i = 0; i < numero; i++) {
            retorno += cadena + "\n";
        }
    }
    else {
        retorno = "-" + numero;
    }
    return retorno;
}
var ejemplo = Opcional;
console.log(ejemplo(3, "Carla"));
console.log(ejemplo(5));
//# sourceMappingURL=Ejercicio_03.js.map