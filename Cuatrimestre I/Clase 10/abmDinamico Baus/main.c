#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <conio.h>

typedef struct{
    int legajo;
    char nombre[20];
    char sexo;
    float sueldo;
    int idSector;
    int isEmpty;
} eEmpleado;

typedef struct{
    int id;
    char descripcion[20];
} eSector;

typedef struct{
    int id;
    char descripcion[20];
}eComida;

typedef struct{
    int id;
    int idComida;
    int idEmpleado;
}eAlmuerzo;

int menu();
void inicializarEmpleados( eEmpleado x[], int tam);
int buscarLibre( eEmpleado x[], int tam);
int buscarEmpleado(eEmpleado x[], int tam, int legajo);
void mostrarEmpleado(eEmpleado emp, eSector sectores[], int tamSector);
void mostrarEmpleados(eEmpleado nomina[], int tam, eSector sectores[], int tamSector);
void agregarEmpleado(eEmpleado empleados[], int tam, eSector sectores[], int tamSectores);
void eliminarEmpleado(eEmpleado empleados[], int tam, eSector sectores[], int tamSector);
void modificarEmpleado(eEmpleado empleados[], int tam, eSector sectores[], int tamSector);
int elegirSector(eSector sectores[], int tam);
void cargarDescripcion(eSector sectores[], int tamSector, int idSector, char cadena[]);
void listarEmpleadosXSector(eEmpleado x[], int tam, eSector sectores[], int tamSector);
void informarMayorSueldoPorSector(eEmpleado x[], int tam, eSector sectores[], int tamSector);
void mostrarAlmuerzos(eEmpleado empleados[], int tam, eComida comidas[], int tamComidas, eAlmuerzo almuerzos[], int tamAlmuerzos);
void informarAlmuerzoPorEmpleado(eEmpleado empleados[], int tam, eComida comidas[], int tamComidas, eAlmuerzo almuerzos[], int tamAlmuerzos);

void harcodearEmpleados(eEmpleado* x);

int main()
{
    char seguir = 's';
    eEmpleado lista[10];
    eSector sectores[] =
    {
        {1,"RRHH"},
        {2,"Ventas"},
        {3,"Compras"},
        {4,"Contable"},
        {5,"Sistemas"},
    };

    eComida comidas[] = {
        {1,"Pizza"},
        {2,"Milanga"},
        {3,"Hamburgueja"},
        {4,"Fritas"},
        {5,"Mondiola"},
    };

    eAlmuerzo almuerzos[] = {
        {101, 1, 1007},
        {102, 5, 1005},
        {103, 4, 1010},
        {104, 4, 1009},
        {105, 5, 1004},
        {106, 2, 1003},
        {107, 3, 1002},
        {108, 2, 1002},
        {109, 4, 1007},
        {110, 1, 1010},
    };

    inicializarEmpleados(lista, 10);
    harcodearEmpleados(lista);

    do
    {
        switch(menu())
        {
        case 1:
            agregarEmpleado(lista, 10, sectores, 5);
            system("pause");
            break;
        case 2:
            eliminarEmpleado(lista, 10, sectores, 5);
            break;
        case 3:
            modificarEmpleado(lista, 10, sectores, 5);
            break;
        case 4:
            mostrarEmpleados(lista, 10, sectores, 5);
            system("pause");
            break;
        case 5:
            listarEmpleadosXSector(lista, 10, sectores, 5);
            system("pause");
            break;
        case 7:
            informarMayorSueldoPorSector(lista, 10, sectores, 5);
            system("pause");
            break;
        case 8:
            mostrarAlmuerzos(lista, 10, comidas, 5, almuerzos, 10);
            system("pause");
            break;
        case 9:
            mostrarEmpleados(lista, 10, sectores, 5);
            informarAlmuerzoPorEmpleado(lista, 10, comidas, 5, almuerzos, 10); //Elegir legajo
            system("pause");
            break;
        case 10:
            seguir = 'n';
            break;
        }
    }
    while(seguir == 's');
    return 0;
}

void inicializarEmpleados( eEmpleado x[], int tam){
    int i;
    for(i=0; i < tam; i++)
    {
        x[i].isEmpty = 0;
    }
}

int buscarLibre( eEmpleado x[], int tam){
    int i, indice = -1;
    for(i=0; i< tam; i++)
    {

        if( x[i].isEmpty == 0)
        {
            indice = i;
            break;
        }
    }
    return indice;
}

int buscarEmpleado(eEmpleado x[], int tam, int legajo){
    int i, indice = -1;
    for(i=0; i < tam; i++)
    {
        if( x[i].legajo == legajo && x[i].isEmpty == 1)
        {
            indice = i;
            break;
        }
    }
    return indice;
}

