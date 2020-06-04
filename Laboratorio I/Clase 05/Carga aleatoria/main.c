#include <stdio.h>
#include <stdlib.h>
#define CANT 50

int main()
{
    int legajo[CANT],i,isEmpty[CANT];
    float salario[CANT];
    for (i=0; i < CANT ; i++){
        isEmpty[i]=1;
    }

    for(i=0; i < CANT ; i++){
        printf("Legajo: ");
        scanf("%d",&legajo[i]);
        printf("Salario: ");
        scanf("%f",&salario);
        isEmpty[i]=0;
        break;
    }
    return 0;
}
