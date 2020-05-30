#ifndef CLIENTES_H_INCLUDED
#define CLIENTES_H_INCLUDED

#define CANT_CLIENTES 100
#define LARGO 51

typedef struct{
    int codigoCliente;
    char nombre[LARGO];
    char apellido[LARGO];
    char domicilio[LARGO];
    char sexo;
    int isEmpty;
}eCliente;

int borrarCliente(eCliente *list, int largoClientes);
int buscarCliente(eCliente *list, int largoClientes, int codigoCliente);
int inicializarClientes(eCliente *pClientes, int largoClientes);
int listarCliente(eCliente juego);
int listarClientes(eCliente *list, int largoClientes);
int modificarCliente(eCliente *list, int largoClientes);
int nuevoCliente(eCliente *list, int largoCliente, int indice);
int nuevoIdCliente(void);
int posicionLibreCliente(eCliente *list, int largoCliente);

#endif // CLIENTES_H_INCLUDED