int menu(){
    int opcion;
    system("cls");
    printf("***Menu de Opciones***\n\n");
    printf("1- Alta\n");
    printf("2- Baja\n");
    printf("3- Modificar\n");
    printf("4- Listar\n");
    printf("5- Listar por sector\n");
    printf("6- Ordenar alfabeticamente por sector y nombre\n");
    printf("7- Mostrar los datos de los empleados que mas ganan por sector\n");
    printf("8- Mostrar almuerzos\n");
    printf("9- Mostrar almuerzo por empleado\n");
    printf("10- Salir\n");
    printf("Ingrese opcion: ");
    fflush(stdin);
    scanf("%d", &opcion);

    return opcion;
}

void agregarEmpleado(eEmpleado empleados[], int tam, eSector sectores[], int tamSectores)
{
    eEmpleado nuevoEmpleado;
    int indice;
    int esta;
    int legajo;
    indice = buscarLibre(empleados, tam);
    if(indice == -1)
    {
        printf("No hay lugar\n\n");
    }
    else
    {
        printf("Ingrese legajo: ");
        scanf("%d", &legajo);
        esta = buscarEmpleado(empleados, tam, legajo);
        if(esta != -1)
        {
            printf("Existe un empleado con el legajo %d\n", legajo);
            mostrarEmpleado( empleados[esta], sectores, 5);
        }
        else
        {
            nuevoEmpleado.legajo = legajo;
            printf("Ingrese nombre: ");
            fflush(stdin);
            gets(nuevoEmpleado.nombre);
            printf("Ingrese sexo: ");
            fflush(stdin);
            scanf("%c", &nuevoEmpleado.sexo);
            printf("Ingrese sueldo: ");
            fflush(stdin);
            scanf("%f", &nuevoEmpleado.sueldo);
            nuevoEmpleado.idSector = elegirSector(sectores,5);
            nuevoEmpleado.isEmpty = 1;
            empleados[indice] = nuevoEmpleado;
        }
    }
}

void mostrarEmpleado(eEmpleado emp, eSector sectores[], int tamSector)
{
    char descripcion[20];
    cargarDescripcion(sectores, 5, emp.idSector, descripcion);
    printf("%d\t%s\t%c\t%.2f\t%s\n", emp.legajo, emp.nombre, emp.sexo, emp.sueldo,descripcion);

}

void mostrarEmpleados(eEmpleado nomina[], int tam, eSector sectores[], int tamSector){
    int i;
    printf("Legajo\tNombre\tSexo\tSueldo\t\tSector\n");
    for(i=0; i< tam; i++)
    {
        if( nomina[i].isEmpty == 1)
        {
            mostrarEmpleado(nomina[i], sectores, tamSector);
        }
    }
}

void eliminarEmpleado(eEmpleado empleados[], int tam, eSector sectores[], int tamSector)
{
    int legajo;
    int indice;
    char borrar;
    printf("Ingrese legajo: ");
    scanf("%d", &legajo);
    indice = buscarEmpleado(empleados, tam, legajo);
    if( indice == -1)
    {
        printf("No hay ningun empleado con el legajo %d\n", legajo);
    }
    else
    {
        mostrarEmpleado( empleados[indice], sectores, 5);
        printf("\nConfirma borrado?: ");
        fflush(stdin);
        scanf("%c", &borrar);
        if(borrar != 's')
        {
            printf("Borrado cancelado\n\n");
        }
        else
        {
            empleados[indice].isEmpty = 0;
            printf("Se ha eliminado el empleado\n\n");
        }
        system("pause");
    }
}

void modificarEmpleado(eEmpleado empleados[], int tam, eSector sectores[], int tamSector)
{
    int legajo;
    int indice;
    char modificar;
    float nuevoSueldo;
    printf("Ingrese legajo: ");
    scanf("%d", &legajo);
    indice = buscarEmpleado(empleados, tam, legajo);
    if( indice == -1)
    {
        printf("No hay ningun empleado con el legajo %d\n", legajo);
    }
    else
    {
        mostrarEmpleado( empleados[indice], sectores, tamSector);
        printf("\nModifica sueldo?: ");
        fflush(stdin);
        scanf("%c", &modificar);
        if(modificar != 's')
        {
            printf("Modificacion cancelada\n\n");
        }
        else
        {
            printf("Ingrese nuevo sueldo: ");
            scanf("%f", &nuevoSueldo);

            empleados[indice].sueldo = nuevoSueldo;
            printf("Se ha modificado el sueldo con exito\n\n");
        }

        system("pause");
    }
}

int elegirSector(eSector sectores[], int tam)
{
    int i, idSector;
    printf("\nSectores\n\n");
    for (i=0; i<tam; i++)
    {
        printf("%d\t%s\n",sectores[i].id,sectores[i].descripcion);
    }
    printf("\nElegir sector: ");
    scanf("%d",&idSector);
    return idSector;
}

void cargarDescripcion(eSector sectores[], int tamSector, int idSector, char cadena[]){
    int i;
    for (i=0; i<tamSector; i++)
    {
        if (sectores[i].id == idSector)
        {
            strcpy(cadena,sectores[i].descripcion);
            break;
        }
    }
}

