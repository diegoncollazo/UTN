#ifndef EMPLOYEE_H_INCLUDED
#define EMPLOYEE_H_INCLUDED
typedef struct{
    int id;
    char nombre[128];
    int horasTrabajadas;
    float sueldo;
}Employee;

Employee* employee_new();
Employee* employee_newParametros(char* idStr,char* nombreStr,char* horasTrabajadasStr,char* sueldoStr);
/**< No sabemos para que */
void employee_delete();
/**< Funciones SET */
int employee_setId(Employee* this,int id);
int employee_setNombre(Employee* this,char* nombre);
int employee_setHorasTrabajadas(Employee* this,int horasTrabajadas);
int employee_setSueldo(Employee* this,int sueldo);
/**< Funciones GET */
int employee_getId(Employee* this,int* id);
int employee_getNombre(Employee* this,char* nombre);
int employee_getHorasTrabajadas(Employee* this,int* horasTrabajadas);
int employee_getSueldo(Employee* this,int* sueldo);
/**< Funciones SORT */
int employee_sortById(void* auxEmpleado1, void* auxEmpleado2);
int employee_sortByNombre(void* auxEmpleado1, void* auxEmpleado2);
int employee_sortBySueldo(void* auxEmpleado1, void* auxEmpleado2);
int employee_sortByHorasTrabajadas(void* auxEmpleado1, void* auxEmpleado2);
/**< Funciones Filter */
int employee_filterByNombre(void* auxEmpleado);
int employee_filterByHorasTrabajadas(void* auxEmpleado);
int employee_filterBySueldo(void* auxEmpleado);
/**< Funciones MAP */
float employee_mapBySueldo(void* auxEmpleado, float *sueldo);
#endif // EMPLOYEE_H_INCLUDED
