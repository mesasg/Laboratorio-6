using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_6
{
    /// <summary>
    /// Clase que ejecuta el juego
    /// </summary>
    public partial class Form1 : Form
    {
        private Tablero nuevoTablero;
        private Button piezaSeleccionada;
        private Button nuevaPosicion;
        public string blancas;
        public string negras;
        public int movB = 0;
        public int movN = 0;
        public string ultimoTurno;
        int puntajeFinalB;
        int puntajeFinalN;

        /// <summary>
        /// Se llama al abrir el formulario
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        
        /// <summary>
        /// Crea la matriz y la rellena de botones
        /// </summary>
        public void construirTablero()
        {
            nuevoTablero = new Tablero();

            int coordY = 3;
            for (int i = 0; i < 8; i++)
            {
                int coordX = 3;
                for (int j = 0; j < 8; j++)
                {
                    Button cuadro = new Button();

                    cuadro.Size = new Size(60, 60);
                    cuadro.Location = new Point(coordX, coordY);
                    cuadro.BackColor = Color.Transparent;
                    cuadro.Click += cuadro_Click;
                    cuadro.Image = nuevoTablero.asignarPiezas(i, j);
                    cuadro.Name = nuevoTablero.nombreBoton(i, j);
                    cuadro.ImageAlign = ContentAlignment.MiddleCenter;
                    cuadro.FlatStyle = FlatStyle.Flat;
                    cuadro.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    cuadro.FlatAppearance.BorderSize = 0;
                    cuadro.MouseEnter += cuadro_MouseEnter;
                    cuadro.MouseLeave += cuadro_MouseLeave;
                    cuadro.MouseDown += cuadro_MouseDown;
                    cuadro.MouseUp += cuadro_MouseUp;

                    panel1.Controls.Add(cuadro);
                    
                    coordX += 70;
                }
                coordY += 70;
            }


        }

        /// <summary>
        /// Modifica la apariencia del boton cuando el puntero esta sobre el
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cuadro_MouseEnter(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            boton.BackColor = Color.Transparent;
            boton.FlatAppearance.BorderSize = 2;
            boton.FlatAppearance.BorderColor = Color.Silver;
        }

        /// <summary>
        /// Modifica la apariencia del boton cuando el puntero deja de estar sobre el
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cuadro_MouseLeave(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            boton.BackColor = Color.Transparent;
            boton.FlatAppearance.BorderSize=0;
         
        }

        /// <summary>
        /// Modifica la apariencia del boton cuando el jugador lo presiona
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cuadro_MouseDown(object sender, MouseEventArgs e)
        {
            var boton = sender as Button;
            boton.FlatStyle = FlatStyle.Standard;
            boton.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Modifica la apariencia del boton cuando el jugador deja de presionarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cuadro_MouseUp(object sender, MouseEventArgs e)
        {
            var boton = sender as Button;
            boton.FlatStyle = FlatStyle.Flat;
            boton.BackColor = Color.Transparent;
        }


        /// <summary>
        /// Se ejecuta cuando el usuario selecciona una pieza y el lugar al que la quiere mover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cuadro_Click(object sender, EventArgs e)
        {
            string color;
            string tipo;

            if (piezaSeleccionada == null)
            {
                piezaSeleccionada = sender as Button;
            }
            else
            {
                nuevaPosicion = sender as Button;

                if (movB == 0)
                {
                    color = piezaSeleccionada.Name.Substring(0,1);
                    tipo = piezaSeleccionada.Name.Substring(1);

                    if (color == "b")
                    {
                        switch (tipo)
                        {
                            case "P":
                                nuevoTablero.movimientoPeon(piezaSeleccionada, nuevaPosicion, 0);
                                break;
                            case "C":
                                nuevoTablero.movimientoCaballo(piezaSeleccionada, nuevaPosicion);
                                break;
                            default:
                                MessageBox.Show("Solo los peones y caballos pueden iniciar la partida");
                                break;
                        }
                        ultimoTurno = "b";
                        movB++;
                        puntosBlanca.Text = nuevoTablero.puntosBlancas.ToString();
                        puntosNegras.Text = nuevoTablero.puntosNegras.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Las blancas comienzan el juego");
                    }

                }
                else
                {
                    color = piezaSeleccionada.Name.Substring(0, 1);
                    tipo = piezaSeleccionada.Name.Substring(1);

                    if (color != ultimoTurno)
                    {
                        switch (tipo)
                        {
                            case "P":
                                if (color == "n")
                                {
                                    nuevoTablero.movimientoPeon(piezaSeleccionada, nuevaPosicion, movN);
                                    movN++;
                                }
                                if (color == "b")
                                {
                                    nuevoTablero.movimientoPeon(piezaSeleccionada, nuevaPosicion, movB);
                                    movB++;
                                }
                                break;
                            case "C":
                                nuevoTablero.movimientoCaballo(piezaSeleccionada, nuevaPosicion);
                                break;
                            case "A":
                                nuevoTablero.movimientoAlfil(piezaSeleccionada, nuevaPosicion);
                                break;
                            case "T":
                                nuevoTablero.movimientoTorre(piezaSeleccionada, nuevaPosicion);
                                break;
                            case "Q":
                                nuevoTablero.movimientoReina(piezaSeleccionada, nuevaPosicion);
                                break;
                            case "R":
                                nuevoTablero.movimientoRey(piezaSeleccionada, nuevaPosicion);
                                break;
                            default:
                                break;
                        }

                        ultimoTurno = color;
                        puntosBlanca.Text = nuevoTablero.puntosBlancas.ToString();
                        puntosNegras.Text = nuevoTablero.puntosNegras.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Es el turno del otro jugador");
                    }

                }

                piezaSeleccionada = null;
                nuevaPosicion = null;
            }
        }


        /// <summary>
        /// Inicia el juego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIniciarJuego_Click(object sender, EventArgs e)
        {
            blancas =txtBlancas.Text;
            negras =txtNegras.Text;
            label1.Visible = false; 
            label2.Visible = false;
            btnInciarJuego.Visible = false;
            txtBlancas.Visible = false;
            txtNegras.Visible = false;
            panelPuntos.Visible = true;
            button1.Visible = true;
            button2.Visible = false;
            construirTablero();
        }

        /// <summary>
        /// Termina el juego y guarda la informacion del ganador
        /// </summary>
        public void terminarJuego()
        {
            int.TryParse(puntosBlanca.Text, out puntajeFinalB);
            int.TryParse(puntosNegras.Text, out puntajeFinalN);
            

            int puntajeGanador;
            string ganador;
            DateTime fecha = DateTime.Now;

            Jugadores jugadores= Jugadores.guardarConstructor();

            if (puntajeFinalN > puntajeFinalB)
            {
                puntajeGanador = puntajeFinalN;
                ganador = negras;
                jugadores.guardarObjetoJugador(ganador, puntajeGanador, fecha);
            }
            if (puntajeFinalB > puntajeFinalN)
            {
                puntajeGanador = puntajeFinalB;
                ganador = blancas;
                jugadores.guardarObjetoJugador(ganador, puntajeGanador, fecha);

            }
            if (puntajeFinalN == puntajeFinalB)
            {
                puntajeGanador = puntajeFinalN;
                ganador = negras + " - " + blancas;
                jugadores.guardarObjetoJugador(ganador, puntajeGanador, fecha);
            }
            panel1.Controls.Clear();
            label1.Visible = true;
            label2.Visible = true;
            btnInciarJuego.Visible = true;
            txtBlancas.Visible = true;
            txtNegras.Visible = true;
            panelPuntos.Visible = false;
            button1.Visible = false;
            button2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            terminarJuego();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 mejoresPuntajes = new Form2();
            mejoresPuntajes.ShowDialog();
        }
    }
}
