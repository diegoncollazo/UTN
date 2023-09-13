#include <stdio.h>
#include <stdlib.h>
#include "Person.h"

int main(){
    Person personas[10];
    int r,i;
    r = parseData("datos.csv", personas);
    printf("id\tnombre\t\tapellido\t\tedad\n\n");
    for(i=0; i<r; i++)
        printf("%d\t%s\t\t%s\t\t%d\n", person_getId(&personas[i]), person_getName(&personas[i]), person_getLastName(&personas[i]), person_getAge(&personas[i]));

    exit(EXIT_SUCCESS);

    scanf(" ");
    return 0;
}
