#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#include "employee.h"
#include "../Bibliotecas/utn.h"
#include "../Bibliotecas/collazo.h"

/** \brief To indicate that all position in the array are empty,
* this function put the flag (isEmpty) in TRUE in all
* position of the array
* \param list Employee* Pointer to array of employees
* \param len int Array length
* \return int Return (-1) if Error [Invalid length or NULL pointer] - (0) if Ok
*
*/
int initEmployees(Employee *list, int len){
    int i, retorno = -1;
    if (list != NULL && len != 0){
        retorno = 0;
        for (i=0; i<len; i++){
            list[i].isEmpty = 1;
            //list[i].id = 0;
        }
    }
    return retorno;
}
/** \brief add in a existing list of employees the values received as parameters
* in the first empty position
* \param list employee*
* \param len int
* \param id int
* \param name[] char
* \param lastName[] char
* \param salary float
* \param sector int
* \return int Return (-1) if Error [Invalid length or NULL pointer or without free space] - (0) if Ok
*
*/
int addEmployee(Employee *list, int len, int id, char name[], char lastName[], float salary, int sector){
    int retorno = -1, i = freePosition(list, ELEMENTS);
    Employee myAuxiliar;
    if (i != -1){
        myAuxiliar.id = id;
        strcpy(myAuxiliar.name, name);
        strcpy(myAuxiliar.lastName, lastName);
        myAuxiliar.salary = salary;
        myAuxiliar.sector = sector;
        myAuxiliar.isEmpty = 0;
        list[i] = myAuxiliar;
        retorno = 0;
    }
    return retorno;
}
/** \brief find an Employee by Id en returns the index position in array.
*
* \param list Employee*
* \param len int
* \param id int
* \return Return employee index position or (-1) if [Invalid length or NULL
pointer received or employee not found]
*
*/
int findEmployeeById(Employee* list, int len, int id){
    int i, retorno = -1;
    for (i=0; i<len; i++){
        if (list[i].isEmpty == 0 && list[i].id == id){
            retorno = i;
            break;
        }
    }
    return retorno;
}
/** \brief Remove a Employee by Id (put isEmpty Flag in 1)
*
* \param list Employee*
* \param len int
* \param id int
* \return int Return (-1) if Error [Invalid length or NULL pointer or if can't
find a employee] - (0) if Ok
*
*/
int removeEmployee(Employee* list, int len, int id){
    int i, retorno = -1;
    i = findEmployeeById(list, len, id);
    if (i != -1){
        list[i].isEmpty = 1;
        retorno = 0;
    }
    return retorno;
}
/** \brief Sort the elements in the array of employees, the argument order
indicate UP or DOWN order
*
* \param list Employee*
* \param len int
* \param order int [1] indicate UP - [0] indicate DOWN
* \return int Return (-1) if Error [Invalid length or NULL pointer] - (0) if Ok
*
*/
int sortEmployees(Employee* list, int len, int order){
    Employee myAuxiliar;
    int i, j;
    if (order == 1){
        for (i=0; i<len-1; i++){//Ascendente
            for (j=i+1; j<len; j++){
                if (list[i].isEmpty == 0){
                    if (strcmp(list[i].lastName,list[j].lastName) > 0){
                        myAuxiliar = list[i];
                        list[i] = list[j];
                        list[j] = myAuxiliar;
                    }else if (strcmp(list[i].lastName,list[j].lastName) == 0 && list[i].sector > list[j].sector){
                        myAuxiliar = list[i];
                        list[i] = list[j];
                        list[j] = myAuxiliar;
                    }
                }
            }
        }
    }else if (order == 2){//Descendente
        for (i=0; i<len-1; i++){
            for (j=i+1; j<len; j++){
                if (list[i].isEmpty == 0){
                    if (strcmp(list[i].lastName,list[j].lastName) < 0){
                        myAuxiliar = list[i];
                        list[i] = list[j];
                        list[j] = myAuxiliar;
                    }else if (strcmp(list[i].lastName,list[j].lastName) == 0 && list[i].sector < list[j].sector){
                        myAuxiliar = list[i];
                        list[i] = list[j];
                        list[j] = myAuxiliar;
                    }
                }
            }
        }
    }
    return 0;
}
/** \brief print the content of employees array
*
* \param list Employee*
* \param length int
* \return int
*
*/
int printEmployees(Employee *list, int len){
    int i;
    system("cls");
    printf("*** Lista de empleados ***\n");
    printf("\nID\tNombre\t\tApellido\tSalario\t\t\tSector\n\n");
    for (i=0; i<len; i++){
        if (list[i].isEmpty == 0){
            printEmployee(list[i]);
        }
    }
    printf("\n");
    return 0;
}
/** \brief print the content of one employee
*
* \param empleado Employee*
* \return int
*
*/
int printEmployee(Employee empleado){
    printf("%d\t%s\t\t%s\t\t%.2f\t\t%d\n",empleado.id,empleado.name,empleado.lastName,empleado.salary,empleado.sector);
    return 0;
}
/** \brief carga y valida los datos de un nuevo empleado
 *
* \param list Employee*
* \param length int
 * \return devuelve 0 sin error o -1 si no pudo cargar el empleado
 *
 */
