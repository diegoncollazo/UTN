#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include "utn.h"
#include "alquileres.h"
#include "clientes.h"
#include "juegos.h"
#include "informes.h"
/**< Acumulador & Contador */
int promedioImportes(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes, float *pPromedio, float *pAcumulador, int *pContador){
    int i, j, k, retorno = 0;
    *pContador = 0;
    *pPromedio = 0;
    *pAcumulador = 0;
    for (i=0; i<largoAlquileres; i++){
        if (pAlquileres[i].isEmpty == 0){
            for (j=0; j<largoClientes; j++){
                if (pAlquileres[i].codigoCliente == pClientes[j].codigoCliente ){
                    //No valido xq el alquiler puede existir pero el ciente puede estar dado de baja
                    //&& pClientes[j].isEmpty == 0
                    for (k=0; k<largoJuegos; k++){
                        if (pAlquileres[i].codigoJuego == pJuegos[k].codigoJuego){
                            //&& pJuegos[k].isEmpty == 0
                            //No valido xq el alquiler puede existir pero el juego puede estar dado de baja
                            *pAcumulador = *pAcumulador + pJuegos[k].importeJuego;
                            *pContador = *pContador + 1;
                        }
                    }
                }
            }
        }
    }
    if (*pContador != 0){
        *pPromedio = (float) (*pAcumulador / *pContador);
        retorno = 1;
    }
    system("cls");
    return retorno;
}
/**< Punto A */
void promedioTotal(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes){
    float promedio, acumulador;
    int contador, r;
    r = promedioImportes(pAlquileres, largoAlquileres, pJuegos, largoJuegos, pClientes, largoClientes, &promedio, &acumulador, &contador);
    if (r){
        printf("El total de alquileres [%i] es de $%.2f.\n",contador,acumulador);
        printf("\nEl promedio es $%.2f.\n\n",promedio);
    }
    else{
        printf("No se pudo realizar la operacion.\n");
    }
    system("pause");
}
/**< Punto B */
void juegosNoSuperenPromedio(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes){
    float promedio, acumulador;
    int contador, contadorInferior = 0, r, i;
    r = promedioImportes(pAlquileres, largoAlquileres, pJuegos, largoJuegos, pClientes, largoClientes, &promedio, &acumulador, &contador);
    if (r){
        printf("Codigo\tDescripcion\t\tImporte\n\n");
        for (i=0; i<largoJuegos; i++){
            if (!pJuegos[i].isEmpty && pJuegos[i].importeJuego < promedio){
                listarJuego(pJuegos[i]);
                contadorInferior++;
            }
        }
        printf("\nCantidad de juegos [%d] inferiores al promedio de [$%.2f].\n\n",contadorInferior,promedio);
    }
    else{
        printf("No se pudo realizar la operacion.\n");
    }
    system("pause");
}
/**< Punto C */
void listarClientesPorJuego(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes){
    int i, j, codigoJuego, flag = 1;
    fflush(stdin);
    listarJuegos(pJuegos, largoJuegos);
    printf("Ingrese el codigo: ");
    scanf("%d",&codigoJuego);
    system("cls");
    int indiceJuego = buscarJuego(pJuegos, largoJuegos, codigoJuego);
    if (indiceJuego == -1){
        printf("Juego inexistente.\n\n");
    }
    else{//Clientes que alquilaron el juego.
        printf("El juego seleccionado es %s y los clientes que lo alquilaron son:\n",pJuegos[indiceJuego].descripcion);
        printf("\nCodigo\tApellido\tNombre\tSexo\tDomicilio\n\n");
        for (i=0; i<largoAlquileres; i++){
            if (pAlquileres[i].isEmpty == 0){
                if (codigoJuego == pAlquileres[i].codigoJuego){
                    for (j=0; j<largoClientes; j++){
                        if (pAlquileres[i].codigoCliente == pClientes[j].codigoCliente){
                                listarCliente(pClientes[j]);
                                flag = 0;
                        }
                    }
                }
            }
        }
    }
    if (flag)
        printf("El juego seleccionado no ha sido alquilado.\n");
    printf("\n");
    system("pause");
}
/**< Punto D */
void listarJuegosPorCliente(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes){
    int i, j, codigoCliente, flag = 1;
    fflush(stdin);
    listarClientes(pClientes, largoClientes);
    printf("\nIngrese el codigo: ");
    scanf("%d",&codigoCliente);
    system("cls");
    int indiceCliente = buscarCliente(pClientes, largoClientes, codigoCliente);
    if (indiceCliente == -1){
        printf("Cliente inexistente.\n\n");
    }
    else{//Juego que alquilaron los clientes.
        printf("El cliente es %s %s y los juegos que alquilo son:\n",pClientes[indiceCliente].nombre,pClientes[indiceCliente].apellido);
        printf("\nCodigo\tDescripcion\t\tImporte\n\n");
        for (i=0; i<largoAlquileres; i++){
            if (pAlquileres[i].isEmpty == 0){
                if (codigoCliente == pAlquileres[i].codigoCliente){
                    for (j=0; j<largoJuegos; j++){
                        if (pAlquileres[i].codigoJuego == pJuegos[j].codigoJuego){
                            listarJuego(pJuegos[j]);
                            flag = 0;
                        }
                    }
                }
            }
        }
    }
    if (flag)
        printf("El cliente no ha alquilado.\n");
    printf("\n");
    system("pause");
}
/**< Punto E */
void listarJuegoMenosAlquilado(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos){
    int i, j, acumulador = 0, bandera = 1, menor;
    //Busco la cantidad del juego menor alquilado
    for (i=0; i<largoJuegos; i++){
        if (!pJuegos[i].isEmpty){
            acumulador = 0;
            for (j=0; j<largoAlquileres; j++){
                if (pAlquileres[j].codigoJuego == pJuegos[i].codigoJuego && !pAlquileres[j].isEmpty)
                    acumulador++;
            }
            if (bandera){
                menor = acumulador;
                bandera = 0;
            }
            if (acumulador < menor)
                menor = acumulador;
        }
    }
    //Busco si hay uno o mas juegos menos alquilados.
    system("cls");
    printf("Juegos menos alquilados (veces [%d]).\n",menor);
    printf("\nID\tJuego\t\t\tPrecio\n\n");
    for (i=0; i<largoJuegos; i++){
        acumulador = 0;
        if (!pJuegos[i].isEmpty){
            for (j=0; j<largoAlquileres; j++){
                if (pAlquileres[j].codigoJuego == pJuegos[i].codigoJuego && !pAlquileres[j].isEmpty)
                    acumulador++;
            }
            if (acumulador == menor){
                listarJuego(pJuegos[i]);
            }
        }
    }
    printf("\n");
    system("pause");
}
/**< Punto F */
void listarClientesConMasAlquileres(eAlquileres *pAlquileres, int largoAlquileres, eCliente *pClientes, int largoClientes){
    int i, j, acumulador = 0, mayor, bandera = 1;
    for (i=0; i<largoClientes; i++){
        if (!pClientes[i].isEmpty){
            acumulador = 0;
            for (j=0; j<largoAlquileres; j++){
                if (pAlquileres[j].codigoCliente == pClientes[i].codigoCliente && !pAlquileres[j].isEmpty)
                    acumulador++;
            }
        }
        if (bandera){
            mayor = acumulador;
            bandera = 0;
        }
        if (acumulador > mayor)
            mayor = acumulador;
    }
    system("cls");
    if (mayor != 0){
        printf("Los clientes con mas alquileres (veces [%d]).\n",mayor);
        printf("\nID\tApellido\tNombre\tSexo\tDireccion\n\n");
        for (i=0; i<largoClientes; i++){
            if (!pClientes[i].isEmpty){
                acumulador = 0;
                for (j=0; j<largoAlquileres; j++){
                    if (pAlquileres[j].codigoCliente == pClientes[i].codigoCliente && !pAlquileres[j].isEmpty)
                        acumulador++;
                }
            }
            if (acumulador == mayor)
                listarCliente(pClientes[i]);
        }
    }
    else
        printf("No hay alquileres realizados.\n");
    printf("\n");
    system("pause");
}
/**< Punto G */
void listarJuegosPorFecha(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes){
    int i, j, r, day, month, year, bandera = 1;;
    system("cls");
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
    printf("\nID\tJuego\t\t\tPrecio\n\n");
    for (i=0; i<largoAlquileres; i++){
        if (pAlquileres[i].isEmpty == 0 && pAlquileres[i].fechaAlquiler.day == day && pAlquileres[i].fechaAlquiler.month == month && pAlquileres[i].fechaAlquiler.year == year){
            for (j=0; j<largoJuegos; j++){
                if (pAlquileres[i].codigoJuego == pJuegos[j].codigoJuego){
                    listarJuego(pJuegos[j]);
                    bandera = 0;
                }
            }
        }
    }
    if (bandera)
        printf("No se encontraron juegos alquilados en esa fecha.\n");
    printf("\n");
    system("pause");
}
/**< Punto H */
void listarClientesPorFecha(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes){
    int i, j, k, r, day, month, year, bandera = 1;
    system("cls");
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
    printf("\nAlquiler Nombre\tApellido\tJuego\tFecha\n\n");
    for (i=0; i<largoAlquileres; i++){
        if (pAlquileres[i].isEmpty == 0 && pAlquileres[i].fechaAlquiler.day == day && pAlquileres[i].fechaAlquiler.month == month && pAlquileres[i].fechaAlquiler.year == year){
            for (j=0; j<largoClientes; j++){
                if (pAlquileres[i].codigoCliente == pClientes[j].codigoCliente && pClientes[j].isEmpty == 0){
                    for (k=0; k<largoJuegos; k++){
                        if (pAlquileres[i].codigoJuego == pJuegos[k].codigoJuego){
                            printf("%d\t%s\t%s\t%s\t%d.%d.%d\n",
                                pAlquileres[i].codigoAlquiler,
                                pClientes[j].nombre,
                                pClientes[j].apellido,
                                pJuegos[k].descripcion,
                                pAlquileres[i].fechaAlquiler.day,
                                pAlquileres[i].fechaAlquiler.month,
                                pAlquileres[i].fechaAlquiler.year
                                );
                            bandera = 0;
                        }
                    }
                }
            }
        }
    }
    if (bandera)
        printf("No se encontraron alquileres en esa fecha.\n");
    printf("\n");
    system("pause");
}
/**< Punto I */
void listarJuegoPorBurbujeo(eJuego *pJuegos, int largoJuegos){
    eJuego miAuxiliar;
    int j, banderaOrdenado = 1;
    while(banderaOrdenado){
        banderaOrdenado = 0;
        for (j=1; j<largoJuegos;j++){
            if (pJuegos[j].importeJuego > pJuegos[j-1].importeJuego){
                miAuxiliar = pJuegos[j];
                pJuegos[j] = pJuegos[j-1];
                pJuegos[j-1] = miAuxiliar;
                banderaOrdenado = 1;
            }
        }
    }
    listarJuegos(pJuegos, largoJuegos);
    system("pause");
}
/**< Punto J */
void ordenarClientesPorInsercion(eCliente *pClientes, int largoClientes){
    eCliente miAuxiliar;
    int i, j;
    for (i=1; i < largoClientes; i++) {
        miAuxiliar = pClientes[i];
        j = i-1;
        while (strcmp(pClientes[j].apellido, miAuxiliar.apellido) > 0 && j>=0) {
            pClientes[j+1] = pClientes[j];
            j--;
        }
        pClientes[j+1] = miAuxiliar;
    }
    listarClientes(pClientes, largoClientes);
    system("pause");
}
