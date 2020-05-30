#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include "utn.h"
#include "alquileres.h"
#include "clientes.h"
#include "juegos.h"
#include "menus.h"
int main(){
    eJuego arrayJuegos[CANT_JUEGOS];
    eCliente arrayClientes[CANT_CLIENTES];
    eAlquileres arrayAlquileres[CANT_ALQUILERES];
    char opcion;
    int hayClientes, hayJuegos;
    inicializarJuegos(arrayJuegos, CANT_JUEGOS);
    inicializarClientes(arrayClientes, CANT_CLIENTES);
    inicializarAlquileres(arrayAlquileres, CANT_ALQUILERES);
    hardCodingData(arrayAlquileres, arrayJuegos, arrayClientes);
    do{
        hayJuegos = sinJuegos(arrayJuegos, CANT_JUEGOS);
        hayClientes = sinClientes(arrayClientes, CANT_CLIENTES);
        fflush(stdin);
        system("cls");
        printf("*** Menu principal ***\n");
        printf("\n1- ABM Juegos.\n");
        printf("\n2- ABM Clientes.\n");
        printf("\n3- ABM Alquileres.\n");
        printf("\n4- Informes.\n");
        printf("\n5- Salir.\n");
        printf("\nElija una opcion: ");
        scanf("%c",&opcion);
        switch(opcion){
            case '1':
                menuJuegos(arrayJuegos, CANT_JUEGOS, &hayJuegos);
                break;
            case '2':
                menuClientes(arrayClientes, CANT_CLIENTES, &hayClientes);
                break;
            case '3':
                menuAlquileres(arrayAlquileres, CANT_ALQUILERES, arrayJuegos, CANT_JUEGOS, arrayClientes, CANT_CLIENTES, hayClientes, hayJuegos);
                break;
            case '4':
                menuInformes(arrayAlquileres, CANT_ALQUILERES, arrayJuegos, CANT_JUEGOS, arrayClientes, CANT_CLIENTES, hayClientes, hayJuegos);
                break;
            case '5':
                printf("\nGracias por utilizar el sistema.\n");
                break;
            default:
                printf("\nOpción incorrecta.");
                system("pause");
        }
    }while (opcion != '5');
    return 0;
}
