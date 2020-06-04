#include <stdio.h>
#include <stdlib.h>
#include "../Bibliotecas/LinkedList.h"
#include "../Bibliotecas/Controller.h"
#include "../Bibliotecas/Employee.h"
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
    char archivo[20];
    int opcion, control;
    LinkedList* listaEmpleados = ll_newLinkedList();
    LinkedList* listaMapEmpleados = ll_newLinkedList();
    do{
        fflush(stdin);
        system("cls");
        printf("*** Menu principal ***\n");
        printf("\n1. Cargar los datos de los empleados desde un archivo (modo texto).\n");
        printf("\n2. Listar empleados.\n");
        printf("\n3. Calcular salarios.\n");
        printf("\n4. Salir.\n");
        printf("\nElija una opcion: ");
        scanf("%d",&opcion);
        switch(opcion){
            case 1:/**< Cargar CSV */
                printf("\nIngrese el nombre del archivo: ");
                scanf("%s",archivo);
                control = controller_loadFromText(archivo,listaEmpleados);
                if (control)
                    printf("\nArchivo cargado con exito.\n\n");
                else
                    printf("\nNo se pudo abrir el archivo.\n\n");
                system("pause");
                break;
            case 2:/**< Listar empleados */
                control = controller_ListEmployee(listaEmpleados);
                system("pause");
                break;
            case 3:/**< Calcular salarios */
                listaMapEmpleados = ll_map(listaEmpleados, employee_mapBySueldo);
                if (listaMapEmpleados != NULL){
                    control = controller_ListEmployee(listaMapEmpleados);
                }
                if (control){
                    control = controller_saveAsText("info.csv",listaEmpleados);
                    if (control)
                        printf("\nArchivo guardado exitosamente.\n\n");
                    else
                        printf("\nNo se puede guardar el archivo.\n\n");
                }
                system("pause");
                break;
            case 4:
                ll_deleteLinkedList(listaEmpleados);
                ll_deleteLinkedList(listaMapEmpleados);
                printf("\nGracias por utilizar el sistema.\n");
                break;
            default:
                printf("\nOpción incorrecta.");
        }
    }while (opcion != 4);
    return 0;
}
