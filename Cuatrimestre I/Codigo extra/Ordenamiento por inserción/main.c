#include <stdio.h>
#include <stdlib.h>
void ordenamientoInsercion(int data[], int len);

int main()
{
    int numeros[5] = {5,7,1,2,-1};
    int tamanIo = 5;
    for (int i=0; i<5;i++){
        printf("%d ",numeros[i]);
    }
    printf("\n");
    ordenamientoInsercion(numeros,tamanIo);
    for (int i=0; i<5;i++){
        printf("%d ",numeros[i]);
    }
    return 0;
}

void ordenamientoInsercion(int data[], int len) {
  int i, j, temp;
  for (i=1; i < len; i++) {
    temp = data[i];
    j = i-1;
    while (data[j]>temp && j>=0) {
      data[j+1] = data[j];
      j--;
    }
    data[j+1] = temp;
  }
}
