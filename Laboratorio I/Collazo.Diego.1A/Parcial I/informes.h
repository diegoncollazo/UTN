#ifndef INFORMES_H_INCLUDED
#define INFORMES_H_INCLUDED
/**< Acumulador & Contador */
int promedioImportes(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes, float *pPromedio, float *pAcumulador, int *pContador);
/**< Punto A */
void promedioTotal(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes);
/**< Punto B */
void juegosNoSuperenPromedio(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes);
/**< Punto C */
void listarClientesPorJuego(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes);
/**< Punto D */
void listarJuegosPorCliente(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes);
/**< Punto E */
void listarJuegoMenosAlquilado(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos);
/**< Punto F */
void listarClientesConMasAlquileres(eAlquileres *pAlquileres, int largoAlquileres, eCliente *pClientes, int largoClientes);
/**< Punto G */
void listarJuegosPorFecha(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes);
/**< Punto H */
void listarClientesPorFecha(eAlquileres *pAlquileres, int largoAlquileres, eJuego *pJuegos, int largoJuegos, eCliente *pClientes, int largoClientes);
/**< Punto I */
void listarJuegoPorBurbujeo(eJuego *pJuego, int largoJuegos);
/**< Punto J */
void ordenarClientesPorInsercion(eCliente *pClientes, int largoClientes);
#endif // INFORMES_H_INCLUDED
