#include <stdio.h>
#include <stdlib.h>
#include "Collazo.h"

int main(){
    int edad, respuesta;
    printf("Ingrese la edad a verificar: ");
    scanf("%d",&edad);
    respuesta = validarRangoEntero(edad, 17, 66);
    if (respuesta){
        printf("Usted es apto para trabajar.");
    }
    else{
        printf("Usted no es apto para trabajar.");
    }
    return 0;
}
