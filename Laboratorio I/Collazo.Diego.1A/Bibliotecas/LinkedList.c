#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "LinkedList.h"
#include "Employee.h"
static Node* getNode(LinkedList* this, int nodeIndex);
static int addNode(LinkedList* this, int nodeIndex,void* pElement);
/** \brief Crea un nuevo LinkedList en memoria de manera dinamica
 *
 *  \param void
 *  \return LinkedList* Retorna (NULL) en el caso de no conseguir espacio en memoria
 *                      o el puntero al espacio reservado
 */
LinkedList* ll_newLinkedList(void){
    LinkedList* this;
    this = (LinkedList *)malloc(sizeof(LinkedList));
    if (this != NULL){
        this->size=0;
        this->pFirstNode = NULL;
    }
    return this;
}
/** \brief Retorna la cantidad de elementos de la lista
 *
 * \param this LinkedList* Puntero a la lista
 * \return int Retorna (-1) si el puntero es NULL o la cantidad de elementos de la lista
 *
 */
int ll_len(LinkedList* this){
    int returnAux = -1;
    if (this != NULL && this->size >= 0)
        returnAux = this->size;
    return returnAux;
}
/** \brief  Obtiene un nodo de la lista
 *
 * \param this LinkedList* Puntero a la lista
 * \param index int Indice del nodo a obtener
 * \return Node* Retorna  (NULL) Error: si el puntero a la lista es NULL o (si el indice es menor a 0 o mayor al len de la lista)
                        (pElement) Si funciono correctamente
 *
 */
static Node* getNode(LinkedList* this, int nodeIndex){
    Node* pNode = NULL;
    int i;
    if (nodeIndex >= 0){
        if ((this != NULL) && (this->pFirstNode != NULL) && (nodeIndex < this->size)){
            pNode = this->pFirstNode;
            for (i=0; i < (this->size); i++){
                if (pNode->pNextNode == NULL || nodeIndex == i)
                    break;
                else
                    pNode = pNode->pNextNode;
            }
        }
    }
    return pNode;
}
/** \brief  Permite realizar el test de la funcion getNode la cual es privada
 *
 * \param this LinkedList* Puntero a la lista
 * \param index int Indice del nodo a obtener
 * \return Node* Retorna  (NULL) Error: si el puntero a la lista es NULL o (si el indice es menor a 0 o mayor al len de la lista)
                        (pElement) Si funciono correctamente
 *
 */
Node* test_getNode(LinkedList* this, int nodeIndex){
    return getNode(this, nodeIndex);
}
/** \brief Agrega y enlaza un nuevo nodo a la lista
 *
 * \param this LinkedList* Puntero a la lista
 * \param nodeIndex int Ubicacion donde se agregara el nuevo nodo
 * \param pElement void* Puntero al elemento a ser cobreakntenido por el nuevo nodo
 * \return int Retorna  (-1) Error: si el puntero a la lista es NULL o (si el indice es menor a 0 o mayor al len de la lista)
                        ( 0) Si funciono correctamente
 *
 */
static int addNode(LinkedList* this, int nodeIndex, void* pElement){
    Node* pNode = NULL;
    int returnAux = -1;
    if ((this != NULL) &&  (nodeIndex >=0) && (nodeIndex <= this->size)){
        Node* pNodeAux = malloc(sizeof(Node));
        if (this->pFirstNode == NULL && nodeIndex == 0){
            this->pFirstNode = pNodeAux;
            pNodeAux->pElement = pElement;
            pNodeAux->pNextNode = NULL;
        }
        else{
            pNode = getNode(this, nodeIndex-1);
            pNodeAux->pNextNode = pNode;
            pNode->pNextNode = pNodeAux;
            pNodeAux->pElement = pElement;
        }
        this->size++;
        returnAux = 0;
    }
    return returnAux;
}
/** \brief Permite realizar el test de la funcion addNode la cual es privada
 *
 * \param this LinkedList* Puntero a la lista
 * \param nodeIndex int Ubicacion donde se agregara el nuevo nodo
 * \param pElement void* Puntero al elemento a ser contenido por el nuevo nodo
  * \return int Retorna  (-1) Error: si el puntero a la lista es NULL o (si el indice es menor a 0 o mayor al len de la lista)
                        ( 0) Si funciono correctamente
 *
 */
