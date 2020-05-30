#ifndef JUEGOS_H_INCLUDED
#define JUEGOS_H_INCLUDED
#define CANT_JUEGOS 100
#define LARGO 51
typedef struct{
    int codigoJuego;
    char descripcion[LARGO] ;
    float importeJuego;
    int isEmpty;
}eJuego;
int borrarJuego(eJuego *misJuegos, int largoJuegos);
int buscarJuego(eJuego *misJuegos, int largoJuegos, int codigoJuego);
int inicializarJuegos(eJuego *pJuegos, int largoJuegos);
int listarJuego(eJuego juego);
int listarJuegos(eJuego *misJuegos, int largoJuegos);
int modificarJuego(eJuego *misJuegos, int largoJuegos);
int nuevoJuego(eJuego *misJuegos, int largoJuego, int indice);
int nuevoIdJuego(void);
int ordenarJuegos(eJuego *misJuegos, int largoJuegos);
int posicionLibreJuego(eJuego *misJuegos, int largoJuego);
#endif // JUEGOS_H_INCLUDED
