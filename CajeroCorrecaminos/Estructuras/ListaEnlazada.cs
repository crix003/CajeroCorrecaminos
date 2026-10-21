using System.Collections;

namespace CajeroCorrecaminos.Estructuras
{
    // Lista Doblemente Enlazada
    public class ListaEnlazada<T> : IEnumerable<T>
    {
        private Nodo<T>? cabeza;
        private Nodo<T>? ultimo;

        public int Cantidad { get; private set; }

        public bool EstaVacia => cabeza == null;

        // Posiciona el nuevo elemento al inicio (Cabeza)
        public void AgregarInicio(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);

            if (cabeza == null)
            {
                cabeza = nuevo;
                ultimo = nuevo;
            }
            else
            {
                nuevo.Siguiente = cabeza;
                cabeza.Anterior = nuevo; // Se establece el enlace hacia atrás
                cabeza = nuevo;
            }

            Cantidad++;
        }

        // Inserta al final usando el puntero 'ultimo'
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
                nuevo.Anterior = ultimo; // Se establece el enlace hacia atrás
                ultimo = nuevo;
            }

            Cantidad++;
        }

        // Busca el primer elemento que cumpla la condición (recorrido lineal hacia adelante)
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

        // Elimina el primer elemento que cumpla la condición reconectando ambos enlaces
        public bool EliminarPrimero(Func<T, bool> condicion)
        {
            Nodo<T>? actual = cabeza;

            while (actual != null)
            {
                if (condicion(actual.Dato))
                {
                    // Si es la cabeza
                    if (actual == cabeza)
                    {
                        cabeza = actual.Siguiente;
                        if (cabeza != null)
                            cabeza.Anterior = null;
                    }
                    else
                    {
                        actual.Anterior!.Siguiente = actual.Siguiente;
                    }

                    // Si es el último nodo
                    if (actual == ultimo)
                    {
                        ultimo = actual.Anterior;
                        if (ultimo != null)
                            ultimo.Siguiente = null;
                    }
                    else if (actual.Siguiente != null)
                    {
                        actual.Siguiente.Anterior = actual.Anterior;
                    }

                    Cantidad--;
                    return true;
                }

                actual = actual.Siguiente;
            }

            return false;
        }

        // Limpia la lista reseteando las referencias
        public void Limpiar()
        {
            cabeza = null;
            ultimo = null;
            Cantidad = 0;
        }

        // Enumerador para recorrer del primero al último (de cabeza a último)
        public IEnumerator<T> GetEnumerator()
        {
            Nodo<T>? actual = cabeza;
            while (actual != null)
            {
                yield return actual.Dato;
                actual = actual.Siguiente;
            }
        }

        // Nuevo método exclusivo de listas dobles: recorrer desde el último hacia la cabeza
        public IEnumerable<T> RecorrerInverso()
        {
            Nodo<T>? actual = ultimo;
            while (actual != null)
            {
                yield return actual.Dato;
                actual = actual.Anterior;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}