int test_addNode(LinkedList* this, int nodeIndex,void* pElement){
    return addNode(this,nodeIndex,pElement);
}
/** \brief  Agrega un elemento a la lista
 * \param pList LinkedList* Puntero a la lista
 * \param pElement void* Puntero al elemento a ser agregado
 * \return int Retorna  (-1) Error: si el puntero a la lista es NULL
                        ( 0) Si funciono correctamente
 *
 */
int ll_add(LinkedList* this, void* pElement){
    int returnAux = -1;
    if(this != NULL ){
        addNode(this, this->size , pElement);
        returnAux = 0;
    }
    return returnAux;
}
/** \brief Permite realizar el test de la funcion addNode la cual es privada
 *
 * \param this LinkedList* Puntero a la lista
 * \param nodeIndex int Ubicacion del elemento a obtener
 * \return void* Retorna    (NULL) Error: si el puntero a la lista es NULL o (si el indice es menor a 0 o mayor al len de la lista)
                            (pElement) Si funciono correctamente
 *
 */
void* ll_get(LinkedList* this, int index){
    Node* pNode = NULL;
    void* returnAux = NULL;
    if (this != NULL){
        if (index >= 0 && index < this->size){
            pNode = getNode(this, index);
            if (pNode != NULL)
                returnAux = pNode->pElement;
        }
    }
    return returnAux;
}
/** \brief Modifica un elemento de la lista
 *
 * \param this LinkedList* Puntero a la lista
 * \param nodeIndex int Ubicacion del elemento a modificar
 * \param pElement void* Puntero al nuevo elemento
 * \return int Retorna  (-1) Error: si el puntero a la lista es NULL o (si el indice es menor a 0 o mayor al len de la lista)
                        ( 0) Si funciono correctamente
 *
 */
int ll_set(LinkedList* this, int index,void* pElement){
    Node* pNode = NULL;
    int returnAux = -1;
    pNode = getNode(this, index);
    if (pNode != NULL){
        pNode->pElement = pElement;
        returnAux = 0;
    }
    return returnAux;
}
/** \brief Elimina un elemento de la lista
 *
 * \param this LinkedList* Puntero a la lista
 * \param nodeIndex int Ubicacion del elemento a eliminar
 * \return int Retorna  (-1) Error: si el puntero a la lista es NULL o (si el indice es menor a 0 o mayor al len de la lista)
                        ( 0) Si funciono correctamente
 *
 */
int ll_remove(LinkedList* this, int index){
    Node* pNode = NULL;
    Node* pPreviousNode = NULL;
    int returnAux = -1;
    if (this != NULL && index >= 0 && index < this->size){
        pNode = getNode(this, index);
        if (index == 0){
            this->pFirstNode = NULL;
        }
        else if (index > 0){
            pPreviousNode = getNode(this, index-1);
            pPreviousNode->pNextNode = pNode->pNextNode;
        }
        free(pNode);
        this->size--;
        returnAux = 0;
    }
    return returnAux;
}
/** \brief Elimina todos los elementos de la lista
 *
 * \param this LinkedList* Puntero a la lista
 * \return int Retorna  (-1) Error: si el puntero a la lista es NULL
                        ( 0) Si funciono correctamente
 *
 */
int ll_clear(LinkedList* this){
    int returnAux = -1, i;
    if (this != NULL){
        for (i = (this->size-1) ; i>=0; i--)
            ll_remove(this, i);
        returnAux = 0;
    }
    return returnAux;
}
/** \brief Elimina todos los elementos de la lista y la lista
 *
 * \param this LinkedList* Puntero a la lista
 * \return int Retorna  (-1) Error: si el puntero a la lista es NULL
                        ( 0) Si funciono correctamente
 *
 */
int ll_deleteLinkedList(LinkedList* this){
    int returnAux = -1;
    if (this != NULL){
        ll_clear(this);
        free(this);
        returnAux = 0;
    }
    return returnAux;
}
/** \brief Busca el indice de la primer ocurrencia del elemento pasado como parametro
 *
 * \param this LinkedList* Puntero a la lista
 * \param pElement void* Puntero al elemento
 * \return int Retorna  (-1) Error: si el puntero a la lista es NULL
                        (indice del elemento) Si funciono correctamente
 *
 */
