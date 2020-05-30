#include <stdio.h>
#include <stdlib.h>

int main()
{
    char nombre[20]= {"Ana"};
    char apellido[20] = {"Perez"};
    char nombreCompleto[40];
    strcpy(nombreCompleto, nombre);
    strcat(nombreCompleto, " ");
    strcat(nombreCompleto, apellido);
    printf("%s\n", nombreCompleto);
    return 0;
}