int validateEmployee(Employee *list, int len){
    int r, id, retorno;
    char name[ANCHO], lastName[ANCHO], salary[ANCHO], sector[5];
    system("cls");
    printf("*** Alta de empleado ***\n");
    do{
        fflush(stdin);
        printf("\nIngrese el nombre: ");
        fgets(name, ANCHO-2, stdin);
        quitarSaltoDeLinea(name);
        corregirNombreCompuesto(name);
        r = areCharacters(name);
    }while (r == 0);
    do{
        fflush(stdin);
        printf("\nIngrese el apellido: ");
        fgets(lastName, ANCHO-2, stdin);
        quitarSaltoDeLinea(lastName);
        corregirNombreCompuesto(lastName);
        r = areCharacters(lastName);
    }while (r == 0);
    do{
        printf("\nIngrese el salario: ");
        scanf("%s",salary);
        r = isFloat(salary);
    }while (r == 0);
    do{
        printf("\nIngrese el sector: ");
        scanf("%s",sector);
        r = isInteger(sector);
    }while (r == 0);
    id = newId();
    retorno = addEmployee(list, len, id, name, lastName, atof(salary), atoi(sector));
    return retorno;
}
/** \brief busca una posicion libre en el array para cargar un nuevo empleado
 *
* \param list Employee*
* \param length int
 * \return devuelve el indice donde se puede cargar o -1 si no hay lugar para un nuevo empleado
 *
 */
int freePosition(Employee *list, int len){
    int i, retorno = -1;
    for (i=0; i<len; i++){
        if (list[i].isEmpty){
            retorno = i;
            break;
        }
    }
    return retorno;
}
/** \brief carga por hardcoding de empleados
 *
* \param list Employee*
* \param length int
 *
 */
void hardCodingData(Employee* list, int len){
    int i;
    Employee empleado[] = {
    {10, "Juan", "Lopez", 14000, 4, 0},
    {11, "Diego", "Siri", 20000, 3, 0},
    {12, "Vanesa", "Silva", 35000, 5, 0},
    {13, "Lorena", "Lopez", 27900, 2, 0},
    {14, "Lucia", "Belen", 15300, 1, 0},
    {15, "Juana", "Caputo", 29800, 5, 0},
    {16, "Macri", "Gato", 50000, 1, 0},
    {17, "Jose", "Lamula", 25000, 2, 0},
    {18, "Ester", "Lamula", 15700, 1, 0},
    {19, "Ana", "Lamula", 45300, 5, 0},
    };
    for (i=0; i<len; i++){
        list[i] = empleado[i];
    }
}
/** \brief genera el codigo ID secuencialmente
 *
 * \return proximo ID;
 *
 */
int newId(void){
    static int nextId = 0;
    nextId++;
    return nextId;
}
/** \brief realiza el reporte de los salarios total, promedio y empleados con mayor salario al promedio
 *
* \param list Employee*
* \param length int
 * \return 0
 *
 */
