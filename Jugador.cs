using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_6
{
    /// <summary>
    /// Clase que crea los objetos jugador
    /// </summary>
    public class Jugador
    {
        /// <summary>
        /// Setter y getter del nombre del jugador ganador.
        /// </summary>
        public string nombreJugador { get; set; }

        /// <summary>
        /// Setter y getter del puntaje que obtuvo el jugador ganador.
        /// </summary>
        public int puntaje { get; set; }

        /// <summary>
        /// Setter y getter de la fecha en la que jugaron.
        /// </summary>
        public DateTime fecha { get; set; }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="nombre">Nombre del jugador</param>
        /// <param name="puntaje">Puntaje que obtuvo</param>
        /// <param name="fecha">Fecha en la que jugó</param>
        public Jugador(String nombre, int puntaje, DateTime fecha)
        {
            this.nombreJugador = nombre;
            this.puntaje = puntaje;
            this.fecha = fecha;
        }

    }
}
