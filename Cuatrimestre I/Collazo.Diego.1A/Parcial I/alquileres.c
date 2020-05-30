#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

#include "utn.h"

#include "alquileres.h"
#include "clientes.h"
#include "juegos.h"

void listarAlquiler(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes){
    int i, j, k;
    system("cls");
    printf("*** Lista de alquileres ***\n\n");
    printf("Alquiler Id\tNombre\tApellido\tSexo Juego\t\tImporte\tFecha\n\n");
    for (i=0; i<largoAlquileres; i++){
        if (pAlquileres[i].isEmpty == 0){
            for (j=0; j<largoClientes; j++){
                if (pAlquileres[i].codigoCliente == pClientes[j].codigoCliente && pClientes[j].isEmpty == 0){
                    for (k=0; k<largoJuegos; k++){
                        if (pAlquileres[i].codigoJuego == pJuegos[k].codigoJuego && pJuegos[k].isEmpty == 0){
                            printf("%d\t%d\t%s\t%s\t%c %s\t$ %2.f\t%d.%d.%d\n",
                                pAlquileres[i].codigoAlquiler,
                                pAlquileres[i].codigoCliente,
                                pClientes[j].nombre,
                                pClientes[j].apellido,
                                pClientes[j].sexo,
                                pJuegos[k].descripcion,
                                pJuegos[k].importeJuego,
                                pAlquileres[i].fechaAlquiler.day,
                                pAlquileres[i].fechaAlquiler.month,
                                pAlquileres[i].fechaAlquiler.year
                                );
                        }
                    }
                }
            }
        }
    }
    printf("\n");
    system("pause");
}

int nuevoAlquilerJuego(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes, int indiceAlquiler){
    int r, indice[2], retorno = 0, codigoAlquiler, codigoJuego , codigoCliente, day, month, year;
    char opcion;
    eAlquileres myAuxiliarAlquiler;
    do{
        listarClientes(pClientes, largoClientes);
        fflush(stdin);
        printf("\nSeleccione el cliente: ");
        scanf("%d",&codigoCliente);
        indice[0] = buscarCliente(pClientes, largoClientes, codigoCliente);
    }while (indice[0] == -1);
    do{
        listarJuegos(pJuegos, largoJuegos);
        fflush(stdin);
        printf("\nSeleccione el juego: ");
        scanf("%d",&codigoJuego);
    indice[1] = buscarJuego(pJuegos, largoJuegos, codigoJuego);
    }while (indice[1] == -1);
    system("cls");
    printf("*** Nuevo alquiler ***\n");
    do{
        fflush(stdin);
        printf("\nIngrese la fecha:\n");
        printf( "\nIntroduzca d%ca: ", 161 );
        scanf( "%d", &day );
        printf( "\nIntroduzca mes: " );
        scanf( "%d", &month );
        printf( "\nIntroduzca a%co: ", 164 );
        scanf( "%d", &year );
        r = isFecha(day, month, year);
    }while (r == 0);
    fflush(stdin);
    printf("\nCliente\tNombre\t\tApellido\tJuego\t\t\tImporte\n");
    printf("\n%d\t%s\t\t%s\t\t%s\t\t$ %.2f",pClientes[indice[0]].codigoCliente,pClientes[indice[0]].nombre,pClientes[indice[0]].apellido,pJuegos[indice[1]].descripcion,pJuegos[indice[1]].importeJuego);
    printf("\n\n%cConfirma el aquiler? S/N: ", 168);
    scanf("%c",&opcion);
    strlwr(&opcion);
    if ((opcion = 's')){
        codigoAlquiler = nuevoCodigoAlquiler();
        myAuxiliarAlquiler.codigoAlquiler = codigoAlquiler;
        myAuxiliarAlquiler.codigoCliente = codigoCliente;
        myAuxiliarAlquiler.codigoJuego = codigoJuego;
        myAuxiliarAlquiler.fechaAlquiler.day = day;
        myAuxiliarAlquiler.fechaAlquiler.month = month;
        myAuxiliarAlquiler.fechaAlquiler.year = year;
        myAuxiliarAlquiler.isEmpty = 0;
        pAlquileres[indiceAlquiler] = myAuxiliarAlquiler;
        printf("\nAlquiler confirmado.\n\n");
    }
    system("pause");
    return retorno;
}

int nuevoCodigoAlquiler(void){
    static int nuevoIdAlquiler = 0;
    nuevoIdAlquiler++;
    return nuevoIdAlquiler;
}

int posicionLibreAlquiler(eAlquileres *pAlquileres, int largoAlquileres){
    int indice, retorno = -1;
    for (indice=0; indice<largoAlquileres; indice++){
        if (pAlquileres[indice].isEmpty){
            retorno = indice;
            break;
        }
    }
    return retorno;
}

int inicializarAlquileres(eAlquileres *pAlquileres, int largoAlquileres){
    int i, retorno = -1;
    if (pAlquileres != NULL && largoAlquileres != 0){
        retorno = 0;
        for (i=0; i<largoAlquileres; i++){
            pAlquileres[i].isEmpty = 1;
        }
    }
    return retorno;
}
