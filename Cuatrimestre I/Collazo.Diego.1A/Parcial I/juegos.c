#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

#include "utn.h"
#include "juegos.h"
/** \brief Carga una nueva estructura recibiendo el indice donde va a ser cargado
 *
 * \param eJuego *misJuegos
 * \param int largoJuego
 * \param int indice
 * \return Devuelve 0
 *
 */
int nuevoJuego(eJuego *misJuegos, int largoJuego, int indice){
    eJuego myAuxiliar;
    int r, retorno, codigoJuego;
    char descripcion[51];
    char juegoImporteChar[20];
    float importeJuego;
    system("cls");
    printf("*** Alta de juego ***\n");
    do{
        fflush(stdin);
        printf("\nIngrese el nombre del juego: ");
        fgets(descripcion, LARGO-2, stdin);
        quitarSaltoDeLinea(descripcion);
        corregirNombreCompuesto(descripcion);
        r = areCharacters(descripcion);
    }while (r == 0);
    do{
        printf("\nIngrese el importe: ");
        scanf("%s",juegoImporteChar);
        r = isFloat(juegoImporteChar);
        importeJuego = atof(juegoImporteChar);
        if (importeJuego <= 0){
            r = 0;
        }
    }while (r == 0);
    codigoJuego = nuevoIdJuego();
    myAuxiliar.codigoJuego = codigoJuego;
    strcpy(myAuxiliar.descripcion, descripcion);
    myAuxiliar.importeJuego = importeJuego;
    myAuxiliar.isEmpty = 0;
    misJuegos[indice] = myAuxiliar;
    retorno = 0;
    printf("\nJuego cargado con exito.\n\n");
    return retorno;
}
/** \brief Busca indice para nueva carga
 *
 * \param eJuego *misJuegos
 * \param int largoJuego
 * \return Devuelve el indice o -1 si no hay lugar
 *
 */
int posicionLibreJuego(eJuego *misJuegos, int largoJuego){
    int i, retorno = -1;
    for (i=0; i<largoJuego; i++){
        if (misJuegos[i].isEmpty){
            retorno = i;
            break;
        }
    }
    return retorno;
}
/** \brief Genera el proximo id
 *
 * \return Devuelve el proximo id (incremental)
 *
 */
int nuevoIdJuego(void){
    static int nextIdJuego = 0;
    nextIdJuego++;
    return nextIdJuego;
}
/** \brief Listado del array de estructuras
 *
 * \param eJuego *misJuegos
 * \param int largoJuego
 * \return Devuelve 0
 *
 */
int listarJuegos(eJuego *misJuegos, int largoJuegos){
    int i;
    system("cls");
    printf("*** Lista de juegos ***\n");
    printf("\nCodigo\tDescripcion\t\tImporte\n\n");
    for (i=0; i<largoJuegos; i++){
        if (misJuegos[i].isEmpty == 0){
            listarJuego(misJuegos[i]);
        }
    }
    printf("\n");
    return 0;
}
/** \brief Lista una fila del array de estructuras
 *
 * \param eJuego juegos
 * \return Devuelve 0
 *
 */
int listarJuego(eJuego juego){
    printf("%d\t%s\t\t$ %.2f\n",juego.codigoJuego,juego.descripcion,juego.importeJuego);
    return 0;
}
/** \brief Busqueda en el array de estructuras por Id
 *
 * \param eJuego *misJuegos
 * \param int largoJuego
 * \param int codigoJuego
 * \return Devuelve indice si encuentra o -1 si no.
 *
 */
int buscarJuego(eJuego *misJuegos, int largoJuegos, int codigoJuego){
    int indice, retorno = -1;
    for (indice=0; indice<largoJuegos; indice++){
        if (misJuegos[indice].isEmpty == 0 && misJuegos[indice].codigoJuego == codigoJuego){
            retorno = indice;
            break;
        }
    }
    return retorno;
}
/** \brief Modifica una fila del array de estructuras
 *
 * \param eJuego *misJuegos
 * \param int largoJuego
 * \return Devuelve 0
 *
 */