int ll_indexOf(LinkedList* this, void* pElement){
    void* pAuxElement = NULL;
    int returnAux = -1, i;
    if (this != NULL ){
        for (i=0; i<this->size; i++){
            if ((pAuxElement = ll_get(this, i)) == pElement){
                returnAux = i;
                break;
            }
        }
    }
    return returnAux;
}
/** \brief Indica si la lista esta o no vacia
 *
 * \param this LinkedList* Puntero a la lista
 * \return int Retorna  (-1) Error: si el puntero a la lista es NULL
                        ( 0) Si la lista NO esta vacia
                        ( 1) Si la lista esta vacia
 *
 */
int ll_isEmpty(LinkedList* this){
    int returnAux = -1;
    if (this != NULL ){
        if (this->pFirstNode != NULL)
            returnAux = 0;
        else
            returnAux = 1;
    }
    return returnAux;
}
/** \brief Inserta un nuevo elemento en la lista en la posicion indicada
 *
 * \param this LinkedList* Puntero a la lista
 * \param nodeIndex int Ubicacion donde se agregara el nuevo elemento
 * \param pElement void* Puntero al nuevo elemento
 * \return int Retorna  (-1) Error: si el puntero a la lista es NULL o (si el indice es menor a 0 o mayor al len de la lista)
                        ( 0) Si funciono correctamente
 *
 */
int ll_push(LinkedList* this, int index, void* pElement){
    int returnAux = -1;
    returnAux = addNode(this, index, pElement);
    return returnAux;
}
/** \brief Elimina el elemento de la posicion indicada y retorna su puntero
 *
 * \param this LinkedList* Puntero a la lista
 * \param nodeIndex int Ubicacion del elemento eliminar
 * \return void* Retorna    (NULL) Error: si el puntero a la lista es NULL o (si el indice es menor a 0 o mayor al len de la lista)
                            (pElement) Si funciono correctamente
 *
 */
void* ll_pop(LinkedList* this, int index){
    void* returnAux = NULL;
    returnAux = ll_get(this, index);
    ll_remove(this, index);
    return returnAux;
}
/** \brief  Determina si la lista contiene o no el elemento pasado como parametro
 *
 * \param this LinkedList* Puntero a la lista
 * \param pElement void* Puntero del elemento a verificar
 * \return int Retorna  (-1) Error: si el puntero a la lista es NULL
                        ( 1) Si contiene el elemento
                        ( 0) si No contiene el elemento
*/
int ll_contains(LinkedList* this, void* pElement){
    int returnAux = -1, index;
    if (this != NULL){
        index = ll_indexOf(this, pElement);
        if (index != -1)
            returnAux = 1;
        else
            returnAux = 0;
    }
    return returnAux;
}
/** \brief  Determina si todos los elementos de la lista (this2)
            estan contenidos en la lista (this)
 *
 * \param this LinkedList* Puntero a la lista
 * \param this2 LinkedList* Puntero a la lista
 * \return int Retorna  (-1) Error: si alguno de los punteros a las listas son NULL
                        ( 1) Si los elementos de (this2) estan contenidos en la lista (this)
                        ( 0) si los elementos de (this2) NO estan contenidos en la lista (this)
*/
int ll_containsAll(LinkedList* this, LinkedList* this2){
    int returnAux = -1, i;
    if (this != NULL && this2 != NULL){
        for (i=0; i<this->size; i++)
            returnAux = ll_contains(this2, ll_get(this, i));
        if (returnAux == -1)
            returnAux = 0;
    }
    return returnAux;
}
/** \brief Crea y retorna una nueva lista con los elementos indicados
 *
 * \param pList LinkedList* Puntero a la lista
 * \param from int Indice desde el cual se copian los elementos en la nueva lista
 * \param to int Indice hasta el cual se copian los elementos en la nueva lista (no incluido)
 * \return LinkedList* Retorna  (NULL) Error: si el puntero a la listas es NULL
                                o (si el indice from es menor a 0 o mayor al len de la lista)
                                o (si el indice to es menor o igual a from o mayor al len de la lista)
                         (puntero a la nueva lista) Si ok
*/
LinkedList* ll_subList(LinkedList* this, int from, int to){
    LinkedList* cloneArray = NULL;
    int i;
    if (this != NULL)
        if (from >= 0 && to <= this->size)
            cloneArray = ll_newLinkedList();
            if (cloneArray != NULL)
                for (i=from ; i < to; i++)
                    ll_add(cloneArray, ll_get(this, i));
    return cloneArray;
}
/** \brief Crea y retorna una nueva lista con los elementos de la lista pasada como parametro
 *
 * \param pList LinkedList* Puntero a la lista
 * \return LinkedList* Retorna  (NULL) Error: si el puntero a la listas es NULL
                                (puntero a la nueva lista) Si ok
*/
LinkedList* ll_clone(LinkedList* this){
    LinkedList* cloneArray = NULL;
    if (this != NULL)
        cloneArray = ll_subList(this, 0, this->size);
    return cloneArray;
}
/** \brief Ordena los elementos de la lista utilizando la funcion criterio recibida como parametro
 * \param pList LinkedList* Puntero a la lista
 * \param pFunc (*pFunc) Puntero a la funcion criterio
 * \param order int  [1] Indica orden ascendente - [0] Indica orden descendente
 * \return int Retorna  (-1) Error: si el puntero a la listas es NULL
                                ( 0) Si ok
 */
