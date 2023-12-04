using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_6
{
    /// <summary>
    /// Clase que administra el vector de mejores Puntajes
    /// </summary>
    public class Jugadores
    {
        public static Jugadores objetoJugador;
        public Jugador[] mejoresPuntajes;
        int numJugadores;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Jugadores()
        {
            mejoresPuntajes = new Jugador[5];
            numJugadores = 0;
        }

        /// <summary>
        /// Guarda los resultados de la partida. 
        /// Organiza el vector de mejoresPuntajes
        /// </summary>
        /// <param name="nombre">Nombre del jugador ganador</param>
        /// <param name="puntaje">´Puntaje que obtuvo</param>
        /// <param name="fecha">Fecha en la que jugó</param>
        public void guardarObjetoJugador(string nombre, int puntaje, DateTime fecha)
        {
            if (numJugadores < 5)
            {
                mejoresPuntajes[numJugadores] = new Jugador(nombre, puntaje, fecha);
                int cant = numJugadores;
                for (int i = numJugadores; i>0;  i--)
                {
                    if (mejoresPuntajes[i].puntaje > mejoresPuntajes[i - 1].puntaje)
                    {
                        Jugador aux = mejoresPuntajes[i];
                        mejoresPuntajes[i] = mejoresPuntajes[i - 1];
                        mejoresPuntajes[i - 1] = aux;
                    }
                }
                numJugadores++;
            }
            if(numJugadores == 5)
            {
                for(int s = 0; s<5; s++)
                {
                    if (mejoresPuntajes[s].puntaje < puntaje)
                    {
                        for (int m = 4; m > s; m--)
                        {
                            mejoresPuntajes[m] = mejoresPuntajes[m - 1];
                        }

                        mejoresPuntajes[s] = new Jugador(nombre, puntaje, fecha);
                        break;
                    }
                }
            }

        }     
        
        /// <summary>
        /// Guarda el constructor creado en la primera partida para poder acceder a las partidas en el mismo vector
        /// </summary>
        /// <returns></returns>
        public static Jugadores guardarConstructor()
        {
            if (objetoJugador == null)
            {
                objetoJugador = new Jugadores();
            }
            return objetoJugador;
        }



    }
}
