#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#define COLUMNAS 8

void mostrarArrayChar(char vector[]);
void ordenarCaracteres(char *vector);

int main()
{
    char muchosCaracteres[] = {'g','f','a','A','c','g','b','Z'};
    mostrarArrayChar(muchosCaracteres);
    ordenarCaracteres(muchosCaracteres);
    mostrarArrayChar(muchosCaracteres);
    return 0;
}

void mostrarArrayChar(char vector[])
{
    for (int x=0; x<COLUMNAS; x++)
    {
        printf("%c ",vector[x]);
    }
    printf("\n\n");
}

void ordenarCaracteres(char *vector)
{
    char aux;
    for(int x=0; x < COLUMNAS; x++)
    {
        for(int y=0; y < x-1; y++)
        {
            if(vector[y]>vector[x])
            {
                aux = vector[x];
                vector[x] = vector[y];
                vector[y] = aux;
            }
        }
    }
}
