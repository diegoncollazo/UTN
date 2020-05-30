#include <stdio.h>
#include <stdlib.h>

int validarRangoEntero(int valor, int limiteInferior, int limiteSuperior){
    int respuesta = 0;
    if (valor > limiteInferior && valor < limiteSuperior){
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
    return 0;
}
