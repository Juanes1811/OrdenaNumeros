using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OrdenaNumeros;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Prueba_CondiciondeVictoria()
        {

            //Arrange
            int datofila = 0;
            int datocolumna = 0;
            int datonumero = 0;

            Logica Evaluador = new Logica();

            //Aqui inicializo la matriz para verificar que la condicion victoria sea true si todo esta en el orden correcto
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    datonumero++;
                    Evaluador.MatrizValores[i, j] = datonumero;
                }
            }
            Evaluador.MatrizValores[3, 3] = 0;

            //Aqui cambio un valor del arreglo para verificar que la condicion victoria sea falsa si hay un valor en otro lugar
            Evaluador.MatrizValores[datofila, datocolumna] = datonumero;

            //Act
            bool Victoria = Evaluador.EvaluaCondicionVictoria();

            //Assert

            Assert.AreEqual(false, Victoria);


        }

        [TestMethod]
        public void Prueba_EvaluaPosicion()
        {
            //Arrange
            int datofila = 2;
            int datocolumna = 3;

            int datonumero = 0;

            int datofilaCero = 3;
            int datocolumnaCero = 3;

            Logica Evaluador = new Logica();

            //Aqui inicializo la matriz en orden para saber donde esta el cero y las entradas cercanas a el
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    datonumero++;
                    Evaluador.MatrizValores[i, j] = datonumero;
                }
            }
            Evaluador.MatrizValores[datofilaCero, datocolumnaCero] = 0;

            //Act
            Evaluador.EvaluaPosicion(datofila, datocolumna);


            //Assert
            //Aqui nos menciona si nos confirma si hubo cambio de posicion con el cero o no
            Assert.AreEqual(0, Evaluador.MatrizValores[datofila, datocolumna]);
            Assert.AreEqual(12, Evaluador.MatrizValores[datocolumnaCero, datocolumnaCero]);


        }


        [TestMethod]
        public void Prueba_InicializaValoresMatrices()
        {
            //Arrange
            int[,] arreglodeprueba = new int[4, 4];

            int datofila = 0;
            int datocolumna = 0;


            int datonumero = 0;

            Logica Evaluador = new Logica();

            //inicializa una matriz ordeanada para compararla con la de la funcion
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arreglodeprueba[i, j] = datonumero;
                    datonumero++;
                }
            }

            //Act
            int[,] referencia = Evaluador.InicializaMatrizValores();

            //Assert
            //Evalua si estan los numeros del 0 al 16 
            Assert.AreEqual(arreglodeprueba[datofila, datocolumna], referencia[datofila, datocolumna]);
        }
    }
}
