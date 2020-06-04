"use strict";
/*Guardar su nombre y apellido en dos variables distintas. Dichas variables serán pasadas
como parámetro de la función MostrarNombreApellido, que mostrará el apellido en
mayúscula y el nombre solo con la primera letra en mayúsculas y el resto en minúsculas.
El apellido y el nombre se mostrarán separados por una coma (,).
Nota: Utilizar console.log()*/
var nombre = "zahira";
var apellido = "barriento";
function MostrarNombreApellido(nombre, apellido) {
    return apellido.toUpperCase() + "," + nombre.charAt(0).toUpperCase() + nombre.slice(1);
}
var test = MostrarNombreApellido;
console.log(test(nombre, apellido));
//# sourceMappingURL=Ejercicio_05.js.map