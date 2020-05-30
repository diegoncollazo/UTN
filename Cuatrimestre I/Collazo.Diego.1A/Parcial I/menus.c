#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

#include "utn.h"
#include "alquileres.h"
#include "juegos.h"
#include "clientes.h"
#include "menus.h"
#include "informes.h"

void menuInformes(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes, int hayClientes, int hayJuegos){
    char opcion;
        do{
        fflush(stdin);
        system("cls");
        printf("*** Menu Informes ***\n");
        printf("\na) Promedio y total de importes de los juegos alquilados.\n");
        printf("\nb) Cantidad de juegos cuyo importe no superan el promedio del item anterior.\n");
        printf("\nc) Listar clientes por juego determinado.\n");
        printf("\nd) Listar juegos por cliente determinado.\n");
        printf("\ne) Listar juego menos alquilado.\n");
        printf("\nf) Listar clientes con mas alquileres.\n");
        printf("\ng) Listar juegos por fecha.\n");
        printf("\nh) Listar clientes por fecha determinada.\n");
        printf("\ni) Listar juegos por burbujeo.\n");
        printf("\nj) Listar clientes por insercion.\n");
        printf("\nk) Volver al Menu principal.\n");
        printf("\nElija una opcion: ");
        scanf("%c",&opcion);
        switch(opcion){
            case 'a':
                promedioTotal(pAlquileres, largoAlquileres, pJuegos, largoJuegos, pClientes, largoClientes);
                break;
            case 'b':
                juegosNoSuperenPromedio(pAlquileres, largoAlquileres, pJuegos, largoJuegos, pClientes, largoClientes);
                break;
            case 'c':
                listarClientesPorJuego(pAlquileres, largoAlquileres, pJuegos, largoJuegos, pClientes, largoClientes);
                break;
            case 'd':
                listarJuegosPorCliente(pAlquileres, largoAlquileres, pJuegos, largoJuegos, pClientes, largoClientes);
                break;
            case 'e':
                listarJuegoMenosAlquilado(pAlquileres, largoAlquileres, pJuegos, largoJuegos);
                break;
            case 'f':
                listarClientesConMasAlquileres(pAlquileres, largoAlquileres, pClientes, largoClientes);
                break;
            case 'g':
                listarJuegosPorFecha(pAlquileres, largoAlquileres, pJuegos, largoJuegos, pClientes, largoClientes);
                break;
            case 'h':
                listarClientesPorFecha(pAlquileres, largoAlquileres, pJuegos, largoJuegos, pClientes, largoClientes);
                break;
            case 'i':
                listarJuegoPorBurbujeo(pJuegos, largoJuegos);
                break;
            case 'j':
                ordenarClientesPorInsercion(pClientes, largoClientes);
                break;
            case 'k':
                break;
            default:
                printf("\nOpción incorrecta.");
                system("pause");
        }
    }while (opcion != 'k');
}

void menuJuegos(eJuego *pJuegos, int largoJuego, int *hayJuegos){
    int i;
    char opcion;
        do{
        fflush(stdin);
        system("cls");
        printf("*** Menu Juegos ***\n");
        printf("\n1- Alta de juego.\n");
        printf("\n2- Modificar juego.\n");
        printf("\n3- Baja de juego.\n");
        printf("\n4- Lista de juegos.\n");
        printf("\n5- Volver al Menu principal.\n");
        printf("\nElija una opcion: ");
        scanf("%c",&opcion);
        switch(opcion){
            case '1':
                i = posicionLibreJuego(pJuegos, CANT_JUEGOS);
                if (i == -1){
                    printf("\nNo hay lugar para cargar juegos");
                    system("pause");
                    break;
                }
                else{
                    nuevoJuego(pJuegos, CANT_JUEGOS, i);
                    system("pause");
                }
                break;
            case '2':
                modificarJuego(pJuegos, CANT_JUEGOS);
                system("pause");
                break;
            case '3':
                borrarJuego(pJuegos, CANT_JUEGOS);
                system("pause");
                break;
            case '4':
                //ordenarJuegos(pJuegos, CANT_JUEGOS);
                listarJuegos(pJuegos, CANT_JUEGOS);
                system("pause");
                break;
            case '5':
                break;
            default:
                printf("\nOpción incorrecta.");
                system("pause");
        }
    }while (opcion != '5');
}

void menuClientes(eCliente *pClientes, int largoCliente, int *hayClientes){
    int i;
    char opcion;
    do{
        fflush(stdin);
        system("cls");
        printf("*** Menu Clientes ***\n");
        printf("\n1- Alta de cliente.\n");
        printf("\n2- Modificar cliente.\n");
        printf("\n3- Baja de cliente.\n");
        printf("\n4- Lista de clientes.\n");
        printf("\n5- Volver al Menu principal.\n");
        printf("\nElija una opcion: ");
        scanf("%c",&opcion);
        switch(opcion){
            case '1':
                i = posicionLibreCliente(pClientes, CANT_CLIENTES);
                if (i == -1){
                    printf("\nNo hay lugar para cargar clientes");
                    system("pause");
                    break;
                }
                else{
                    nuevoCliente(pClientes, CANT_CLIENTES, i);
                    system("pause");
                }
                break;
            case '2':
                if (hayClientes > 0){
                    modificarCliente(pClientes, CANT_CLIENTES);
                    system("pause");
                }
                break;
            case '3':
                if (hayClientes > 0){
                    borrarCliente(pClientes, CANT_CLIENTES);
                    system("pause");
                }
                break;
            case '4':
                if (hayClientes > 0){
                    //ordenarClientes(pClientes, CANT_CLIENTES);
                    listarClientes(pClientes, CANT_CLIENTES);
                    system("pause");
                }
                break;
            case '5':
                break;
            default:
                printf("\nOpción incorrecta.");
                system("pause");
                break;
        }
    }while (opcion != '5');
}

