#ifndef EMPLOYEE_H_INCLUDED
#define EMPLOYEE_H_INCLUDED
#define ELEMENTS 1000
#define ANCHO 51

typedef struct{
 int id;
 char name[ANCHO];
 char lastName[ANCHO];
 float salary;
 int sector;
 int isEmpty;
}Employee;

int addEmployee(Employee *list, int len, int id, char name[], char lastName[], float salary, int sector);
int findEmployeeById(Employee* list, int len, int id);
int sortEmployees(Employee* list, int len, int order);
int removeEmployee(Employee* list, int len, int id);
int validateEmployee(Employee *list, int len);
int borrarEmployee(Employee* list, int len);
int printEmployees(Employee *list, int len);
int initEmployees(Employee *list, int len);
int salaryReports(Employee* list, int len);
int freePosition(Employee *list, int len);
int printEmployee(Employee empleado);
int newId(void);
void modificarEmployee(Employee* list, int len);
void hardCodingData(Employee* list, int len);

#endif // EMPLOYEE_H_INCLUDED
