#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

#include "utn.h"
#include "clientes.h"
/** \brief Carga una nueva estructura recibiendo el indice donde va a ser cargado
 *
 * \param eCliente *list
 * \param int largoCliente
 * \param int indice
 * \return Devuelve 0
 *
 */
int nuevoCliente(eCliente *list, int largoCliente, int indice){
    eCliente myAuxiliar;
    char apellido[LARGO];
    char domicilio[LARGO];
    char nombre[LARGO];
    char sexo;
    int r, codigoCliente;
    system("cls");
    printf("*** Alta de Cliente ***\n");
    do{
        fflush(stdin);
        printf("\nIngrese el nombre del cliente: ");
        fgets(nombre, LARGO-2, stdin);
        quitarSaltoDeLinea(nombre);
        corregirNombreCompuesto(nombre);
        r = areCharacters(nombre);
    }while (r == 0);
    do{
        fflush(stdin);
        printf("\nIngrese el apellido del cliente: ");
        fgets(apellido, LARGO-2, stdin);
        quitarSaltoDeLinea(apellido);
        corregirNombreCompuesto(apellido);
        r = areCharacters(apellido);
    }while (r == 0);

    do{
        fflush(stdin);
        printf("\nIngrese el domicilio del cliente: ");
        fgets(domicilio, LARGO-2, stdin);
        quitarSaltoDeLinea(domicilio);
        corregirNombreCompuesto(domicilio);
        r = isAlphaNumeric(domicilio);
    }while (r == 0);
    do{
        printf("\nIngrese el sexo: ");
        scanf("%c",&sexo);
        r = isCharacter(sexo);
    }while (r == 0);
    codigoCliente = nuevoIdCliente();
    myAuxiliar.codigoCliente = codigoCliente;
    strcpy(myAuxiliar.nombre, nombre);
    strcpy(myAuxiliar.apellido, apellido);
    strcpy(myAuxiliar.domicilio, domicilio);
    myAuxiliar.sexo = sexo;
    myAuxiliar.isEmpty = 0;
/** \brief Ordena array de estructuras con criterios solicitados
 *
 * \param eJuego *misJuegos
 * \param int largoJuego
 * \return Devuelve 0
 *
 */
    return 0;
}
/** \brief Busca indice para nueva carga
 *
 * \param eCliente *list
 * \param int largoCliente
 * \return Devuelve el indice o -1 si no hay lugar
 *
 */
