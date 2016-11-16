using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoEncuentreParejas
{
    public partial class Form1 : Form
    {
        //Aqui declaramos los atributos del juego
     
        private metodosjuego objx= new metodosjuego();
      
        //Estos dos arreglos tienen tienen los valores y los botones
    
        private Button[] arregloBotones;
        
        


        //Estos atributos se refieren a la parte de la pareja a encontrar
        

        public Form1()
        {
            InitializeComponent();

            //Aqui inicializamos los atributos del juego
            objx.InicializaArregloValores();
            objx.InicializaAtributos();
            InicializaArregloBotones();
            


            //Llevamos los valores de los atributos a los cuadros de texto
            textoTotalIntentos.Text = objx.intentos.ToString();
            textoParejasEncontradas.Text = objx.parejas.ToString();
        }

        //private void InicializaAtributos()
        //{
        //    totalIntentos = 0;
        //    totalParejas = 0;

        //    //Inicializamos las partes de la pareja
        //    parejaParteA = 0;
        //    parejaParteB = 0;

        //    //Aqui invocamos las funciones de inicialización de arreglo
        //    InicializaArregloBotones();
        //    InicializaArregloValores();
        //}

        //Este metodo Inicializa el arreglo de valores
        //private void InicializaArregloValores()
        //{
        //    //Estas son las variables de la función
        //    //Los números a ubicar... va de 1 a 8
        //    int contadorNumeros = 1;
        //    //Las ubicaciones por número: 2
        //    int contadorUbicacion = 0;

        //    //La variable que llevara control de la ubicación del número
        //    int ubicacionValor;

        //    //Esta es la variable aleatoria que utilizaremos
        //    Random aleatorio = new Random();

        //    //primero inicializamos el arreglo en ceros
        //    arregloValores = new int[16];

        //    for (int i = 0; i < arregloValores.Length; i++)
        //        arregloValores[i] = 0;

        //    //Este ciclo while ubica los numeros en el arreglo
        //    while (contadorNumeros <= 8) //Total numeros a ubicar
        //    {
        //        ubicacionValor = aleatorio.Next(arregloValores.Length);

        //        //Si en esa ubicación hay un cero, almacenamos el numero
        //        if (arregloValores[ubicacionValor] == 0)
        //        {
        //            arregloValores[ubicacionValor] = contadorNumeros;
        //            contadorUbicacion++;
        //        }

        //        // Si ya ubicamos los dos valores por numero, continuamos 
        //        // con el siguiente valor
        //        if (contadorUbicacion == 2)
        //        {
        //            contadorNumeros++;
        //            contadorUbicacion = 0;
        //        }
        //    }

        //    //Aqui inicializamos el arreglo que contiene los valores encontrados
        //    h = new bool[8];

        //    for (int i = 0; i < h.Length; i++)
        //        h[i] = false;

        //}

        // Este método inicializa los Botones<s
        public void InicializaArregloBotones()
        {
            arregloBotones = new Button[16];

            arregloBotones[0] = button1;
            arregloBotones[1] = button2;
            arregloBotones[2] = button3;
            arregloBotones[3] = button4;
            arregloBotones[4] = button5;
            arregloBotones[5] = button6;
            arregloBotones[6] = button7;
            arregloBotones[7] = button8;
            arregloBotones[8] = button9;
            arregloBotones[9] = button10;
            arregloBotones[10] = button11;
            arregloBotones[11] = button12;
            arregloBotones[12] = button13;
            arregloBotones[13] = button14;
            arregloBotones[14] = button15;
            arregloBotones[15] = button16;

            //Finalmente, aqui ocultamos todas las etiquetas de los botones
            for (int i = 0; i < arregloBotones.Length; i++)
            {
                arregloBotones[i].Text = "X";
                arregloBotones[i].Enabled = true; //Los habilitamos
            }
        }

        private void botonReiniciar_Click(object sender, EventArgs e)
        {
            objx.InicializaAtributos();
            objx.InicializaArregloValores();
            objx.InicializaAtributos();
            InicializaArregloBotones();

            //Llevamos los valores de los atributos a los cuadros de texto
            textoTotalIntentos.Text = objx.intentos.ToString();
            textoParejasEncontradas.Text = objx.parejas.ToString();

            textoEstado.Text = "Juego reinicializado.";

        }

        private void AnalizaBotonPresionado(int numeroBoton)
        {
           

        //Aqui leemos el valor del dato correspondiente al boton presionado
        int datoValor = objx.valores[numeroBoton - 1];

            //Y también desactivamos el botón para que no se vuelva a usar mientras se
            //define la busqueda de la pareja
            arregloBotones[numeroBoton - 1].Enabled= false;



            string mensaje; //El mensaje que se visualizará en el cuadro de diálogo

            textoEstado.Text = "Presionaste el botón " +
                numeroBoton.ToString() + ", el valor aqui es: " +
                 datoValor.ToString();

            //Aqui identificamos si el valor presionado corresponde a la parte A o B
            if (objx.parejaa == 0)
                //Luego almacenamos en la respectiva parte el valor del arreglo
                objx.parejaa = datoValor;
            else // De lo contrario, lo almacenamos en la parteB
                objx.parejab = datoValor;

            //Luego visualizamos el valor en el botón presionado
            arregloBotones[numeroBoton - 1].Text = datoValor.ToString();

            //Aqui se comparan las partes de la pareja
            //Primero se valida si las partes están ingresadas
            if (objx.parejaa != 0 && objx.parejab != 0)
            {
                //Aqui colocamos un cuadro de Dialogo con los valores encontrados
                mensaje = "Parte A: " + objx.parejaa.ToString() + "\nParte B: " + objx.parejab.ToString();

                // Si las partes son iguales, se encontró una pareja
                if (objx.parejaa == objx.parejab)
                {
                    //Se visualiza en un cuadro de dialogo que se ha encontrado una pareja
                    MessageBox.Show(mensaje, "Pareja encontrada!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objx.encontrados[datoValor - 1] = true;
                    textoEstado.Text = objx.EvaluarCondicionVictoria();

                }
                // De lo contrario, se vuelve a ocultar las etiquetas
                else
                {
                    //Se visualiza en un cuadro de dialogo los valores que se revelaron
                    MessageBox.Show(mensaje, "Valores revelados:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Este método oculta las etiquetas de los valores no encontrados
                    ValidaEtiquetasBotones();
                }

                //reiniciamos los valores de las partes para el siguiente intento
                objx.parejaa = 0;
                objx.parejab = 0;

                //En cualquier caso, se incrementa el número de intentos
                objx.intentos++;
            }

            //Aqui actualizamos la información de los usuarios
            textoTotalIntentos.Text = objx.intentos.ToString();
            textoParejasEncontradas.Text = objx.parejas.ToString();
        }

        
        //Aqui validamos la condición de victoria
        //private void EvaluarCondicionVictoria()
        //{
        //    //Reiniciamos el contador de parejas encontradas
        //    totalParejas = 0;

        //    for (int i = 0; i < objx.encontrados.Length; i++)
        //    {
        //        if (objx.encontrados[i] == true)
        //            totalParejas++;
        //    }

        //    //Si el total de parejas es 8, la victoria se ha obtenido
        //    if (totalParejas == 8)
        //    {
        //        textoEstado.Text = "Victoria Alcanzada!";

        //        /*
        //        //Aqui se bloquean todos los botones para que no sigan activos
        //        for (int i = 0; i < arregloBotones.Length; i++)
        //            arregloBotones[i].Enabled = false;
        //        */
        //    }
        //}

        //Este método se encarga de volver a esconder aquellos valores que no han sido
        //relacionados en parejas, colocando en el botón una X
        private void ValidaEtiquetasBotones()
        {
            int datoValor;

            //Se valida si el valor fue encontrado. Si no, se vuelve a colocar la X
            for (int i = 0; i < objx.valores.Length; i++)
            {
                datoValor = objx.valores[i];

                //Se identifica en el arreglo de valoresEncontrados si ya se identificó la pareja
                if (objx.encontrados[datoValor - 1] == false)
                {
                    //Si el valor no fue encontrado, el botón se coloca con X
                    arregloBotones[i].Text = "X";
                    arregloBotones[i].Enabled = true; //se habilita nuevamente el botón
                }
            }

            textoEstado.Text = "";
        }

        #region Eventos de los Botones

        private void button1_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(12);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(15);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(16);
        }

        #endregion
    }
}
