#ifndef ALQUILERES_H_INCLUDED
#define ALQUILERES_H_INCLUDED

#define CANT_ALQUILERES 2000

#include "clientes.h"
#include "juegos.h"

typedef struct{
    int day;
    int month;
    int year;
}eFecha;

typedef struct{
    int codigoAlquiler;
    int codigoJuego;
    int codigoCliente;
    eFecha fechaAlquiler;
    int isEmpty;
}eAlquileres;

int inicializarAlquileres(eAlquileres *pAlquileres, int largoAlquileres);
void listarAlquiler(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes);
int nuevoAlquilerJuego(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes, int indiceAlquiler);
int nuevoCodigoAlquiler(void);
int posicionLibreAlquiler(eAlquileres *pAlquileres, int largoAlquileres);

#endif // ALQUILERES_H_INCLUDED
