#include <stdio.h>
#include <stdlib.h>

int validarRangoEntero(int valor, int limiteInferior, int limiteSuperior){
    int respuesta = 0;
    if (valor > limiteInferior && valor < limiteSuperior){
        respuesta = 1;
    }
    return respuesta;
}
