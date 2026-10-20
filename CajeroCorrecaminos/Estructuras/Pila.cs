using System.Collections;

namespace CajeroCorrecaminos.Estructuras
{    
    // Pila (LIFO: último en entrar, primero en salir)
    // Guarda las operaciones reversibles (depósitos y transferencias):
    // la última que se hizo es la primera que se puede revertir.
    public class Pila<T> : IEnumerable<T>
    {
        private Nodo<T>? tope;

        public int Cantidad { get; private set; }

        public bool EstaVacia => tope == null;

        // Función: coloca un elemento encima de la pila.
        public void Apilar(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);
            nuevo.Siguiente = tope;
            tope = nuevo;
            Cantidad++;
        }

        // Función: Saca y devuelve el elemento del tope
        public T Desapilar()
        {
            if (tope == null)
                throw new InvalidOperationException("La pila está vacía.");

            T dato = tope.Dato;
            tope = tope.Siguiente;
            Cantidad--;
            return dato;
        }

        //Función: mira el elemento del tope sin sacarlo. (peek)
        public T VerTope()
        {
            if (tope == null)
                throw new InvalidOperationException("La pila está vacía.");

            return tope.Dato;
        }

        //Vaciar la pila
        public void Vaciar()
        {
            tope = null;
            Cantidad = 0;
        }

        //Recorre desde el primero hacia el fondo (solo para mostrarla en pantalla)
        public IEnumerator<T> GetEnumerator()
        {
            Nodo<T>? actual = tope;
            while (actual != null)
            {
                yield return actual.Dato;
                actual = actual.Siguiente;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
