#include <stdio.h>
#include <stdlib.h>
#include "../Bibliotecas/utn.h"
#include "../Bibliotecas/LinkedList.h"
#include "Controller.h"
#include "Employee.h"
#include "parser.h"
#define ANCHO 128
/** \brief Carga los datos de los empleados desde el archivo data.csv (modo texto).
 *
 * \param path char*
 * \param pArrayListEmployee LinkedList*
 * \return int
 *
 */
int controller_loadFromText(char* path , LinkedList* pArrayListEmployee){
    FILE *text;
    int retorno = 0;
    if ((text = fopen(path, "r"))!=NULL)
        retorno = parser_EmployeeFromText(text, pArrayListEmployee);
    fclose(text);
    return retorno;
}/**< FINALIZADO */
/** \brief Carga los datos de los empleados desde el archivo data.csv (modo binario).
 *
 * \param path char*
 * \param pArrayListEmployee LinkedList*
 * \return int
 *
 */
int controller_loadFromBinary(char* path , LinkedList* pArrayListEmployee){
    FILE *binary;
    int retorno = 0;
    if ((binary = fopen(path, "rb")) != NULL)
        retorno = parser_EmployeeFromBinary(binary, pArrayListEmployee);
    fclose(binary);
    return retorno;
}/**< FINALIZADO */
/** \brief Alta de empleados
 *
 * \param path char*
 * \param pArrayListEmployee LinkedList*
 * \return int
 *
 */
int controller_addEmployee(LinkedList* pArrayListEmployee){
    Employee* pEmpleado = NULL;
    Employee* auxEmpleado = employee_new();
    int retorno = 0, control, r[4];
    char nombre[ANCHO], id[10], horasTrabajadas[5] , sueldo[15];
    system("cls");
    printf("*** Alta empleado ***\n");
    do{
        fflush(stdin);
        printf("\nIngrese el ID: ");
        fgets(id, 10-2, stdin);
        quitarSaltoDeLinea(id);
        r[0] = esDigito(id);
        if (r[0])
            control = controller_findEmployee(pArrayListEmployee, atoi(id));
    }while (control != -1);
    /**< Encontro ID libre y procede a cargar el resto de los datos. */
    if (control == -1){
        printf("\nID libre [%s]\n",id);
        do{
            fflush(stdin);
            printf("\nIngrese el nombre: ");
            fgets(nombre, ANCHO-2, stdin);
            quitarSaltoDeLinea(nombre);
            corregirNombreCompuesto(nombre);
            r[0] = areCharacters(nombre);
        }while (r[0] == 0);
        do{
            fflush(stdin);
            printf("\nIngrese horas trabajadas: ");
            scanf("%s",horasTrabajadas);
            quitarSaltoDeLinea(horasTrabajadas);
            r[0] = esDigito(horasTrabajadas);

        }while (r[0] == 0);
        do{
            fflush(stdin);
            printf("\nIngrese el sueldo: ");
            scanf("%s",sueldo);
            quitarSaltoDeLinea(sueldo);
            r[0] = isFloat(sueldo);
        }while (r[0] == 0);
        r[0] = employee_setId(auxEmpleado, atoi(id));
        if (!r[0])
            printf("\nEl ID se encuentra fuera de rango.\n");
        r[1] = employee_setNombre(auxEmpleado, nombre);
        if (!r[1])
            printf("\nEl nombre es invalido.\n");
        r[2] = employee_setHorasTrabajadas(auxEmpleado, atoi(horasTrabajadas));
        if (!r[2])
            printf("\nLas horas trabajadas se encuentran fuera de rango.\n");
        r[3] = employee_setSueldo(auxEmpleado, atof(sueldo));
        if (!r[3])
            printf("\nEl sueldo se encuentra fuera de rango.\n");
        if (r[0] && r[1] && r[2] && r[3]){
            pEmpleado = employee_newParametros(id , nombre, horasTrabajadas, sueldo);
            if (pEmpleado != NULL){
                control = ll_add(pArrayListEmployee,pEmpleado);
                if (control)
                    printf("\nEmpleado no cargado exitosamente.\n\n");
                else
                    printf("\nEmpleado cargado exitosamente.\n\n");
            }
            else
                printf("\nNo se pudo conseguir memoria libre.\n");
        }
        else
            printf("\nEmpleado no cargado exitosamente (algun valor fuera de rango).\n\n");
    }
    free(pEmpleado);
    free(auxEmpleado);
    return retorno;
}/**< FINALIZADO */
/** \brief Modificar datos de empleado
 *
 * \param path char*
 * \param pArrayListEmployee LinkedList*
 * \return int
 *
 */