int salaryReports(Employee* list, int len){
    float totalSalarios = 0, promedioSalarios;
    int i, contadorSalarios = 0, contadorEmpleados = 0;
    for (i=0; i<len; i++){
        if (list[i].isEmpty == 0){
            totalSalarios = totalSalarios + list[i].salary;
            contadorSalarios++;
        }
    }
    promedioSalarios = totalSalarios / contadorSalarios;
    for (i=0; i<len; i++){
        if ((list[i].isEmpty == 0) && (list[i].salary > promedioSalarios))
            contadorEmpleados++;
    }
    system("cls");
    printf("*** Informe de salarios ***\n");
    printf("\nEl total de los salarios es: %.2f\n",totalSalarios);
    printf("\nEl promedio de los salarios es: %.2f\n",promedioSalarios);
    printf("\nLos empleados que pasan el promedio son: %d\n\n",contadorEmpleados);
    return 0;
}
/** \brief solicita ID de empleado a borrar, lo busca y pide confirmacion
 *
* \param list Employee*
* \param length int
 * \return 0
 *
 */
int borrarEmployee(Employee* list, int len){
    int i, id;
    char respuesta;
    printf("\nIngrese el ID: ");
    scanf("%d",&id); //Comprobar que sea un entero
    i = findEmployeeById(list, len, id); //Devuelve el i del Id buscado
    if (i == -1){
        printf("\nNo existe el ID.\n");
    }
    else{
        printf("\nID\tNombre\t\tApellido\tSalario\t\t\tSector\n\n");
        printEmployee(list[i]);
        printf("\nDesea borrar el empleado? S/N: ");
        fflush(stdin);
        scanf("%c",&respuesta);
        if (respuesta == 's' || respuesta == 'S'){
            removeEmployee(list, len, id);
            printf("\nEmpleado borrado.\n\n");
        }
        else{
            printf("\nBorrado cancelado.\n\n");
        }
    }
    return 0;
}
/** \brief solicita ID empleado a modificar, lo busca y muestra un submenu para modificar valores permitidos
 *
* \param list Employee*
* \param length int
 * \return 0
 *
 */
void modificarEmployee(Employee* list, int len){
    char name[ANCHO], lastName[ANCHO], salary[ANCHO], sector[5];
    int i, r, id, subOpcion;
    printf("\nIngrese el ID: ");
    scanf("%d",&id); //Comprobar que sea un entero
    i = findEmployeeById(list, len, id); //Devuelve el i del Id buscado
    if (i == -1){
        printf("\nNo existe el ID.\n");
    }
    else{
        int flag = 0;
        system("cls");
        printf("*** Modificar empleado ***\n");
        printf("\n1- Modificar Nombre [%s].\n",list[i].name);
        printf("\n2- Modificar Apellido [%s].\n",list[i].lastName);
        printf("\n3- Modificar Salario [%.2f].\n",list[i].salary);
        printf("\n4- Modificar Sector [%d].\n",list[i].sector);
        printf("\n5- Volver al menu principal.\n");
        printf("\nElija una opcion: ");
        scanf("%d",&subOpcion);
        switch(subOpcion)
        {
            case 1:
               do{
                    fflush(stdin);
                    printf("\nIngrese el NUEVO nombre: ");
                    fgets(name, ANCHO-2, stdin);
                    quitarSaltoDeLinea(name);
                    corregirNombreCompuesto(name);
                    r = areCharacters(name);
                }while (r == 0);
                strcpy(list[i].name, name);
                flag = 1;
                break;
            case 2:
                do{
                    fflush(stdin);
                    printf("\nIngrese el NUEVO apellido: ");
                    fgets(lastName, ANCHO-2, stdin);
                    quitarSaltoDeLinea(lastName);
                    corregirNombreCompuesto(lastName);
                    r = areCharacters(lastName);
                }while (r == 0);
                strcpy(list[i].lastName, lastName);
                flag = 1;
                break;
            case 3:
                do{
                    printf("\nIngrese el NUEVO salario: ");
                    scanf("%s",salary);
                    r = isFloat(salary);
                }while (r == 0);
                list[i].salary = atof(salary);
                flag = 1;
                break;
            case 4:
                do{
                    printf("\nIngrese el NUEVO sector: ");
                    scanf("%s",sector);
                    r = isInteger(sector);
                }while (r == 0);
                list[i].sector = atoi(sector);
                flag = 1;
                break;
            case 5:
                break;
            default:
                printf("\nOpcion incorrecta.");
                break;
        }
        if (flag)
            printf("\nModificacion exitosa.\n\n");
    }
}
