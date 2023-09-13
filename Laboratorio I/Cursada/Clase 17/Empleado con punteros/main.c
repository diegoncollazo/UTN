#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct{
    int codigo;
    char marca[20];
    int capacidad;
    float precio;
}ePendrive;

int cargarPendrive(ePendrive *myPendrive);
int cargarPendriveParam(ePendrive *myPendrive, int codigo, char marca[], int capacidad, float precio);
void mostrarPendrive(ePendrive *myPendrive);

int main(){
    ePendrive unPendrive;
    if (cargarPendrive(&unPendrive))
        mostrarPendrive(&unPendrive);
    return 0;
}

int cargarPendrive(ePendrive *myPendrive){
    ePendrive *auxPen;
    auxPen = malloc(sizeof(ePendrive)*1);
    int retorno = 0;
    if (myPendrive != NULL){
        //Cargar pendrive
        printf("Ingrese codigo: ");
        scanf("%d",&auxPen->codigo);
        fflush(stdin);
        printf("\nIngrese marca: ");
        //fgets(auxPen->marca, 20-2 ,stdin);
        scanf("%s",&auxPen->marca);
        printf("\nIngrese capacidad: ");
        scanf("%d",&auxPen->capacidad);
        printf("\nIngrese precio: ");
        scanf("%f",&auxPen->precio);

        retorno = cargarPendriveParam(myPendrive,auxPen->codigo,auxPen->marca,auxPen->capacidad,auxPen->precio);
    }
    free(auxPen);
    return retorno;
}
int cargarPendriveParam(ePendrive *myPendrive, int codigo, char marca[], int capacidad, float precio){
    int retorno = 0;
    if (myPendrive != NULL){
        strcpy(myPendrive->marca,marca);
        myPendrive->codigo = codigo;
        myPendrive->capacidad = capacidad;
        myPendrive->precio = precio;
        retorno = 1;
    }
    return retorno;
}
void mostrarPendrive(ePendrive *myPendrive){
    printf("Codigo\tMarca\tCapacidad\tPrecio\n");
    printf("%d\t%s\t%d\t%.2f",myPendrive->codigo,myPendrive->marca,myPendrive->capacidad,myPendrive->precio);
}