int controller_editEmployee(LinkedList* pArrayListEmployee){
    Employee* pEmpleado = NULL;
    Employee* auxEmpleado = employee_new();
    char nombre[ANCHO], id[10], horasTrabajadas[5] , sueldo[15], opcion = '0';
    int r, control, index, retorno = 0, flag = 0;
    system("cls");
    printf("*** Modificar empleado ***\n");
    printf("\nIngrese el ID: ");
    fflush(stdin);
    fgets(id, 10-2, stdin);
    quitarSaltoDeLinea(id);
    index = controller_findEmployee(pArrayListEmployee, atoi(id));
    if (index != -1){
        pEmpleado = (Employee*) ll_get(pArrayListEmployee, index);
        fflush(stdin);
        printf("\n1- Modificar ID [%d].\n",pEmpleado->id);
        printf("\n2- Modificar Nombre [%s].\n",pEmpleado->nombre);
        printf("\n3- Modificar horas trabajadas [%d].\n",pEmpleado->horasTrabajadas);
        printf("\n4- Modificar Salario [%6.2f].\n",pEmpleado->sueldo);
        printf("\n5- Volver al menu principal.\n");
        printf("\nElija una opcion: ");
        scanf("%c",&opcion);
        switch(opcion){
            case '1':
                do{
                    fflush(stdin);
                    printf("\nIngrese el NUEVO ID: ");
                    fgets(id, 10-2, stdin);
                    quitarSaltoDeLinea(id);
                    r = esDigito(id);
                    if (r)
                        control = controller_findEmployee(pArrayListEmployee, atoi(id));
                }while (control != -1);
                r = employee_setId(auxEmpleado, atoi(id));
                if (r){
                    employee_setId(pEmpleado, atoi(id));
                    flag = 1;
                }
                else
                    printf("\nEl ID se encuentra fuera de rango.\n");
                break;
            case '2':
                do{
                    fflush(stdin);
                    printf("\nIngrese el NUEVO nombre: ");
                    fgets(nombre, ANCHO-2, stdin);
                    quitarSaltoDeLinea(nombre);
                    corregirNombreCompuesto(nombre);
                    r = areCharacters(nombre);
                }while (r == 0);
                r = employee_setNombre(auxEmpleado, nombre);
                if (r){
                    employee_setNombre(pEmpleado, nombre);
                    flag = 1;
                }
                else
                    printf("\nEl nombre es invalido.\n");
                break;
            case '3':
                do{
                    fflush(stdin);
                    printf("\nIngrese horas trabajadas: ");
                    scanf("%s",horasTrabajadas);
                    quitarSaltoDeLinea(horasTrabajadas);
                    r = esDigito(horasTrabajadas);
                }while (r == 0);
                r = employee_setHorasTrabajadas(auxEmpleado, atoi(horasTrabajadas));
                if (r){
                    employee_setHorasTrabajadas(pEmpleado, atoi(horasTrabajadas));
                    flag = 1;
                }
                else
                    printf("\nLas horas trabajadas se encuentran fuera de rango.\n");
                break;
            case '4':
                do{
                    fflush(stdin);
                    printf("\nIngrese el sueldo: ");
                    scanf("%s",sueldo);
                    quitarSaltoDeLinea(sueldo);
                    r = isFloat(sueldo);
                }while (r == 0);
                r = employee_setSueldo(auxEmpleado, atof(sueldo));
                if (r){
                    employee_setSueldo(pEmpleado, atof(sueldo));
                    flag = 1;
                }else
                    printf("\nEl sueldo se encuentra fuera de rango.\n");
                break;
        }
        if (flag)
            printf("\nEmpleado modificado exitosamente.\n");
        else
            printf("\nEmpleado no modificado.\n");
    }
    else
        printf("\nEmpleado no encontrado.\n");
    printf("\n");
    return retorno;
}/**< FINALIZADO */
/** \brief Baja de empleado
 *
 * \param path char*
 * \param pArrayListEmployee LinkedList*
 * \return int
 *
 */
