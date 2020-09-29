"use strict";
function saludo(nombre: string): string{
    nombre.toUpperCase();
    return `Hola, "encantado" de 'verte', ${nombre}!`;
}

console.log(saludo(`Diego`));
