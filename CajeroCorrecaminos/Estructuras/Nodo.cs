namespace CajeroCorrecaminos.Estructuras
{

    // Declaracion de los Nodos y punteros 
    // Se usará de base para las listas enlazadas y pilas   
    public class Nodo<T>
    {
        public T Dato;
        public Nodo<T>? Siguiente;

        public Nodo(T dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}
