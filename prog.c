#include <stdio.h>
#include <stdlib.h>

#define bool int
/**********************************************************************/
// Definición del tamaño de la cola
/**********************************************************************/

#define MAX 10000
#define FALSE 0
#define TRUE 1 

//typedef int bool;

typedef  struct {
    char nombre[11];
} TCliente;

typedef  TCliente T;

// Definición del la estructura de la Pila
typedef struct{
    int tam; //Tamaño de la pila
    int tope;
    T *elementos; //Datos de la pila con apuntador
} Tpila;
//Iniciar Pila
void iniciarPila(Tpila *pila, int N){
    pila->elementos= (T *) malloc(sizeof(T)*N);
    pila->tam=N;
    pila->tope=-1;
}
// Agregar un dato a la Pila
void agregarPila(Tpila *pila, T dato){
    pila->tope++;
    pila->elementos[pila->tope]=dato;
}

// Extraer un dato de la Pila
T extraerPila(Tpila *pila){
    T dato;
    dato = pila->elementos[pila->tope];
    pila->tope--;
    return dato;
}
//Obtener dato del tope sin extraerlo
T obtenerElementoTopePila(Tpila pila){
return pila.elementos[pila.tope];
}

//Determina si la Pila esta vacía
int vaciaPila(Tpila pila){
    return(pila.tope==-1)?TRUE:FALSE;
}
//Determina si la Pila esta llena
int llenaPila(Tpila pila){
    return(pila.tope==pila.tam-1)?TRUE:FALSE;
}

//Obtiene numero de elementos de la Pila
int numElementosPila(Tpila pila){
    return pila.tope+1;
}
//Obtiene un elemento de la Pila de alguna posición
T obtenerElementoPila(Tpila pila, int pos){
    return pila.elementos[pos];
}

/**********************************************************************/
// Definición de la estructura de datos Cola
/**********************************************************************/

typedef struct{
    int frente, final;
    T elementos[MAX];
} TCola;

//Inicializa una cola
void iniciarCola(TCola *cola){
    cola->frente=0;
    cola->final=-1;
}
// Agrega un dato a la cola
void agregarCola(TCola *cola, T dato){
    cola->final++;
    cola->elementos[cola->final]=dato;
}

// Extrae un dato de la cola
T extraerCola(TCola *cola){
int i;

T dato = cola->elementos[cola->frente];
    
    for(i=0; i<cola->final; i++)
        cola->elementos[i]=cola->elementos[i+1];
    
    cola->final--;    
   // printf("%s", cola->elementos[cola->frente].nombre);
    return dato;
}
// Obtiene el dato del frente de la cola sin extraer
T obtenerElementoFrenteCola(TCola cola){
    return  cola.elementos[cola.frente];
}

// Determina si la cola esta vacía
bool vaciaCola(TCola cola){
    return(cola.final==-1)?TRUE:FALSE;
}
// Determina si la cola esta llena
bool llenaCola(TCola cola){
    return(cola.final==MAX-1)?TRUE:FALSE;
}

// Obtiene numero de elementos de la cola
bool numElementosCola(TCola cola){
return cola.final+1;
}
// Obtiene un elemento de la cola de una posición
T obtenerElementoCola(TCola cola, int pos){
    return cola.elementos[pos];
}

int main()
{
    Tpila pila;
    TCola cola;
    TCliente cliente;
    int N, i, tipo;
    char op;
    
    iniciarPila(&pila, MAX);
     iniciarCola(&cola);

    //printf("Numero:");
    scanf("%d", &N);
    for (i=0; i<N ;i++){
        getchar();
        scanf("%c", &op);
        switch(op){
            case 'E':
                scanf("%d%s", &tipo, cliente.nombre);

                if (tipo==1)
                    agregarCola(&cola, cliente);
                else
                    agregarPila(&pila, cliente);
                break;
            
            case 'A':
                              
                    scanf("%d", &tipo);
                    
                    if (tipo==1){
                        cliente = extraerCola(&cola); 
                    }   
                    else
                        cliente = extraerPila(&pila);
                        
                    printf ("%s\n",cliente.nombre);
                break;
        }
    }
    

    return 0;
}
