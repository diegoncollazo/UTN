#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Employee.h"

Employee* employee_new(){
    Employee* pEmpleado = malloc(sizeof(Employee));
    pEmpleado->id = -1;
    strcpy(pEmpleado->nombre, "");
    pEmpleado->horasTrabajadas = 0;
    pEmpleado->sueldo = 0;
    return pEmpleado;
}

Employee* employee_newParametros(char* id,char* nombre,char* horasTrabajadas,char* sueldo){
    Employee* pEmpleado = employee_new();
    if(pEmpleado != NULL){
        pEmpleado->id = atoi(id);
        strncpy(pEmpleado->nombre, nombre, 50);
        pEmpleado->horasTrabajadas = atoi(horasTrabajadas);
        pEmpleado->sueldo = atof(sueldo);
    }
    return pEmpleado;
}

void employee_delete(){
/**< Aún no se para que sirve esta función */
}

int employee_setId(Employee* this, int id){
    int retorno = 0;
    if (id >= 0 && id <10000 && this != NULL){
        this->id = id;
        retorno = 1;
    }
    return retorno;
}

int employee_getId(Employee* this, int* id){
    int retorno = 0;
    if (id != NULL && this != NULL){
        *id = this->id;
        retorno = 1;
    }
    return retorno;
}

int employee_setNombre(Employee* this,char* nombre){
    int retorno = 0;
    if (strlen(nombre) > 0 && this != NULL){
        strncpy(this->nombre, nombre, 50);
        retorno = 1;
    }
    return retorno;
}

int employee_getNombre(Employee* this,char* nombre){
    int retorno = 0;
    if (strlen(this->nombre) > 0 && this != NULL){
        strncpy(nombre, this->nombre, 50) ;
        retorno = 1;
    }
    return retorno;
}

int employee_setHorasTrabajadas(Employee* this, int horasTrabajadas){
    int retorno = 0;
    if (horasTrabajadas >= 0 && horasTrabajadas <500 && this != NULL){
        this->horasTrabajadas = horasTrabajadas;
        retorno = 1;
    }
    return retorno;
}

int employee_getHorasTrabajadas(Employee* this,int* horasTrabajadas){
    int retorno = 0;
    if (horasTrabajadas != NULL && this != NULL){
        *horasTrabajadas = this->horasTrabajadas;
        retorno = 1;
    }
    return retorno;
}

int employee_setSueldo(Employee* this,int sueldo){
    int retorno = 0;
    if (sueldo >= 0  && this != NULL){
        this->sueldo = sueldo;
        retorno = 1;
    }
    return retorno;
}

int employee_getSueldo(Employee* this,int* sueldo){
    int retorno = 0;
    if (sueldo != NULL && this != NULL){
        *sueldo = this->sueldo;
        retorno = 1;
    }
    return retorno;
}

int employee_sortById(void* auxEmpleado1, void* auxEmpleado2){
    int retorno = 0;
    if(((Employee*)auxEmpleado1)->id<((Employee*)auxEmpleado2)->id)
        retorno = 1;
    return retorno;
}

int employee_sortByNombre(void* auxEmpleado1, void* auxEmpleado2){
    int retorno = 0;
    if(strcmp(((Employee*)auxEmpleado1)->nombre, ((Employee*)auxEmpleado2)->nombre) > 0)
        retorno = 1;
    return retorno;
}

int employee_sortBySueldo(void* auxEmpleado1, void* auxEmpleado2){
    int retorno = 0;
    if(((Employee*)auxEmpleado1)->sueldo<((Employee*)auxEmpleado2)->sueldo)
        retorno = 1;
    return retorno;
}

int employee_sortByHorasTrabajadas(void* auxEmpleado1, void* auxEmpleado2){
    int retorno = 0;
    if(((Employee*)auxEmpleado1)->horasTrabajadas<((Employee*)auxEmpleado2)->horasTrabajadas)
        retorno = 1;
    return retorno;
}

int employee_filterByNombre(void* auxEmpleado){
    Employee* pEmpleado = (Employee*)auxEmpleado;
    int retorno = 0;
    if (strcmp(pEmpleado->nombre, "Diego") == 0)
        retorno = 1;
    return retorno;
}

int employee_filterByHorasTrabajadas(void* auxEmpleado){
    int retorno = 0;
    if(((Employee*)auxEmpleado)->horasTrabajadas >= 50)
        retorno = 1;
    return retorno;
}

int employee_filterBySueldo(void* auxEmpleado){
    int retorno = 0;
    if(((Employee*)auxEmpleado)->sueldo >= 40000)
        retorno = 1;
    return retorno;
}
/** \brief Calcula salarios
 *
 * \param void* auxEmpleado
 * \param float *sueldo
 * \return Retorna -1 si hay error y sino el sueldo calculado.
 *
 */
float employee_mapBySueldo(void* auxEmpleado, float *sueldo){
    *sueldo = -1;
    int horasTrabajadas = ((Employee*)auxEmpleado)->horasTrabajadas;
    if(horasTrabajadas <= 176){
        *sueldo = (float) 180 * horasTrabajadas;
    }
    else if ((horasTrabajadas > 176) && (horasTrabajadas <= 208)){
        *sueldo = (float) 270 * horasTrabajadas;
    }
    else if ((horasTrabajadas > 208) && (horasTrabajadas <= 240)){
        *sueldo = (float) 360 * horasTrabajadas;
    }
    return *sueldo;
}
