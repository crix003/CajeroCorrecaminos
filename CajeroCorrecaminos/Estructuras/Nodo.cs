namespace CajeroCorrecaminos.Estructuras
{
    // Declaración de los Nodos con doble enlace (Siguiente y Anterior)
    // Se utiliza en la lista enlazada y en la pila.
    public class Nodo<T>
    {
        public T Dato;
        public Nodo<T>? Siguiente;
        public Nodo<T>? Anterior;

        public Nodo(T dato)
        {
            Dato = dato;
            Siguiente = null;
            Anterior = null;
        }
    }
}
