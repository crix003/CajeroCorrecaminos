using System.Collections;

namespace CajeroCorrecaminos.Estructuras
{
    // Lista Enlazada simple
    // registro de cuentas e historial de movimientos.
    public class ListaEnlazada<T> : IEnumerable<T>
    {
        private Nodo<T>? cabeza;
        private Nodo<T>? ultimo;

        public int Cantidad { get; private set; }

        public bool EstaVacia => cabeza == null;

        //Posiciona lo más reciente "primero" en historial
        public void AgregarInicio(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);
            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
            if (ultimo == null) ultimo = nuevo;
            Cantidad++;
        }

        //Inserta al final, se guarda el puntero al último nodo
        public void AgregarFinal(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);
            if (cabeza == null)
            {
                cabeza = nuevo;
                ultimo = nuevo;
            }
            else
            {
                ultimo!.Siguiente = nuevo;
                ultimo = nuevo;
            }
            Cantidad++;
        }

        // Busca el primer elemento que cumpla la condición (recorrido lineal)
        public T? Buscar(Func<T, bool> condicion)
        {
            Nodo<T>? actual = cabeza;
            while (actual != null)
            {
                if (condicion(actual.Dato)) return actual.Dato;
                actual = actual.Siguiente;
            }
            return default;
        }

        public bool EliminarPrimero(Func<T, bool> condicion)
        {
            Nodo<T>? anterior = null;
            Nodo<T>? actual = cabeza;

            while (actual != null)
            {
                if (condicion(actual.Dato))
                {
                    if (anterior == null)
                        cabeza = actual.Siguiente;
                    else
                        anterior.Siguiente = actual.Siguiente;

                    if (actual == ultimo)
                        ultimo = anterior;

                    Cantidad--;
                    return true;
                }

                anterior = actual;
                actual = actual.Siguiente;
            }

            return false;
        }

        //Función para limpiar la lista enlazada
        public void Limpiar()
        {
            cabeza = null;
            ultimo = null;
            Cantidad = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Nodo<T>? actual = cabeza;
            while (actual != null)
            {
                yield return actual.Dato;
                actual = actual.Siguiente;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
