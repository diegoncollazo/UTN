    //Listar
    printf("Legajo\tApellido\t\tNombre\t\tEdad\n\n");
    for (int i=0; i<FILAS ; i++)
    {
        if (isEmpty[i] == 0)
        {
            printf("%d\t%s\t\t%s\t\t\%d\n",legajo[i],apellido[i],nombre[i],edad[i]);
        }

    }

    //Modificar
    printf("Legajo: ");
    scanf("%d",&legajoAux);
    bandera1 = 0;
    for (i=0; i<FILAS; i++)
    {
        if (legajoAux == legajo[i])
        {
            //printf() Muestro contacto completo
//            ¿Modificar? S/N

            fflush(stdin);

            char respuesta;
            int subOpcion=0;

            scanf("%c",&respuesta);
            if (respuesta == 's')
            {
                do
                {
                    printf("Menu:");
                    printf("1.- Apellido(s):");
                    printf("2.- Nombre(s):");
                    printf("3.- Edad:");
                    printf("4.- Salir:");
                    printf("Seleccionar: ");
                    scanf("%d",&subOpcion);
                    switch(subOpcion)
                    {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        break;
                    }
                }
                while (subOpcion!=0);


            }

        }


    }
