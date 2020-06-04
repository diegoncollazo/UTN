#include <stdio.h>
#include <stdlib.h>
#include "../Bibliotecas/LinkedList.h"
#include "Controller.h"
#include "Employee.h"
/******************************************************************************
Menu:
 1. Cargar los datos de los empleados desde el archivo data.csv (modo texto).
 2. Cargar los datos de los empleados desde el archivo data.bin (modo binario).
 3. Alta de empleado
 4. Modificar datos de empleado
 5. Baja de empleado
 6. Listar empleados
 7. Ordenar empleados
 8. Guardar los datos de los empleados en el archivo data.csv (modo texto).
 9. Guardar los datos de los empleados en el archivo data.bin (modo binario).
10. Salir
******************************************************************************/
int main(){
    int opcion, control;
    LinkedList* listaEmpleados = ll_newLinkedList();
    do{
        fflush(stdin);
        system("cls");
        printf("*** Menu principal ***\n");
        printf("\n1. Cargar los datos de los empleados desde el archivo data.csv (modo texto).\n");
        printf("\n2. Cargar los datos de los empleados desde el archivo data.bin (modo binario).\n");
        printf("\n3. [A]lta de empleado.\n");
        printf("\n4. [B]aja de empleado.\n");
        printf("\n5. [M]odificar datos de empleado.\n");
        printf("\n6. Listar empleados.\n");
        printf("\n7. Ordenar empleados.\n");
        printf("\n8. Guardar los datos de los empleados en el archivo data.csv (modo texto).\n");
        printf("\n9. Guardar los datos de los empleados en el archivo data.bin (modo binario).\n");
        printf("\n10.Filtrado de empleados.\n");
        printf("\n20.Salir.\n");
        printf("\nElija una opcion: ");
        scanf("%d",&opcion);
        switch(opcion){
            case 1:/**< Cargar CSV */
                control = controller_loadFromText("data.csv",listaEmpleados);
                if (control)
                    printf("\nArchivo cargado con exito.\n\n");
                else
                    printf("\nNo se pudo abrir el archivo.\n\n");
                system("pause");
                break;
            case 2:/**< Cargar BIN */
                control = controller_loadFromBinary("data.bin",listaEmpleados);
                if (control)
                    printf("\nArchivo cargado con exito.\n\n");
                else
                    printf("\nNo se pudo abrir el archivo.\n\n");
                system("pause");
                break;
            case 3:/**< Alta empleado */
                control = controller_addEmployee(listaEmpleados);
                system("pause");
                break;
            case 4:/**< Baja empleado */
                control = controller_removeEmployee(listaEmpleados);
                system("pause");
                break;
            case 5:/**< Modificar empleado */
                control = controller_editEmployee(listaEmpleados);
                system("pause");
                break;
            case 6:/**< Listar empleados */
                control = controller_ListEmployee(listaEmpleados);
                system("pause");
                break;
            case 7:/**< Ordenar empleados */
                if (ll_len(listaEmpleados)>1)
                    control = controller_sortEmployee(listaEmpleados);
                else{
                    printf("\nEl archivo contiene menos de dos elementos y no se puede ordenar.\n");
                    system("pause");
                }
                break;
            case 8:/**< Guardar CSV */
                control = controller_saveAsText("data.csv",listaEmpleados);
                if (control)
                    printf("\nArchivo guardado exitosamente.\n\n");
                else
                    printf("\nNo se puede guardar el archivo.\n\n");
                system("pause");
                break;
            case 9:/**< Guardar BIN */
                control = controller_saveAsBinary("data.bin",listaEmpleados);
                if (control)
                    printf("\nArchivo guardado exitosamente.\n\n");
                else
                    printf("\nNo se puede guardar el archivo.\n\n");
                system("pause");
                break;
            case 10:/**< Filtrar */
                control = controller_filterEmployee(listaEmpleados);
                break;
            case 20:
                printf("\nGracias por utilizar el sistema.\n");
                break;
            default:
                printf("\nOpción incorrecta.");
        }
    }while (opcion != 20);
    return 0;
}
