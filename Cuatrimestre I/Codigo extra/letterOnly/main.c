#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>

///PROTOTIPOS
int lettersOnly (char cadenaAChekar[]);
/// MAIN FUNCTION



int main()
{

    char cadenaAChekar[]="julian";         ///Declara VARIABLES para test
    char cadenaAChekarDos[]="Avramides";

    int resultado;
    int resultadoDos;

/// CUERPO PRINCIPAL

    resultado = lettersOnly (cadenaAChekar);///  LLAMADA A LA FUNCION
    printf("\n Resultado en main devuelto por VALID LETTER ONLY ES: %d\n\n", resultado);

    resultadoDos= lettersOnly (cadenaAChekarDos);///  LLAMADA A LA FUNCION
    printf("\n Resultado en main devuelto por VALID LETTER ONLY ES: %d\n\n", resultadoDos);
}
///CIERRE CUERPO PRINCIPAL



/// LE VAN A PASAR UNA CADENA Y ELLA VA A DETERMINAR SI HAY SOLO LETRAS
///FUNCION SOLO LETRAS

int lettersOnly (char cadenaAChekar[])
{
    int isalpha_result;              /// HOLDS RESULT OF ISALPHA FUNCTION
    int texto_length;               ///HOLDS LENGTH OF TEXT ARRAY
    int lettersOnlyChar=1;     ///if=0 INVALID VALUE // IF=1 VALID VALUE

    texto_length=strlen (cadenaAChekar);
    for (int i=0; i<texto_length; i++)
    {
        isalpha_result=isalpha(cadenaAChekar[i]);
        if (isalpha_result==0)
        {
            lettersOnlyChar=0;
        }
    }
    return lettersOnlyChar;
}///cierre lettersOnly
