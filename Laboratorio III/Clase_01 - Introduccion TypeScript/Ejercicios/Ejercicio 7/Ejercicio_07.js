"use strict";
/*Se necesita mostrar por consola los primeros 20 números primos. Para ello realizar una
función.
Nota: Utilizar console.log()*/
function Primo(numero) {
    var retorno = true;
    for (var i = 2; i <= numero - 1; i++) {
        if (numero % i == 0) {
            retorno = false;
        }
    }
    return retorno;
}
for (var i = 2; i <= 71; i++) {
    if (Primo(i)) {
        console.log(i);
    }
}
//# sourceMappingURL=Ejercicio_07.js.map