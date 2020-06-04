/* Programa: Validar fecha (Solución 1) */
#include <conio.h>
#include <stdio.h>

int main(){
    int dia, mes, anio, retorno = 0;
    printf( "\nIntroduzca d%ca: ", 161 );
    scanf( "%d", &dia );
    printf( "\nIntroduzca mes: " );
    scanf( "%d", &mes );
    printf( "\nIntroduzca a%co: ", 164 );
    scanf( "%d", &anio );
    if ( mes >= 1 && mes <= 12 ){
        switch (mes){
        case  1 :
        case  3 :
        case  5 :
        case  7 :
        case  8 :
        case 10 :
        case 12 :
            if (dia >= 1 && dia <= 31)
                printf( "\nFecha incorrecta" );
            else
                printf( "\nFecha incorrecta" );
            break;
        case  4 :
        case  6 :
        case  9 :
        case 11 :
            if ( dia >= 1 && dia <= 30 )
                printf( "\nFecha incorrecta" );
            else
                printf( "\nFecha incorrecta" );
            break;
        case  2 :
            if ( (anio % 4 == 0) && (anio % 100 != 0) || (anio % 400 == 0) )
                if ( dia >= 1 && dia <= 29 )
                    printf( "\nFecha incorrecta" );
                else
                    printf( "\nFecha incorrecta" );
            else if ( dia >= 1 && dia <= 28 )
                printf( "\nFecha incorrecta" );
            else
                printf( "\nFecha incorrecta" );
        }
    }
    else
        printf( "\nFecha incorrecta" );
    return retorno;
}