void menuAlquileres(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes, int hayClientes, int hayJuegos){
    int indiceAlquiler;
    char opcion;
        do{
        fflush(stdin);
        system("cls");
        printf("*** Menu Alquileres ***\n");
        printf("\n1- Nuevo de alquiler de juego.\n");
        printf("\n2- Lista de alquileres.\n");
        printf("\n3- Volver al Menu principal.\n");
        printf("\nElija una opcion: ");
        scanf("%c",&opcion);
        switch(opcion){
            case '1':
                indiceAlquiler = posicionLibreAlquiler(pAlquileres, CANT_ALQUILERES);
                if (!hayClientes || !hayJuegos){
                    printf("\nNo se pueden generar alquileres sin juegos y/o clientes.\n\n");
                    system("pause");
                    break;
                }
                else{
                    if (indiceAlquiler == -1){
                        printf("\nNo hay lugar para cargar clientes");
                        system("pause");
                        break;
                    }
                    else{
                        nuevoAlquilerJuego(pAlquileres, largoAlquileres, pJuegos, largoJuegos, pClientes, largoClientes, indiceAlquiler);
                    }
                }
                break;
            case '2':
                listarAlquiler(pAlquileres, largoAlquileres, pJuegos, largoJuegos, pClientes, largoClientes);
                break;
            case '3':


                break;
            default:
                printf("\nOpción incorrecta.");
                system("pause");
        }
    }while (opcion != '3');
}

void hardCodingData(eAlquileres *pAlquileres, eJuego *pJuegos, eCliente *pClientes){
    int i;
    eAlquileres alquiler[] = {
    {30, 10 , 20, {10, 10, 2018}, 0},
    {31, 10 , 22, {10, 5, 2018}, 0},
    {32, 10 , 25, {10, 3, 2018}, 0},
    {33, 13 , 27, {10, 4, 2018}, 0},
    {34, 13 , 27, {10, 10, 2018}, 0},
    {35, 17 , 22, {10, 12, 2018}, 0},
    {36, 17 , 24, {10, 9, 2018}, 0},
    {37, 17 , 28, {10, 10, 2018}, 0},
    {38, 17 , 21, {10, 12, 2018}, 0},
    {39, 19 , 27, {10, 9, 2018}, 0},
    };
    eJuego juego[] = {
    {10, "FIFA 2018", 1000 ,0},
    {11, "PES 2019", 900, 0},
    {12, "God of War", 100, 0},
    {13, "Gran Turismo", 200, 0},
    {14, "Metal Slug", 500, 0},
    {15, "Mario Bross", 100, 0},
    {16, "Counter Strike", 150, 0},
    {17, "Warcraft III", 800, 0},
    {18, "Starcraft II", 900, 0},
    {19, "Tomb Raider", 350, 0},
    };
    eCliente cliente[] = {
    {20, "Juan", "Lopez", "Calle 1 245", 'm', 0},
    {21, "Diego", "Siri", "Calle 2 245", 'm', 0},
    {22, "Vanesa", "Silva", "Calle 3 245", 'f', 0},
    {23, "Lorena", "Lopez", "Calle 4 245", 'f', 0},
    {24, "Lucia", "Belen", "Calle 5 245", 'f', 0},
    {25, "Juana", "Caputo", "Calle 6 245", 'f', 0},
    {26, "Macri", "Gato", "Calle 7 245", 'm', 0},
    {27, "Jose", "Lamula", "Calle 8 245", 'm', 0},
    {28, "Ester", "Lamula", "Calle 19 245", 'f', 0},
    {29, "Ana", "Lamula", "Calle 10 245", 'f', 0},
    };
    for (i=0; i<10; i++){
        pJuegos[i] = juego[i];
        pClientes[i] = cliente[i];
        pAlquileres[i] = alquiler[i];
    }
}

int sinClientes(eCliente *pClientes, int largoClientes){
    int i, retorno = 0;
    for (i=0; i<largoClientes; i++){
        if (pClientes[i].isEmpty == 0){
            retorno = 1;
            break;
        }
    }
    return retorno;
}

int sinJuegos(eJuego *pJuegos, int largoJuegos){
    int i, retorno = 0;
    for (i=0; i<largoJuegos; i++){
        if (pJuegos[i].isEmpty == 0){
            retorno = 1;
            break;
        }
    }
    return retorno;
}
