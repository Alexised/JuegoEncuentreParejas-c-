using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEncuentreParejas
{
    class metodosjuego
    {
        /// <summary>
        /// 
        /// </summary>
        private static int totalIntentos;
        private static int totalParejas;
        private static int[] arregloValores;
        private static bool[] valoresEncontrados;
        private static int parejaParteA = 0;
        private static int parejaParteB = 0;
        private static  string text =""; 

        #region "Propiedades"
        public int intentos
        { set { totalIntentos = value; }
            get { return totalIntentos; }
        }
        public string message
        {
            set { text = value; }
            get { return text; }
        }
        public int parejaa
        {
            set { parejaParteA = value; }
            get { return parejaParteA; }
        }
        public int parejab
        {
            set { parejaParteB = value; }
            get { return parejaParteB; }
        }
        public int parejas
        { set { totalParejas = value; }
            get { return totalParejas; }
        }

        public int [] valores
        { set { arregloValores = value; }
           get { return arregloValores; }
        }

        public bool [] encontrados
        {
            get { return valoresEncontrados; }
            set { valoresEncontrados = value; }
        }
        #endregion

        public void InicializaAtributos()
        {



            //Inicializamos las partes de la pareja
            totalIntentos = 0;
            totalParejas = 0;

            //Inicializamos las partes de la pareja
            parejaParteA = 0;
            parejaParteB = 0;

            //Aqui invocamos las funciones de inicialización de arreglo

            InicializaArregloValores();
        }
        public void InicializaArregloValores()
        {             //Estas son las variables de la función
            //Los números a ubicar... va de 1 a 8
            int contadorNumeros = 1;
            //Las ubicaciones por número: 2
            int contadorUbicacion = 0;

            //La variable que llevara control de la ubicación del número
            int ubicacionValor;

            //Esta es la variable aleatoria que utilizaremos
            Random aleatorio = new Random();

            //primero inicializamos el arreglo en ceros
            arregloValores = new int[16];

            for (int i = 0; i < arregloValores.Length; i++)
                arregloValores[i] = 0;

            //Este ciclo while ubica los numeros en el arreglo
            while (contadorNumeros <= 8) //Total numeros a ubicar
            {
                ubicacionValor = aleatorio.Next(arregloValores.Length);

                //Si en esa ubicación hay un cero, almacenamos el numero
                if (arregloValores[ubicacionValor] == 0)
                {
                    arregloValores[ubicacionValor] = contadorNumeros;
                    contadorUbicacion++;
                }

                // Si ya ubicamos los dos valores por numero, continuamos 
                // con el siguiente valor
                if (contadorUbicacion == 2)
                {
                    contadorNumeros++;
                    contadorUbicacion = 0;
                }
            }

            //Aqui inicializamos el arreglo que contiene los valores encontrados
            valoresEncontrados = new bool[8];

            for (int i = 0; i < valoresEncontrados.Length; i++)
                valoresEncontrados[i] = false;
        


        }
        public string EvaluarCondicionVictoria()
        {
            //Reiniciamos el contador de parejas encontradas
            totalParejas = 0;

            for (int i = 0; i < valoresEncontrados.Length; i++)
            {
                if (valoresEncontrados[i] == true)
                    totalParejas++;
            }

            //Si el total de parejas es 8, la victoria se ha obtenido
            if (totalParejas == 8)
            {
               return text = "Victoria Alcanzada!";

                /*
                //Aqui se bloquean todos los botones para que no sigan activos
                for (int i = 0; i < arregloBotones.Length; i++)
                    arregloBotones[i].Enabled = false;
                */
            } else {
                return text = " continue!";

            }
        }

    }
}