int posicionLibreCliente(eCliente *list, int largoCliente){
    int i, retorno = -1;
    for (i=0; i<largoCliente; i++){
        if (list[i].isEmpty){
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
int nuevoIdCliente(void){
    static int nextIdCliente = 0;
    nextIdCliente++;
    return nextIdCliente;
}
/** \brief Listado del array de estructuras
 *
 * \param eCliente *list
 * \param int largoCliente
 * \return Devuelve 0
 *
 */
int listarClientes(eCliente *list, int largoClientes){
    int i;
    system("cls");
    printf("*** Lista de Clientes ***\n");
    printf("\nCodigo\tApellido\tNombre\tSexo\tDomicilio\n\n");
    for (i=0; i<largoClientes; i++){
        if (list[i].isEmpty == 0){
            listarCliente(list[i]);
        }
    }
    printf("\n");
    return 0;
}
/** \brief Lista una fila del array de estructuras
 *
 * \param eeCliente *list
 * \return Devuelve 0
 *
 */
int listarCliente(eCliente cliente){
    printf("%d\t%s\t\t%s\t%c\t\%s\n",cliente.codigoCliente, cliente.apellido, cliente.nombre, cliente.sexo, cliente.domicilio);
    return 0;
}
/** \brief Busqueda en el array de estructuras por Id
 *
 * \param eCliente *list
 * \param int largoClientes
 * \param int codigoCliente
 * \return Devuelve indice si encuentra o -1 si no.
 *
 */
int buscarCliente(eCliente *list, int largoClientes, int codigoCliente){
    int indice, retorno = -1;
    for (indice=0; indice<largoClientes; indice++){
        if (list[indice].isEmpty == 0 && list[indice].codigoCliente == codigoCliente){
            retorno = indice;
            break;
        }
    }
    return retorno;
}
/** \brief Modifica una fila del array de estructuras
 *
 * \param eCliente *list
 * \param int largoClientes
 * \return Devuelve 0
 *
 */
int modificarCliente(eCliente *list, int largoClientes){
    int r, i, id, subOpcion;
    char apellido[LARGO];
    char domicilio[LARGO];
    char nombre[LARGO];
    char sexo;
    printf("\nIngrese el codigo: ");
    scanf("%d",&id); //Comprobar que sea un entero
    i = buscarCliente(list, largoClientes, id); //Devuelve el i del Id buscado
    if (i == -1){
        printf("\nNo existe el codigo.\n\n");
    }
    else{
        int flag = 0;
        system("cls");
        printf("*** Modificar cliente  ***\n");
        printf("\n1- Modificar apellido [%s].\n",list[i].apellido);
        printf("\n2- Modificar nombre [%s].\n",list[i].nombre);
        printf("\n3- Modificar sexo [%c].\n",list[i].sexo);
        printf("\n4- Modificar domicilio [%s].\n",list[i].domicilio);
        printf("\n5- Volver al menu principal.\n");
        printf("\nElija una opcion: ");
        scanf("%d",&subOpcion);
        switch(subOpcion)
        {
            case 1:
                do{
                    fflush(stdin);
                    printf("\nIngrese el NUEVO apellido del cliente: ");
                    fgets(apellido, LARGO-2, stdin);
                    quitarSaltoDeLinea(apellido);
                    corregirNombreCompuesto(apellido);
                    r = areCharacters(apellido);
                }while (r == 0);
                strcpy(list[i].apellido, apellido);
                flag = 1;
                break;
            case 2:
                do{
                    fflush(stdin);
                    printf("\nIngrese el NUEVO nombre del cliente: ");
                    fgets(nombre, LARGO-2, stdin);
                    quitarSaltoDeLinea(nombre);
                    corregirNombreCompuesto(nombre);
                    r = areCharacters(nombre);
                }while (r == 0);
                strcpy(list[i].nombre, nombre);
                flag = 1;
                break;
            case 3:
                do{
                    printf("\nIngrese el NUEVO sexo: ");
                    scanf("%c",&sexo);
                    r = isCharacter(sexo);
                }while (r == 0);
                list[i].sexo = sexo;
                flag = 1;
            case 4:
                do{
                    fflush(stdin);
                    printf("\nIngrese el NUEVO domicilio del cliente: ");
                    fgets(domicilio, LARGO-2, stdin);
                    quitarSaltoDeLinea(domicilio);
                    corregirNombreCompuesto(domicilio);
                    r = isAlphaNumeric(domicilio);
                }while (r == 0);
                strcpy(list[i].domicilio, domicilio);
                flag = 1;
            case 5:
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
 * \param eCliente *list
 * \param int largoClientes
 * \return Devuelve 0
 *
 */
int borrarCliente(eCliente *list, int largoClientes){
    int i, id;
    char respuesta;
    printf("\nIngrese el codigo: ");
    scanf("%d",&id); //Comprobar que sea un entero
    i = buscarCliente(list, largoClientes, id); //Devuelve el i del Id buscado
    if (i == -1){
        printf("\nNo existe el codigo.\n");
    }
    else{
        system("cls");
        printf("\nCodigo\tApellido\tNombre\tSexo\tDomicilio\n\n");
        listarCliente(list[i]);
        printf("\nDesea borrar el cliente? S/N: ");
        fflush(stdin);
        scanf("%c",&respuesta);
        if (respuesta == 's' || respuesta == 'S'){
            list[i].isEmpty = 1;
            printf("\nCliente borrado.\n\n");
        }
        else{
            printf("\nBorrado cancelado.\n\n");
        }
    }
    return 0;
}
/** \brief Inicia el campo isEmpty array de estructuras con 1
 *
 * \param eCliente *list
 * \param int largoClientes
 * \return Devuelve 0
 *
 */
int inicializarClientes(eCliente *pClientes, int largoClientes){
    int i, retorno = -1;
    if (pClientes != NULL && largoClientes != 0){
        retorno = 0;
        for (i=0; i<largoClientes; i++){
            pClientes[i].isEmpty = 1;
        }
    }
    return retorno;
}
/** \brief Ordena array de estructuras con criterios solicitados
 *
 * \param eCliente *list
 * \param int largoClientes
 * \param int codigoCliente
 * \return Devuelve 0
 *
 */
int ordenarClientes(eCliente *misClientes, int largoClientes){
    int i, j;
    eCliente auxCliente;
    for (i=0; i<largoClientes-1; i++){
        for (j=0+i; j<largoClientes; j++){
            if (misClientes[i].isEmpty == 0 && misClientes[j].isEmpty == 0){
                if (strcmp(misClientes[i].apellido,misClientes[j].apellido) > 0){
                    auxCliente = misClientes[i];
                    misClientes[i] = misClientes[j];
                    misClientes[j] = auxCliente;
                }
                else if (strcmp(misClientes[i].apellido,misClientes[j].apellido) == 0){
                    if (strcmp(misClientes[i].nombre,misClientes[j].nombre) > 0){
                        auxCliente = misClientes[i];
                        misClientes[i] = misClientes[j];
                        misClientes[j] = auxCliente;
                    }
                }
            }
        }
    }
    return 0;
}