int modificarJuego(eJuego *misJuegos, int largoJuegos){
    int r, i, id, subOpcion;
    char descripcion[51];
    char juegoImporteChar[20];
    float importeJuego;
    fflush(stdin);
    printf("\nIngrese el codigo: ");
    scanf("%d",&id);
    i = buscarJuego(misJuegos, largoJuegos, id); //Devuelve el i del Id buscado
    if (i == -1){
        printf("\nNo existe el codigo.\n\n");
    }
    else{
        int flag = 0;
        system("cls");
        printf("*** Modificar juego  ***\n");
        printf("\n1- Modificar descripcion [%s].\n",misJuegos[i].descripcion);
        printf("\n2- Modificar importe [%.2f].\n",misJuegos[i].importeJuego);
        printf("\n3- Volver al menu principal.\n");
        printf("\nElija una opcion: ");
        scanf("%d",&subOpcion);
        switch(subOpcion)
        {
            case 1:
                do{
                    fflush(stdin);
                    printf("\nIngrese el NUEVO nombre del juego: ");
                    fgets(descripcion, LARGO-2, stdin);
                    quitarSaltoDeLinea(descripcion);
                    corregirNombreCompuesto(descripcion);
                    r = areCharacters(descripcion);
                }while (r == 0);
                strcpy(misJuegos[i].descripcion, descripcion);
                flag = 1;
                break;
            case 2:
                do{
                    printf("\nIngrese el NUEVO importe: ");
                    scanf("%s",juegoImporteChar);
                    r = isFloat(juegoImporteChar);
                    importeJuego = atof(juegoImporteChar);
                    if (importeJuego <= 0){
                        r = 0;
                    }
                }while (r == 0);
                misJuegos[i].importeJuego = importeJuego;
                flag = 1;
                break;
            case 3:
                break;
            default:
                printf("\nOpcion incorrecta.");
                break;
        }
        if (flag)
            printf("\nModificacion exitosa.\n\n");
    }
    return 0;
}
/** \brief Borra una fila del array de estructuras
 *
 * \param eJuego *misJuegos
 * \param int largoJuegos
 * \return Devuelve 0
 *
 */
int borrarJuego(eJuego *misJuegos, int largoJuegos){
    int i, id;
    char respuesta;
    printf("\nIngrese el codigo: ");
    scanf("%d",&id); //Comprobar que sea un entero
    i = buscarJuego(misJuegos, largoJuegos, id); //Devuelve el i del Id buscado
    if (i == -1){
        printf("\nNo existe el codigo.\n");
    }
    else{
        //system("cls");
        printf("\nCodigo\tDescripcion\t\tImporte\n\n");
        listarJuego(misJuegos[i]);
        printf("\nDesea borrar el juego? S/N: ");
        fflush(stdin);
        scanf("%c",&respuesta);
        if (respuesta == 's' || respuesta == 'S'){
            misJuegos[i].isEmpty = 1;
            printf("\nJuego borrado.\n\n");
        }
        else{
            printf("\nBorrado cancelado.\n\n");
        }
    }
    return 0;
}
/** \brief Inicia el campo isEmpty array de estructuras con 1
 *
 * \param eJuego *misJuegos
 * \param int largoJuego
 * \return Devuelve 0
 *
 */
int inicializarJuegos(eJuego *misJuegos, int largoJuegos){
    int i, retorno = -1;
    if (misJuegos != NULL && largoJuegos != 0){
        retorno = 0;
        for (i=0; i<largoJuegos; i++){
            misJuegos[i].isEmpty = 1;
        }
    }
    return retorno;
}
/** \brief Ordena array de estructuras con criterios solicitados
 *
 * \param eJuego *misJuegos
 * \param int largoJuego
 * \return Devuelve 0
 *
 */
int ordenarJuegos(eJuego *misJuegos, int largoJuegos){
    int i, j;
    eJuego auxJuego;
    for (i=0; i<largoJuegos-1; i++){
        for (j=0+i; j<largoJuegos; j++){
            if (misJuegos[i].isEmpty == 0 && misJuegos[j].isEmpty == 0){
                if (misJuegos[i].importeJuego <  misJuegos[j].importeJuego){
                    auxJuego = misJuegos[i];
                    misJuegos[i] = misJuegos[j];
                    misJuegos[j] = auxJuego;
                }
                else if (misJuegos[i].importeJuego ==  misJuegos[j].importeJuego){
                    if (strcmp(misJuegos[i].descripcion,misJuegos[j].descripcion) > 0){
                        auxJuego = misJuegos[i];
                        misJuegos[i] = misJuegos[j];
                        misJuegos[j] = auxJuego;
                    }
                }
            }
        }
    }
    return 0;
}