int controller_removeEmployee(LinkedList* pArrayListEmployee){
    Employee* pEmpleado;
    int index, retorno = 0;
    char id[10], opcion;
    system("cls");
    printf("*** Borrar empleado ***\n");
    printf("\nIngrese el ID: ");
    fflush(stdin);
    fgets(id, 10-2, stdin);
    quitarSaltoDeLinea(id);
    index = controller_findEmployee(pArrayListEmployee, atoi(id));
    if (index != -1){
        pEmpleado = (Employee*) ll_get(pArrayListEmployee, index);
        printf("\nEmpleado a borrar:\n");
        printf("\nID\tNombre\t\tHoras\tSueldo\n");
        printf("\n%4d\t%s\t\t%d\t%6.2f\n",pEmpleado->id,pEmpleado->nombre,pEmpleado->horasTrabajadas,pEmpleado->sueldo);
        printf("\n%cEst%c seguro? S/N: ", 168, 160);
        fflush(stdin);
        scanf("%c",&opcion);
        if (opcion == 's' || opcion == 'S'){
            retorno =  !ll_remove(pArrayListEmployee, index);
            printf("\nBorrado exitoso.\n");
        }
        else
            printf("\nBorrado cancelado.\n");
    }
    else
        printf("\nEmpleado no encontrado.\n");
    printf("\n");
    return retorno;
}/**< FINALIZADO */
/** \brief Listar empleados
 *
 * \param path char*
 * \param pArrayListEmployee LinkedList*
 * \return int
 *
 */
int controller_ListEmployee(LinkedList* pArrayListEmployee){
    Employee *pEmpleado;
    int i, retorno = 1;
    system("cls");
    for (i=0; i < ll_len(pArrayListEmployee); i++){
        pEmpleado = ll_get(pArrayListEmployee, i);
        printf("%5d %20s %3d %6.2f\n",pEmpleado->id,pEmpleado->nombre,pEmpleado->horasTrabajadas,pEmpleado->sueldo);
    }
    printf("\n");
    return retorno;
}/**< FINALIZADO */
/** \brief Ordenar empleados
 *
 * \param path char*
 * \param pArrayListEmployee LinkedList*
 * \return int
 *
 */
int controller_sortEmployee(LinkedList* pArrayListEmployee){
    int retorno = 0;
    char opcion;
    do{
        system("cls");
        printf("*** Ordenar empleados ***\n");
        printf("\n1- Ordenar por ID.\n");
        printf("\n2- Ordenar por nombre.\n");
        printf("\n3- Ordenar por horas trabajadas.\n");
        printf("\n4- Ordenar por sueldo.\n");
        printf("\n5- Volver al menu principal.\n");
        printf("\nElija una opcion: ");
        fflush(stdin);
        scanf("%c",&opcion);
        switch (opcion){
            case '1':
                ll_sort(pArrayListEmployee,employee_sortById,1);
                retorno = 1;
                break;
            case '2':
                ll_sort(pArrayListEmployee,employee_sortByNombre,1);
                retorno = 1;
                break;
            case '3':
                ll_sort(pArrayListEmployee,employee_sortByHorasTrabajadas,1);
                retorno = 1;
                break;
            case '4':
                ll_sort(pArrayListEmployee,employee_sortBySueldo,1);
                retorno = 1;
                break;
            default:
                break;
        }
    }while (opcion != '5');
    return retorno;
}/**< FINALIZADO */
/** \brief Guarda los datos de los empleados en el archivo data.csv (modo texto).
 *
 * \param path char*
 * \param pArrayListEmployee LinkedList*
 * \return int
 *
 */
