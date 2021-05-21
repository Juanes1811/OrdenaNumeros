using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenaNumeros
{
    public class Logica
    {
        private int[,] matrizValores;
        private int posicionFila, posicionColumna;

        public int[,] MatrizValores
        {
            get
            {
                return matrizValores;
            }
        }
        public int PosicionFila
        {
            get
            {
                return posicionFila;
            }
        }
        public int PosicionColumna
        {
            get
            {
                return posicionColumna;
            }
        }

        public Logica()
        {
            posicionFila = 0;
            posicionColumna = 0;

            matrizValores = new int[4, 4];
            InicializaMatrizValores();

        }

        public int[,] InicializaMatrizValores()
        {
            int valor = 0;


            //Inicialmente se asignan los números del 0 al 15 en toda la matriz
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrizValores[i, j] = valor;
                    valor++;
                }
            }

            //Luego, procedemos a cambiar los valores de posición de manera aleatoria

            Random aleatorio = new Random();
            int posicionHorizontal, posicionVertical, valorTemporal;

            //Aqui desordenamos la matriz, calculando posiciones horizontales y
            //verticales dentro de la matriz
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    valorTemporal = matrizValores[i, j];
                    posicionHorizontal = aleatorio.Next(4);
                    posicionVertical = aleatorio.Next(4);

                    matrizValores[i, j] = matrizValores[posicionHorizontal, posicionVertical];
                    matrizValores[posicionHorizontal, posicionVertical] = valorTemporal;
                }
            }


            int[,] referenciaOrdenada = new int[4, 4];
            int[] numerosordenados = new int[16];
            int valores = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    numerosordenados[valores++] = matrizValores[i, j];
                }
            }
            int datoTemporal;
            bool seHizoCambio = true;
            while (seHizoCambio == true)
            {
                seHizoCambio = false;
                for (int i = 0; i < numerosordenados.Length - 1; i++)
                {
                    if (numerosordenados[i] > numerosordenados[i + 1])
                    {
                        datoTemporal = numerosordenados[i + 1];
                        numerosordenados[i + 1] = numerosordenados[i];
                        numerosordenados[i] = datoTemporal;
                        seHizoCambio = true;
                    }
                }
            }
            valores = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    referenciaOrdenada[i, j] = numerosordenados[valores++];
                }
            }

            return referenciaOrdenada;
        }
        public bool EvaluaCondicionVictoria()
        {
            //Partimos del supuesto que ya logramos la condición de victoria
            bool condicionVictoria = true;

            int valorBuscado = 0;

            //Aqui recorremos la matriz de valores buscando para cada posición si el valor está en orden
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //incrementamos el valor buscado
                    valorBuscado++;

                    //Si los valores son diferentes, entonces todavía necesitamos seguir jugando!!!
                    if (matrizValores[i, j] != valorBuscado)
                    {
                        // Validamos si estamos en la última casilla, el valor existente es 0,
                        // el valor buscado ya llegó a 16 y la condición de victoria sigue siendo true
                        if (matrizValores[i, j] == 0 && valorBuscado == 16 && condicionVictoria == true)
                            condicionVictoria = true;

                        // De lo contrario, es porque estamos en cualquier otra casilla y los valores
                        // Todavía no son iguales
                        else
                            condicionVictoria = false;
                    }
                }
            }
            return condicionVictoria;
        }
        public void EvaluaPosicion(int datofila, int datocolumna)
        {

            int valorTemporal = 0;

            //Validamos el valor superior a donde presionamos si está el cero
            if (datofila > 0)
            {
                if (matrizValores[datofila - 1, datocolumna] == 0)
                {
                    valorTemporal = matrizValores[datofila, datocolumna];
                    matrizValores[datofila, datocolumna] = 0;
                    matrizValores[datofila - 1, datocolumna] = valorTemporal;
                }
            }

            //Validamos el valor inferior a donde presionamos si está el cero
            if (datofila < 3)
            {
                if (matrizValores[datofila + 1, datocolumna] == 0)
                {
                    valorTemporal = matrizValores[datofila, datocolumna];
                    matrizValores[datofila, datocolumna] = 0;
                    matrizValores[datofila + 1, datocolumna] = valorTemporal;
                }
            }

            //Validamos el valor izquierdo a donde presionamos si está el cero
            if (datocolumna > 0)
            {
                if (matrizValores[datofila, datocolumna - 1] == 0)
                {
                    valorTemporal = matrizValores[datofila, datocolumna];
                    matrizValores[datofila, datocolumna] = 0;
                    matrizValores[datofila, datocolumna - 1] = valorTemporal;
                }
            }

            //Validamos el valor derecho a donde presionamos si está el cero
            if (datocolumna < 3)
            {
                if (matrizValores[datofila, datocolumna + 1] == 0)
                {
                    valorTemporal = matrizValores[datofila, datocolumna];
                    matrizValores[datofila, datocolumna] = 0;
                    matrizValores[datofila, datocolumna + 1] = valorTemporal;
                }
            }
        }
        public void EvaluaBoton(int numeroBoton, int datoFila, int datoColumna)
        {
            posicionFila = datoFila;
            posicionColumna = datoColumna;
            int numero = numeroBoton;
            //Aqui evaluamos en la matrizValores, la posición correspondiente al botón presionado
            EvaluaPosicion(datoFila, datoColumna);

        }
    }
}
