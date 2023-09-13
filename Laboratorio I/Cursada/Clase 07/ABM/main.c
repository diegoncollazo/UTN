#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#include "../../Bibliotecas/collazo.h"

#define FILAS 200

void ordenamientoPorApellido(char nombre[][COLUMNAS], char apellido[][COLUMNAS], int *edad, int *legajo, int *isEmpty);

int main(){
    char nombre[FILAS][COLUMNAS], nombreAux[COLUMNAS];
    char apellido[FILAS][COLUMNAS], apellidoAux[COLUMNAS];
    int isEmpty[FILAS], isEmptyAux;
    int legajo[FILAS], legajoAux;
    int edad[FILAS], edadAux;
    int i, j, opcion = 0, bandera1 = 0;

    for (i=0; i<FILAS; i++){ //Inicializo el vector isEmpty(todos vacios)
        isEmpty[i]=1;
    }

    //Hardcoding carga
    strcpy(nombre[0],"Juan");
    strcpy(apellido[0],"Silva");
    legajo[0] = 1;
    edad[0] = 20;
    strcpy(nombre[1],"Diego");
    strcpy(apellido[1],"Collazo");
    legajo[1] = 2;
    edad[1] = 30;
    strcpy(nombre[2],"Ignacio");
    strcpy(apellido[2],"Aguirre");
    legajo[2] = 3;
    edad[2] = 50;
    strcpy(nombre[3],"Nicolas");
    strcpy(apellido[3],"Amaral");
    legajo[3] = 4;
    edad[3] = 40;
    for (j=0; j<4; j++){
        isEmpty[j]=0;
    }

    do{
        system("cls");
        printf("1.- Nuevo contacto: \n");
        printf("\n2.- Modificar contacto: \n");
        printf("\n3.- Borrar contacto: \n");
        printf("\n4.- Listar contactos: \n");
        printf("\n5.- Salir de la agenda: \n");
        printf("\nIngrese una opcion: ");
        scanf("%d",&opcion);
        switch(opcion){
        case 1:
            getContact(nombre,apellido,edad,legajo,isEmpty,FILAS);
            break;
        case 2:
            //Buscar por legajo
            printf("\nLegajo: ");
            scanf("%d",&legajoAux);
            bandera1 = 0;
            for (int i=0; i<FILAS ; i++){
                if (legajoAux == legajo[i] && isEmpty[i] == 0){
                    isEmpty[i]=1;
                    bandera1 = 1;
                    printf("Dato encontrado.");
                    fflush(stdin);
                    getchar();
                }
            }
            if (bandera1 ==0 ){
                printf("Dato no encontrado.");
                fflush(stdin);
                getchar();
            }
            break;
        case 3:
            //como uso el isEmpty
            for (i=0; i<FILAS-1; i++){
                /*if (isEmpty[i]==0){
                    continue;
                }*/
                for (j=i+1; j<FILAS; j++){
                    /*if (isEmpty[j]==0){
                        continue;
                    }*/
                    if(strcmp(apellido[i],apellido[j]) > 0){
                        strcpy(nombreAux, nombre[i]);
                        strcpy(nombre[i], nombre[j]);
                        strcpy(nombre[j], nombreAux);

                        strcpy(apellidoAux, apellido[i]);
                        strcpy(apellido[i], apellido[j]);
                        strcpy(apellido[j], apellidoAux);

                        edadAux = edad[i];
                        edad[i] = edad[j];
                        edad[j] = edadAux;

                        legajoAux = legajo[i];
                        legajo[i] = legajo[j];
                        legajo[j] = legajoAux;

                        isEmptyAux = isEmpty[i];
                        isEmpty[i] = isEmpty[j];
                        isEmpty[j] = isEmptyAux;

                        printf("i: %d - j: %d", i, j);
                    }
                }
            }

            break;
        case 4:
            contactShow(nombre,apellido,edad,legajo,isEmpty,FILAS);
            break;
        default:
            break;
        }
    }
    while (opcion != 5);
    return 0;
}


