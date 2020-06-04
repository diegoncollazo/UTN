#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define FILAS 3

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
void mostrarEmpleados(eEmpleado lista[], int filas);
void ordenarEmpleados(eEmpleado lista[], int filas);
int main()
{
    eEmpleado empleados[FILAS];
    for (int i=0; i<FILAS; i++){
        printf("Ingrese legajo: ");
        scanf("%d",&empleados[i].legajo);
        printf("Ingrese nombre: ");
        fflush(stdin);
        gets(empleados[i].nombre);
        printf("Ingrese sexo: ");
        fflush(stdin);
        scanf("%c",&empleados[i].sexo);
        printf("Ingrese sueldo: ");
        scanf("%f",&empleados[i].sueldo);
    }
    mostrarEmpleados(empleados,FILAS);

    return 0;
}

void mostrarEmpleado(eEmpleado employee){
    printf("%d %s %c %.2f \n\n",employee.legajo,employee.nombre,employee.sexo,employee.sueldo);
}

void mostrarEmpleados(eEmpleado lista[], int filas){
    for (int j=0; j<filas; j++){
        mostrarEmpleado(lista[j]);
    }
}

void ordenarEmpleados(eEmpleado lista[], int filas){
    eEmpleado auxiliar;

    for (int i=0; i<filas; i++){
        for (int j=i+1; j<filas; j++){
            if (lista[i].sexo > lista[j].sexo){
                auxiliar = lista[i];
                lista[i] = lista[j];
                lista[j] = auxiliar;
            }
        }
    }
}
