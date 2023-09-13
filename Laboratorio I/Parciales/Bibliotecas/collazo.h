#ifndef COLLAZO_H_INCLUDED
#define COLLAZO_H_INCLUDED
#define COLUMNAS 31

float multiplicacion(float operador1, float operador2);
float division(float operador1, float operador2);
float resta(float operador1, float operador2);
float suma(float operador1, float operador2);
float factorial(float numero);
int validarRangoEntero(int valor, int limiteInferior, int limiteSuperior);
void factorialConPunteros(float operador1, float operador2, float *punteroFactorial1, float *punteroFactorial2);
void contactShow(char nombre[][COLUMNAS], char apellido[][COLUMNAS], int edad[], int legajo[], int isEmpty[], int cantidadFilas);
void getContact(char nombre[][COLUMNAS], char apellido[][COLUMNAS], int edad[], int legajo[], int isEmpty[],int cantidadFilas);

#endif // COLLAZO_H_INCLUDED
