#include <stdio.h>
#include <stdlib.h>
#include <string.h>
/*
struct empleado{
    int legajo;
    char nombre[25];
    char sexo;
    float sueldo;
};
*/
typedef struct{
    int dia;
    int mes;
    int ano;
}eFecha;

typedef struct{
    int legajo;
    char nombre[25];
    char sexo;
    float sueldo;
    eFecha fechaIngreso;
}eEmpleado;

void mostrarEmpleado(eEmpleado employee);

int main()
{
    //struct empleado unEmpleado;
    eFecha unafecha;
    unafecha.dia = 30;
    unafecha.mes = 6;
    unafecha.ano = 2015;

    eEmpleado unEmpleado;
    eEmpleado otroEmpleado;
    eEmpleado empleado3 = {2222,"Felicitas",'f',2001.51,{1,10,2012}};
    eEmpleado empleado4;

    empleado4.fechaIngreso = unafecha;

    unEmpleado.legajo = 1122;
    strcpy(unEmpleado.nombre,"Lucia");
    unEmpleado.sexo = 'f';
    unEmpleado.sueldo = 15000.75;
    unEmpleado.fechaIngreso.dia = 30;
    unEmpleado.fechaIngreso.mes = 06;
    unEmpleado.fechaIngreso.ano = 2015;

    otroEmpleado.legajo = 1234;
    strcpy(otroEmpleado.nombre,"Juan Ignacio");
    otroEmpleado.sexo = 'm';
    otroEmpleado.sueldo = 10000.5;
/*
    printf("Ingrese legajo: ");
    scanf("%d",&empleado4.legajo);
    printf("Ingrese nombre: ");
    fflush(stdin);
//    fgets(empleado4.nombre, 23,stdin);
    scanf("%s",&empleado4.nombre);
    printf("Ingrese sexo: ");
    fflush(stdin);
    scanf("%c",&empleado4.sexo);
    printf("Ingrese sueldo: ");
    scanf("%f",&empleado4.sueldo);

/*    printf("\n");
    mostrarEmpleado(unEmpleado);
    printf("\n");
    mostrarEmpleado(otroEmpleado);
    printf("\n");
    */
    mostrarEmpleado(empleado3);

    printf("\n");
    mostrarEmpleado(unEmpleado);

    return 0;
}
void mostrarEmpleado(eEmpleado employee){
    printf("%d %s %c %.2f %02d/%02d/%4d \n\n",employee.legajo,employee.nombre,employee.sexo,employee.sueldo,employee.fechaIngreso.dia,employee.fechaIngreso.mes,employee.fechaIngreso.ano);
}
