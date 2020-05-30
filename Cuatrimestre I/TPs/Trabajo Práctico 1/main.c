#include <stdio.h>
#include <stdlib.h>
#include "Biblioteca DNC.h"

int main(){
    int control, bandera1=0, bandera2=0, bandera3=0, bandera4=0;
    float operador1=0, operador2=0, resultadoSuma, resultadoResta, resultadoDivision, resultadoMultiplicacion;
    float resultadoFactorial1, resultadoFactorial2;
    do{
        system("cls");
        printf("\nCalculadora v1.0 by DNC.\n");
        printf("\n1. Ingresar 1er operando (A=%.2f).\n", operador1);
        printf("\n2. Ingresar 2do operando (B=%.2f).\n", operador2);
        printf("\n3. Calcular todas las operaciones.\n");
        printf("\n  a) Calcular la suma (A+B).");
        printf("\n  b) Calcular la resta (A-B).");
        printf("\n  c) Calcular la division (A/B).");
        printf("\n  d) Calcular la multiplicacion (A*B).");
        printf("\n  e) Calcular el factorial (A!) & (!B).\n");
        printf("\n4. Informar resultados.\n");
        if (bandera3==1 && bandera4==1){
            printf("\n  a) El resultado de A+B es: %.3f\t",resultadoSuma);
            printf("\n  b) El resultado de A-B es: %.3f\t",resultadoResta);
            if (operador2 == 0){
                printf("\n  c) No es posible dividir por cero");
            }
            else{
                printf("\n  c) El resultado de A/B es: %.3f\t",resultadoDivision);
            }
            printf("\n  d) El resultado de A*B es: %.3f\t",resultadoMultiplicacion);
            printf("\n  e) El factorial de A es: %.3f y El factorial de B es: %.3f\t\n",resultadoFactorial1, resultadoFactorial2);
        }
        printf("\n5. Salir de la calculadora: ");
        scanf("%d",&control); //Elijo opcion del menu
        switch(control){
        case 1: //Operando 1
            printf("\nIngrese 1er operando: ");
            scanf("%f",&operador1);
            if (bandera1==1){
                bandera3=0;
                bandera4=0;
            }
            else{
                bandera1=1;
            }
            break;
        case 2: //Operando 2
            printf("\nIngrese 2do operando: ");
            scanf("%f",&operador2);
            if (bandera2==1){
                bandera3=0;
                bandera4=0;
            }
            else{
                bandera2=1;
            }
            break;
        case 3: //Calculos
            if (bandera1==1 && bandera2==1){
                resultadoSuma = suma(operador1,operador2);
                resultadoResta = resta(operador1, operador2);
                resultadoDivision = division(operador1,operador2);
                resultadoMultiplicacion = multiplicacion(operador1,operador2);
                resultadoFactorial1 = factorial(operador1);
                resultadoFactorial2 = factorial(operador2);
                bandera3 = 1;
            }
            else{
                printf("\n¡Falta alguno de lo operandos!\n");//Faltaría una pausa.
            }
            break;
        case 4: //Informes
            if (bandera3==1){
                bandera4=1;
            }
            break;
        case 5: //Salir
            printf("\nGracias por utilizar la calculadora.");
            break;
        default:
            break;
        }
    }while (control != 5);
    return 0;
}
