#include "persona.h"
#include <stdio.h>


void init(EPersona lista[], int len){
    int i;
    for(i=0; i<len; i++){
        lista[i].isEmpty = 1;
    }
}

int obtenerEspacioLibre(EPersona lista[], int len){
    //Le paso array peronas y la cantidad

    int i;
    int retorno = -1;

    for(i=0; i<len; i++){
        if(lista[i].isEmpty == 1){
            retorno = i;
            break;
        }
    }
    return retorno;
}


void alta(EPersona lista[], int len){
    int index;

    index = obtenerEspacioLibre(lista, len);

    if(index != -1){
        printf("Ingrese apellido: ");
        fflush(stdin);
        fgets(lista[index].apellido, 31-2, stdin);
        printf("Ingrese nombre: ");
        fflush(stdin);
        fgets(lista[index].nombre, 31-2, stdin);
        printf("Ingrese DNI: ");
        scanf("%ld",&lista[index].dni);
        printf("Ingrese día de nacimiento: ");
        scanf("%d",&lista[index].feNac.dia);
        printf("Ingrese mes de nacimiento: ");
        scanf("%d",&lista[index].feNac.mes);
        printf("Ingrese ano de nacimiento: ");
        scanf("%d",&lista[index].feNac.anio);
        lista[index].isEmpty = 0;
    }
    else{
        //no hay espacio libre
    }
    return;
}

void listar(EPersona lista[], int len){
    int i;
    for (i=0; i<len; i++){
        if (lista[i].isEmpty == 0){
            printf("\nApellido\t\tNombre\t\tDNI\tNacimiento\n");

            printf("%s\t\t%s\t\t%ld\t%2d/%2d/%4d",lista[i].apellido,lista[i].nombre,lista[i].dni,lista[i].feNac.dia,lista[i].feNac.mes,lista[i].feNac.anio);
        }
    }
}
