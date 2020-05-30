#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "../../GitHub/C/TPs/Bibliotecas/utn.h"

int main(){
    char auxiliar;
    int respuesta;
//    printf("Ingrese el sexo: ");
//    fflush(stdin);
//    scanf("%c",&auxiliar);
    auxiliar = getChain("Ingrese sexo: ");
    strlwr(&auxiliar);
    respuesta = isCharacter(auxiliar);
    if (respuesta)
        printf("Correcto");
    else
        printf("Incorrecto");
    return 0;
}
