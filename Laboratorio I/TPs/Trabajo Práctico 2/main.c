#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#include "employee.h"

int main(){
    Employee arrayEmployees[ELEMENTS];
    char opcion;
    int flag = 0, r, hayLugar;
    r = initEmployees(arrayEmployees, ELEMENTS);
    hardCodingData(arrayEmployees, 10);
    do{
        fflush(stdin);
        system("cls");
        printf("*** Menu principal ***\n");
        printf("\n1- Alta de empleado.\n");
        printf("\n2- Modificar empleado.\n");
        printf("\n3- Baja de empleado.\n");
        printf("\n4- Informe de empleados.\n");
        printf("\n5- Salir.\n");
        printf("\nElija una opcion: ");
        scanf("%c",&opcion);
        switch(opcion)
        {
            case '1':
                hayLugar = freePosition(arrayEmployees, ELEMENTS);
                if (hayLugar == -1){
                    printf("No hay lugar para cargar mas empleados");
                }
                else{
                    r = validateEmployee(arrayEmployees, ELEMENTS);
                    if (r == -1)
                        printf("No se puede cargar el empleado");
                    else
                        flag = 1;
                }
                break;
            case '2':
                if (flag)
                    modificarEmployee(arrayEmployees, ELEMENTS);
                else
                    printf("\nNo hay datos cargados.\n\n");
                system("pause");
                break;
            case '3':
                if (flag)
                    r = borrarEmployee(arrayEmployees, ELEMENTS);
                else
                    printf("\nNo hay datos cargados.\n\n");
                system("pause");
                break;
            case '4':
                if (flag){
                    r = sortEmployees(arrayEmployees, ELEMENTS, 1);//Ascendente
                    //r = sortEmployees(arrayEmployees, ELEMENTS, 2);//Descendente
                    r = printEmployees(arrayEmployees, ELEMENTS);
                    system("pause");
                    r = salaryReports(arrayEmployees, ELEMENTS);
                }
                else
                    printf("\nNo hay datos cargados.\n\n");
                system("pause");
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