int ll_sort(LinkedList* this, int (*pFunc)(void* ,void*), int order){
    Node* pNodeUno = NULL;
    Node* pNodeDos = NULL;
    Node* pNodeAux = NULL;
    int returnAux = -1, i ,j;
    if(this != NULL && pFunc != NULL && (order == 1 || order == 0)){
        for(i=0; i<(this->size-1); i++){
            pNodeUno = ll_get(this, i);
            for(j=i+1; j<this->size; j++){
                pNodeDos = ll_get(this, j);
                if(order){
                    if(pFunc(pNodeUno, pNodeDos) > 0){
                        pNodeAux = pNodeDos;
                        pNodeDos = pNodeUno;
                        pNodeUno = pNodeAux;
                    }
                }
                else{
                    if(pFunc(pNodeUno, pNodeDos) < 0){
                        pNodeAux = pNodeUno;
                        pNodeUno = pNodeDos;
                        pNodeDos = pNodeAux;
                    }
                }
                ll_set(this, i, pNodeUno);
                ll_set(this, j, pNodeDos);
            }
        }
        returnAux = 0;
    }
    return returnAux;
}
/** \brief Filtra los elementos de la lista utilizando la funcion criterio recibida como parametro
 *
 * \param this LinkedList* Puntero a la lista
 * \param pFunc (*pFunc) Puntero a la funcion criterio
 * \return LinkedList* Retorna (NULL) en el caso de no conseguir espacio en memoria
 *                      o el puntero al espacio reservado
 */
LinkedList* ll_filter(LinkedList* this, int (*pFunc)(void*)){
    LinkedList* filterList;
    int i;
    if (this != NULL){
        filterList = ll_newLinkedList();
        if (filterList != NULL){
            for (i=0; i<this->size; i++){
                if (pFunc(ll_get(this, i))){
                    ll_add(filterList, ll_get(this, i));
                }
            }
        }
    }
    return filterList;
}

LinkedList* ll_map(LinkedList* this, int (*pFunc)(void*,float*)){
    LinkedList* filterList;
    Employee* auxEmpleado = employee_new();
    float sueldo;
    int i;
    if (this != NULL){
        filterList = ll_newLinkedList();
        if (filterList != NULL){
            for (i=0; i<this->size; i++){
                auxEmpleado = (Employee*)ll_get(this, i);
                pFunc(auxEmpleado, &sueldo);
                if (sueldo != -1){/**< Compruebo que el sueldo fue calculado */
                    auxEmpleado = (Employee*)ll_get(this, i);
                    auxEmpleado->sueldo = sueldo;
                    ll_add(filterList, auxEmpleado);
                }
            }
        }
    }
    return filterList;
}
