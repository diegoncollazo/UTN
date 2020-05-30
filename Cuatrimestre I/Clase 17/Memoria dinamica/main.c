#include <stdio.h>
#include <stdlib.h>

int main()
{
    int *p;
    p = (int*) malloc(sizeof(p));
    *p = 5;
    if (p != NULL){
        printf("Valor de x: %d",*p);
        free(p);
    }
    return 0;
}
