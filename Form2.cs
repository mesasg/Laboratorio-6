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
    /// Clase de la pestaña de mejores puntajes
    /// </summary>
    public partial class Form2 : Form
    {
        string mP1;
        string mP2;
        string mP3;
        string mP4;
        string mP5;

        /// <summary>
        /// Se ejecuta al cargar el formulario
        /// </summary>
        public Form2()
        {
            InitializeComponent();
            organizarLabels();
            label2.Text = mP1;
            label3.Text = mP2;
            label4.Text = mP3;
            label5.Text = mP4;
            label6.Text = mP5;

        }

        /// <summary>
        /// Asigna la informacion de los mejores puntajes a los labels del formulario
        /// </summary>
        public void organizarLabels()
        {
            Jugadores jugadores = Jugadores.guardarConstructor();

            if (jugadores.mejoresPuntajes[0] != null)
            {
                string nombre = jugadores.mejoresPuntajes[0].nombreJugador;
                string puntaje = jugadores.mejoresPuntajes[0].puntaje.ToString();
                string fecha = jugadores.mejoresPuntajes[0].fecha.ToString();
                mP1 = "Jugador: " + nombre + " " + "Puntaje: " + puntaje + " " + "Fecha: " + fecha;

            }
            if (jugadores.mejoresPuntajes[1] != null)
            {
                string nombre = jugadores.mejoresPuntajes[1].nombreJugador;
                string puntaje = jugadores.mejoresPuntajes[1].puntaje.ToString();
                string fecha = jugadores.mejoresPuntajes[1].fecha.ToString();
                mP2 = "Jugador: " + nombre + " " + "Puntaje: " + puntaje + " " + "Fecha: " + fecha;
            }
            if (jugadores.mejoresPuntajes[2] != null)
            {
                string nombre = jugadores.mejoresPuntajes[2].nombreJugador;
                string puntaje = jugadores.mejoresPuntajes[2].puntaje.ToString();
                string fecha = jugadores.mejoresPuntajes[2].fecha.ToString();
                mP3 = "Jugador: " + nombre + " " + "Puntaje: " + puntaje + " " + "Fecha: " + fecha;
            }
            if (jugadores.mejoresPuntajes[3] != null)
            {
                string nombre = jugadores.mejoresPuntajes[3].nombreJugador;
                string puntaje = jugadores.mejoresPuntajes[3].puntaje.ToString();
                string fecha = jugadores.mejoresPuntajes[3].fecha.ToString();
                mP4 = "Jugador: " + nombre + " " + "Puntaje: " + puntaje + " " + "Fecha: " + fecha;
            }
            if (jugadores.mejoresPuntajes[4] != null)
            {
                string nombre = jugadores.mejoresPuntajes[4].nombreJugador;
                string puntaje = jugadores.mejoresPuntajes[4].puntaje.ToString();
                string fecha = jugadores.mejoresPuntajes[4].fecha.ToString();
                mP5 = "Jugador: " + nombre + " " + "Puntaje: " + puntaje + " " + "Fecha: " + fecha;
            }
        }
        
        /// <summary>
        /// Cierra la pestaña de mejores puntajes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInciarJuego_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
