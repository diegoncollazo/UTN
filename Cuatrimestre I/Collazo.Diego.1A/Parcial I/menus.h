#ifndef MENUS_H_INCLUDED
#define MENUS_H_INCLUDED
void hardCodingData(eAlquileres *pAlquileres, eJuego *pJuegos, eCliente *pClientes);
void menuAlquileres(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes, int hayClientes, int hayJuegos);
void menuClientes(eCliente *pClientes, int largoCliente, int *hayClientes);
void menuJuegos(eJuego *pJuegos, int largoJuego, int *hayJuegos);
void menuInformes(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes, int hayClientes, int hayJuegos);
int sinClientes(eCliente *pClientes, int largoClientes);
int sinJuegos(eJuego *pJuegos, int largoJuegos);
#endif // MENUS_H_INCLUDED
