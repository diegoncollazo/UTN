#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//Planchar cadena

int main()
{
    char nombre[20]= {"JUAN"};
    strlwr(nombre);
    printf("%s\n\n", nombre);
    return 0;
}