void listarEmpleadosXSector(eEmpleado x[], int tam, eSector sectores[], int tamSector)
{
    int sectorElegido = elegirSector(sectores, tamSector), i, bandera = 1;
    char descripcion[20];
    cargarDescripcion(sectores, 5, sectorElegido, descripcion);
    for (i=0; i<tam; i++){
        if (sectorElegido == x[i].idSector && x[i].isEmpty == 1){
            printf("%d %s %c %.2f %s\n\n", x[i].legajo, x[i].nombre, x[i].sexo, x[i].sueldo,descripcion);
            bandera = 0;
        }
    }
    if (bandera == 1)
        printf("No hay empleados en el sector.");

}

void ordenarXSectorYXNombre(eEmpleado x[], int tam, eSector sectores[], int tamSector){
    eEmpleado auxEmp;
    int i, j;
    for (i=0; i<tam-1; i++){
        for (j=i+1; j<tam; j++){
                if (strcmp(x[i].nombre,x[j].nombre ) > 0 ){ //Revisar
                    auxEmp = x[i];
                    x[i] = x[j];
                    x[j] = auxEmp;
                }
        }
    }
}

void informarMayorSueldoPorSector(eEmpleado x[], int tam, eSector sectores[], int tamSector){
    int i, j;
    float mayorSueldo[tamSector];

    for (i=0; i<tamSector; i++){
        mayorSueldo[i] = 0;
        for (j=0; j<tam; j++){
            if (x[j].idSector == sectores[i].id && x[j].sueldo > mayorSueldo[i]){
                mayorSueldo[i]= x[j].sueldo;
            }
        }
    }
    for (i=0; i<tamSector; i++){
        for (j=0; j<tam; j++){
            if (mayorSueldo[i] == x[j].sueldo && sectores[i].id == x[j].idSector)
                printf("\nMayor sueldo del sector %s es %2.f y pertenece a %s\n",sectores[i].descripcion,mayorSueldo[i],x[j].nombre);
        }
    }
}

void harcodearEmpleados(eEmpleado* x){
    int i;
    eEmpleado y[]=
    {
        {1000, "ana", 'f', 15000, 4, 1},
        {1007, "luis", 'm', 25000, 4, 1},
        {1006, "alberto", 'm', 31000, 5, 1},
        {1004, "julia", 'f', 30000, 1, 1},
        {1010, "julieta", 'f', 23000, 2, 1},
        {1009, "andrea", 'f', 31000, 5, 1},
        {1002, "mauro", 'm', 27000, 5, 1},
        {1003, "andres", 'm', 31000, 3, 1},
        {1005, "mariela", 'f', 27000, 3, 1}
    };
    for(i=0; i<9; i++){
       *(x + i) = *(y + i);
       //x[i] = y[i];
    }
}
void cargarDescripcionComidas(eComida comidas[], int tamComidas, int idComida, char cadena[]){
    int i;
    for (i=0; i<tamComidas; i++)
    {
        if (comidas[i].id == idComida)
        {
            strcpy(cadena,comidas[i].descripcion);
            break;
        }
    }
}

void mostrarAlmuerzos(eEmpleado empleados[], int tam, eComida comidas[], int tamComidas, eAlmuerzo almuerzos[], int tamAlmuerzos){
    int i, j, k;
    printf("\nId\tLegajo\tNombre\tComida\n");
    for (i=0; i<tamAlmuerzos; i++){
        for (j=0; j<tamComidas; j++){
            if (almuerzos[i].idComida == comidas[j].id){
                for (k=0; k<tam; k++){
                    if (almuerzos[i].idEmpleado == empleados[k].legajo){
                        printf("\n%d\t%d\t%s\t%s\n",almuerzos[i].id,almuerzos[i].idEmpleado,empleados[k].nombre,comidas[j].descripcion);
                    }
                }
            }
        }
    }
}

void informarAlmuerzoPorEmpleado(eEmpleado empleados[], int tam, eComida comidas[], int tamComidas, eAlmuerzo almuerzos[], int tamAlmuerzos){
    int i, j, k, legajo, indice;
    printf("Seleccione un empleado: ");
    scanf("%d",&legajo);
    indice = buscarEmpleado(empleados, 10, legajo);
    if (indice == -1){
        printf("\nEmpleado no existe\n");
    }
    else{
        for (i=0; i<tamAlmuerzos; i++){
            for (j=0; j<tamComidas; j++){
                if (almuerzos[i].idComida == comidas[j].id){
                    for (k=0; k<tam; k++){
                        if (empleados[k].legajo == indice)
                            printf("\n%d\t%d\t%s\t%s\n",almuerzos[i].id,almuerzos[i].idEmpleado,empleados[k].nombre,comidas[j].descripcion);
                    }
                }
            }
        }

    }
}
