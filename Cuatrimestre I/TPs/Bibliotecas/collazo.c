#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#include "collazo.h"

int validarRangoEntero(int valor, int limiteInferior, int limiteSuperior){
    int respuesta = 0;
    if (valor >= limiteInferior && valor <= limiteSuperior){
        respuesta = 1;
    }
    return respuesta;
}
float suma(float operador1, float operador2){
    float resultado;
    resultado = operador1 + operador2;
    return resultado;
}
float resta(float operador1, float operador2){
    float resultado;
    resultado = operador1 - operador2;
    return resultado;
}
float division(float operador1, float operador2){
    float resultado;
    if (operador2==0){
    }
    else{
        resultado = operador1 / operador2;
    }
    return resultado;
}
float multiplicacion(float operador1, float operador2){
    float resultado;
    resultado = operador1 * operador2;
    return resultado;
}
float factorial(float numero){
    float resultado = 1;
    int parteEntera, c;
        if (numero <= 0){
        resultado=0;
    }
    else
    {
        parteEntera = numero; //Saco la parte entera del numero ingresado.
        for(c = 1; c <= parteEntera; c++){
            resultado = resultado * c;
        }
    }
    return resultado;
}
void factorialConPunteros(float operador1, float operador2, float *punteroFactorial1, float *punteroFactorial2){
    int parteEntera1, parteEntera2, resultado1 = 1, resultado2 = 1, contador;
    if (operador1 <= 0){
        resultado1=0;
    }
    else
    {
        parteEntera1 = operador1; //Saco la parte entera del numero ingresado.
        for(contador = 1; contador <= parteEntera1; contador++){
            resultado1 = resultado1 * contador;
        }
    }
    if (operador2 <= 0){
        resultado2=0;
    }
    else
    {
        parteEntera2 = operador2; //Saco la parte entera del numero ingresado.
        for(contador = 1; contador <= parteEntera2; contador++){
            resultado2 = resultado2 * contador;
        }
    }
    *punteroFactorial1 = resultado1;
    *punteroFactorial2 = resultado2;
}
void getContact(char nombre[][COLUMNAS], char apellido[][COLUMNAS], int edad[], int legajo[], int isEmpty[],int cantidadFilas){
    int edadValida;
    for(int i=0; i<cantidadFilas; i++)
    {
        if (isEmpty[i])
        {
            fflush(stdin);
            printf("\nIngrese nombre(s): ");
            fgets(nombre[i], COLUMNAS-2, stdin);
            quitarSaltoDeLinea(nombre[i]);
            fflush(stdin);
            printf("\nIngrese apellido(s): ");
            fgets(apellido[i], COLUMNAS-2, stdin);
            quitarSaltoDeLinea(apellido[i]);
            fflush(stdin);
            do{
                printf("\nIngrese edad: ");
                scanf("%d",&edad[i]);
                edadValida = validarRangoEntero(edad[i], 18, 65);
            } while (edadValida == 0);
            fflush(stdin);
            legajo[i] = i + 1;
            isEmpty[i] = 0;
            break;
        }
    }
}
void contactShow(char nombre[][COLUMNAS], char apellido[][COLUMNAS], int edad[], int legajo[], int isEmpty[], int cantidadFilas){
    int i;
    fflush(stdin);
    printf("\nLegajo\tApellido\t\tNombre\t\tEdad\n\n");
    for (i=0; i<cantidadFilas ; i++)
    {
        if (isEmpty[i] == 0)
        {
            printf("%d\t%s\t\t\t%s\t\t\%d\t%d\n",legajo[i],apellido[i],nombre[i],edad[i], isEmpty[i]);
        }
    }
    printf("\nPresione Intro para continuar...");
    getchar();
}