int controller_saveAsText(char* path , LinkedList* pArrayListEmployee){
    FILE* text;
    Employee* this;
    int retorno = 0, largo, i;
    text = fopen(path, "w");
    largo = ll_len(pArrayListEmployee);
    if(text != NULL && pArrayListEmployee != NULL){
        fprintf(text, "id,nombre,horasTrabajadas,sueldo\n");
        for(i=0; i < largo; i++){
            this = (Employee*) ll_get(pArrayListEmployee, i);
            fprintf(text, "%d,%s,%d,%.2f\n", this->id, this->nombre, this->horasTrabajadas, this->sueldo);
        }
        retorno = 1;
    }
    fclose(text);
    return retorno;
}/**< FINALIZADO */
/** \brief Guarda los datos de los empleados en el archivo data.csv (modo binario).
 *
 * \param path char*
 * \param pArrayListEmployee LinkedList*
 * \return int
 *
 */
int controller_saveAsBinary(char* path , LinkedList* pArrayListEmployee){
    FILE* binary;
    Employee* this;
    int retorno = 0, largo, i;
    binary = fopen(path, "wb");
    largo = ll_len(pArrayListEmployee);
    if(binary != NULL && pArrayListEmployee != NULL){
        for(i=0; i<largo; i++){
            this = (Employee*)ll_get(pArrayListEmployee, i);
            fwrite(this, sizeof(Employee), 1, binary);
        }
        retorno = 1;
    }
    fclose(binary);
    return retorno;
}/**< FINALIZADO */
/** \brief Busca el ID de un empleado.
 *
 * \param pArrayListEmployee LinkedList*
 * \param ID int
 * \return int
 *
 */
int controller_findEmployee(LinkedList* pArrayListEmployee, int id){
    Employee* pEmpleado;
    int i, retorno = -1;
    for (i=0; i < ll_len(pArrayListEmployee); i++){
        pEmpleado = (Employee*) ll_get(pArrayListEmployee, i);
        if (id == pEmpleado->id){
            retorno = i;
            break;
        }
    }
    return retorno;
}/**< FINALIZADO */
/** \brief Menu para filtrado del Array por parametros
 *
 * \param LinkedList* pArrayListEmployee
 * \return int
 *
 */
int controller_filterEmployee(LinkedList* pArrayListEmployee){
    LinkedList* listaEmpleadosFiltrados;
    int retorno = -1;
    char opcion;
    do{
        system("cls");
        printf("*** Filtrar empleados ***\n");
        printf("\n1- Filtrar por nombre.\n");
        printf("\n2- Filtrar por horas trabajadas.\n");
        printf("\n3- Filtrar por sueldo.\n");
        printf("\n4- Volver al menu principal.\n");
        printf("\nElija una opcion: ");
        fflush(stdin);
        scanf("%c",&opcion);
        switch (opcion){
            case '1':
                listaEmpleadosFiltrados = ll_filter(pArrayListEmployee, employee_filterByNombre);
                if (listaEmpleadosFiltrados != NULL){
                    controller_ListEmployee(listaEmpleadosFiltrados);
                }
                system("pause");
                break;
            case '2':
                listaEmpleadosFiltrados = ll_filter(pArrayListEmployee, employee_filterByHorasTrabajadas);
                if (listaEmpleadosFiltrados != NULL){
                    controller_ListEmployee(listaEmpleadosFiltrados);
                }
                system("pause");
                break;
            case '3':
                listaEmpleadosFiltrados = ll_filter(pArrayListEmployee, employee_filterBySueldo);
                if (listaEmpleadosFiltrados != NULL){
                    controller_ListEmployee(listaEmpleadosFiltrados);
                }
                system("pause");
                break;
            default:
                break;
        }
    }while (opcion != '4');
    return retorno;
}/**< FINALIZADO */
