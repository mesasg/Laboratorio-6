using Laboratorio_6.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Laboratorio_6
{
    /// <summary>
    /// Clase que contiene los metodos escenciales del juego
    /// </summary>
    internal class Tablero
    {
        public Button[,] tablero;
        private Button piezaSeleccionada;
        private Button nuevaPosicion;
        public int puntosBlancas = 0;
        public int puntosNegras = 0;


        /// <summary>
        /// Getter y setter de la posicion de cada cuadro del tablero.
        /// </summary>
        public string[,] posiciones { get; set; }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Tablero()
        {
            this.posiciones = new string[8, 8];
            posicionesTablero();
        }

        /// <summary>
        /// Devuelve el valor correspondiente a cada pieza
        /// </summary>
        /// <param name="piezaComida">Tipo de pieza comida</param>
        /// <returns>Puntos que se deben sumar</returns>
        public int sumarPuntos(string piezaComida)
        {
            Form1 form = new Form1();
            switch (piezaComida)
            {
                case "C": 
                    return 3;
                case "Q": 
                    return 9;
                case "A": 
                    return 3;
                case "T": 
                    return 5;
                case "R":
                    form.terminarJuego();
                    return 0; //valor control para saber que hizo jaque
                default: 
                    return 1;
            }
        }

        /// <summary>
        /// Contola los movimientos de los peones
        /// </summary>
        /// <param name="peon">Botón correspondiente al peón</param>
        /// <param name="destino">Botón correspondiente a la casilla a la que se quiere mover</param>
        /// <param name="mov">Número de movimientos que se han hecho en la partida</param>
        public void movimientoPeon(Button peon, Button destino, int mov)
        {
            Form1 form = new Form1();
            int columna = destino.Location.X;
            int fila = destino.Location.Y;

            int colP = peon.Location.X;
            int filaP = peon.Location.Y;
            string colorPeon = peon.Name.Substring(0, 1);

            bool mov1Negro = false;
            bool mov1Blanco = false;

            //En el primer movimiento se puede mover hasta 2 casillas
            if (fila - filaP == 70 && columna == colP || fila - filaP == 140 && columna == colP)
            {
                mov1Negro = true;
            }
            if (fila - filaP == -70 && columna == colP || fila - filaP == -140 && columna == colP)
            {
                mov1Blanco = true;
            }

            if (mov == 0) // si es el primer movimiento
            {
                if (colorPeon == "b")
                {
                    if (mov1Blanco)
                    {
                        string aux = destino.Name;
                        destino.Name = peon.Name;
                        peon.Name = aux;

                        Image auxI = destino.Image;
                        destino.Image = peon.Image;
                        peon.Image = auxI;
                    }

                }
                if (colorPeon == "n")
                {
                    if (mov1Negro)
                    {
                        string aux = destino.Name;
                        destino.Name = peon.Name;
                        peon.Name = aux;

                        Image auxI = destino.Image;
                        destino.Image = peon.Image;
                        peon.Image = auxI;
                    }
                }
            }
            else
            {
                bool movNegro = false;
                bool movBlanco = false;
                // el peon solo se puede mover hacia adelante en la dirección correspondiente al color
                if (fila - filaP == 70)
                {
                    movNegro = true;
                }
                if (fila - filaP == -70)
                {
                    movBlanco = true;
                }

                string colorVacio = destino.Name.Substring(0, 1);
                bool comerBlanco = false;
                bool comerNegro = false;
                // Si la casilla que inidico el jugador esta en diagonal
                if (fila - filaP == 70 && columna - colP == -70 || fila - filaP == 70 && columna - colP == 70)
                {
                    comerNegro = true;
                }
                if (fila - filaP == -70 && columna - colP == 70 || fila - filaP == -70 && columna - colP == -70)
                {
                    comerBlanco = true;
                }

                string pieza = destino.Name.Substring(1);

                if (colorPeon == "b")
                {
                    if (movBlanco)
                    {
                        switch (colorVacio)
                        {
                            case "n":
                                if (comerBlanco && colorVacio != "v")
                                {
                                    int puntos = sumarPuntos(pieza);

                                    if (puntos == 0)
                                    {
                                        form.terminarJuego();
                                    }
                                    else
                                    {
                                        puntosBlancas += puntos;
                                    }

                                    destino.Image = peon.Image;
                                    peon.Image = null;

                                    destino.Name = peon.Name;
                                    peon.Name = "v";
                                }
                                break;
                            case "b":
                                MessageBox.Show("No puedes poner 2 piezas en el mismo lugar");
                                break;
                            default:
                                if(columna == colP) // para que no se pueda mover en diagonal si no es para comer
                                {
                                    string aux = destino.Name;
                                    destino.Name = peon.Name;
                                    peon.Name = aux;
                                    Image auxI = destino.Image;
                                    destino.Image = peon.Image;
                                    peon.Image = auxI;
                                }
                                break;
                        }

                    }

                }

                if (colorPeon == "n")
                {
                    if (movNegro)
                    {
                        switch (colorVacio)
                        {
                            case "b":
                                if (comerNegro && colorVacio != "v")
                                {
                                    int puntos = sumarPuntos(pieza);
                                    if (puntos == 0)
                                    {
                                        form.terminarJuego();
                                    }
                                    else
                                    {
                                        puntosNegras += puntos;
                                    }

                                    destino.Name = peon.Name;
                                    peon.Name = "v";

                                    destino.Image = peon.Image;
                                    peon.Image = null;
                                }
                                break;
                            case "n":
                                MessageBox.Show("No puedes poner 2 piezas en el mismo lugar");
                                break;
                            default:
                                if(columna == colP)
                                {
                                    string aux = destino.Name;
                                    destino.Name = peon.Name;
                                    peon.Name = aux;
                                    Image auxI = destino.Image;
                                    destino.Image = peon.Image;
                                    peon.Image = auxI;
                                }
                                break;
                        }
                    }

                }
            }

        }

        /// <summary>
        /// Controla el movimiento de las torres
        /// </summary>
        /// <param name="torre">Botón correspondiente a la torre</param>
        /// <param name="destino">Botón correspondiente a la casilla a la que se quiere mover</param>
        public void movimientoTorre(Button torre, Button destino)
        {
            Form1 form = new Form1();
            int columna = destino.Location.X;
            int fila = destino.Location.Y;

            int colT = torre.Location.X;
            int filaT = torre.Location.Y;
            string colorTorre = torre.Name.Substring(0, 1);
            form1 = new Form1();

            bool movTorre = false;
            //horizontal
            if (columna - colT <= 490 && columna - colT >= -490 && fila == filaT)
            {
                movTorre = true;
            }
            //vertical
            if (fila - filaT <= 490 && fila - filaT >= -490 && columna == colT)
            {
                movTorre = true;
            }

            string colorVacio = destino.Name.Substring(0, 1);
            string pieza = destino.Name.Substring(1);
            if (movTorre)
            {
                switch (colorVacio)
                {
                    case "n":
                        if (colorTorre == "n")
                        {
                            MessageBox.Show("No puedes poner 2 piezas en el mismo lugar");
                        }
                        if (colorTorre == "b")
                        {
                            int puntos = sumarPuntos(pieza);
                            if (puntos == 0)
                            {
                                form.terminarJuego();
                            }
                            else
                            {
                                puntosBlancas += puntos;
                            }

                            destino.Name = torre.Name;
                            torre.Name = "v";

                            destino.Image = torre.Image;
                            torre.Image = null;
                        }
                        break;

                    case "b":
                        if (colorTorre == "b")
                        {
                            MessageBox.Show("No puedes poner 2 piezas en el mismo lugar");
                        }
                        if (colorTorre == "n")
                        {
                            int puntos = sumarPuntos(pieza);
                            if (puntos == 0)
                            {
                                form.terminarJuego();
                            }
                            else
                            {
                                puntosNegras += puntos;
                            }

                            destino.Name = torre.Name;
                            torre.Name = "v";

                            destino.Image = torre.Image;
                            torre.Image = null;
                        }
                        break;

                    default:
                        string aux = destino.Name;
                        destino.Name = torre.Name;
                        torre.Name = aux;

                        Image auxI = destino.Image;
                        destino.Image = torre.Image;
                        torre.Image = auxI;
                        break;

                }
            }

        }

        /// <summary>
        /// Controla los movimientos de los caballos
        /// </summary>
        /// <param name="caballo">Botón correspondiente al caballo</param>
        /// <param name="destino">Botón correspondiente a la casilla a la que se quiere mover</param>
        public void movimientoCaballo(Button caballo, Button destino)
        {
            Form1 form = new Form1();
            int columna = destino.Location.X;
            int fila = destino.Location.Y;

            int colC = caballo.Location.X;
            int filaC = caballo.Location.Y;
            string colorCaballo = caballo.Name.Substring(0, 1);

            bool movCaballo = false;
            //Adelante
            if (columna - colC == -70 && fila - filaC == -140 || columna - colC == 70 && fila - filaC == -140)
            {
                movCaballo = true;
            }
            //Adelante lados
            if (columna - colC == 140 && fila - filaC == -70 || columna - colC == -140 && fila - filaC == -70)
            {
                movCaballo = true;
            }
            //Atras 
            if (columna - colC == 70 && fila - filaC == 140 || columna - colC == -70 && fila - filaC == 140)
            {
                movCaballo = true;
            }
            //Atras lados
            if (columna - colC == 140 && fila - filaC == 70 || columna - colC == -140 && fila - filaC == 70)
            {
                movCaballo = true;
            }

            string colorVacio = destino.Name.Substring(0, 1);
            string pieza = destino.Name.Substring(1);
            if (movCaballo)
            {
                switch (colorVacio)
                {
                    case "n":
                        if (colorCaballo == "n")
                        {
                            MessageBox.Show("No puedes poner 2 piezas en el mismo lugar");
                        }
                        if (colorCaballo == "b")
                        {
                            int puntos = sumarPuntos(pieza);
                            if (puntos == 0)
                            {
                                form.terminarJuego();
                            }
                            else
                            {
                                puntosBlancas += puntos;
                            }

                            destino.Name = caballo.Name;
                            caballo.Name = "v";

                            destino.Image = caballo.Image;
                            caballo.Image = null;
                        }
                        break;

                    case "b":
                        if (colorCaballo == "b")
                        {
                            MessageBox.Show("No puedes poner 2 piezas en el mismo lugar");
                        }
                        if (colorCaballo == "n")
                        {
                            int puntos = sumarPuntos(pieza);
                            if (puntos == 0)
                            {
                                form.terminarJuego();
                            }
                            else
                            {
                                puntosNegras += puntos;
                            }

                            destino.Name = caballo.Name;
                            caballo.Name = "v";

                            destino.Image = caballo.Image;
                            caballo.Image = null;
                        }
                        break;

                    default:
                        string aux = destino.Name;
                        destino.Name = caballo.Name;
                        caballo.Name = aux;

                        Image auxI = destino.Image;
                        destino.Image = caballo.Image;
                        caballo.Image = auxI;
                        break;

                }
            }

        }

        /// <summary>
        /// Controla el movimiento de los alfiles
        /// </summary>
        /// <param name="alfil">Botón correspondiente al alfil</param>
        /// <param name="destino">Botón correspondiente a la casilla a la que se quiere mover</param>
        public void movimientoAlfil(Button alfil, Button destino)
        {
            Form1 form = new Form1();
            int columna = destino.Location.X;
            int fila = destino.Location.Y;
            int colA = alfil.Location.X;
            int filaA = alfil.Location.Y;

            bool movAlfil = false;
            //Arriba derecha
            if (fila - filaA >= -490 && columna - colA == -(fila - filaA))
            {
                movAlfil = true;
            }
            //Abajo derecha
            if (fila - filaA >= 490 && columna - colA == fila - filaA)
            {
                movAlfil = true;
            }
            //Arriba izquierda
            if (fila - filaA >= -490 && columna - colA == fila - filaA)
            {
                movAlfil = true;
            }
            //Abajo izquierda
            if (fila - filaA >= 490 && columna - colA == -(fila - filaA))
            {
                movAlfil = true;
            }

            string colorAlfil = alfil.Name.Substring(0, 1);
            string colorVacio = destino.Name.Substring(0, 1);
            string pieza = destino.Name.Substring(1);

            if (movAlfil)
            {
                switch (colorVacio)
                {
                    case "n":
                        if (colorAlfil == "n")
                        {
                            MessageBox.Show("No puedes poner 2 piezas en el mismo lugar");
                        }
                        if (colorAlfil == "b")
                        {
                            int puntos = sumarPuntos(pieza);
                            if (puntos == 0)
                            {
                                form.terminarJuego();
                            }
                            else
                            {
                                puntosBlancas += puntos;
                            }

                            destino.Name = alfil.Name;
                            alfil.Name = "v";

                            destino.Image = alfil.Image;
                            alfil.Image = null;
                        }
                        break;

                    case "b":
                        if (colorAlfil == "b")
                        {
                            MessageBox.Show("No puedes poner 2 piezas en el mismo lugar");
                        }
                        if (colorAlfil == "n")
                        {
                            int puntos = sumarPuntos(pieza);
                            if (puntos == 0)
                            {
                                form.terminarJuego();
                            }
                            else
                            {
                                puntosNegras += puntos;
                            }

                            destino.Name = alfil.Name;
                            alfil.Name = "v";

                            destino.Image = alfil.Image;
                            alfil.Image = null;
                        }
                        break;

                    default:

                        string aux = destino.Name;
                        destino.Name = alfil.Name;
                        alfil.Name = aux;

                        Image auxI = destino.Image;
                        destino.Image = alfil.Image;
                        alfil.Image = auxI;

                        break;
                }
            }

        }

        /// <summary>
        ///  Controla los movimientos de los reyes
        /// </summary>
        /// <param name="rey">Botón correspondiente a la rey</param>
        /// <param name="destino">Botón correspondiente a la casilla que se quiere mover</param>
        public void movimientoRey(Button rey, Button destino)
        {
            Form1 form = new Form1();
            int columna = destino.Location.X;
            int fila = destino.Location.Y;

            int colR = rey.Location.X;
            int filaR = rey.Location.Y;

            bool horizontal = false;
            bool vertical = false;

            if (filaR - fila == 70 && colR == columna || filaR - fila == -70 && colR == columna)
            {
                vertical = true;
            }
            if (colR - columna == -70 && filaR == fila || colR - columna == 70 && filaR == fila)
            {
                horizontal = true;
            }

            bool diagonal = false;

            if (filaR - fila == 70 && colR - columna == 70 || filaR - fila == 70 && colR - columna == -70 ||
                filaR - fila == -70 && colR - columna == 70 || filaR - fila == -70 && colR - columna == -70)
            {
                diagonal = true;
            }

            string colorVacio = destino.Name.Substring(0, 1);
            string pieza = destino.Name.Substring(1);
            string colorRey = rey.Name.Substring(0, 1);

            if (diagonal || horizontal || vertical)
            {
                switch (colorVacio)
                {
                    case "n":
                        if (colorRey == "n")
                        {
                            MessageBox.Show("No puedes poner 2 piezas en el mismo lugar");
                        }
                        if (colorRey == "b")
                        {
                            int puntos = sumarPuntos(pieza);
                            if (puntos == 0)
                            {
                                form.terminarJuego();
                            }
                            else
                            {
                                puntosBlancas += puntos;
                            }

                            destino.Name = rey.Name;
                            rey.Name = "v";

                            destino.Image = rey.Image;
                            rey.Image = null;
                        }
                        break;

                    case "b":
                        if (colorRey == "b")
                        {
                            MessageBox.Show("No puedes poner 2 piezas en el mismo lugar");
                        }
                        if (colorRey == "n")
                        {
                            int puntos = sumarPuntos(pieza);
                            if (puntos == 0)
                            {
                                form.terminarJuego();
                            }
                            else
                            {
                                puntosNegras += puntos;
                            }

                            destino.Name = rey.Name;
                            rey.Name = "v";

                            destino.Image = rey.Image;
                            rey.Image = null;
                        }
                        break;

                    default:
                        string aux = destino.Name;
                        destino.Name = rey.Name;
                        rey.Name = aux;

                        Image auxI = destino.Image;
                        destino.Image = rey.Image;
                        rey.Image = auxI;
                        break;
                }

            }

        }

        /// <summary>
        /// Controla el movimiento de las reinas
        /// </summary>
        /// <param name="reina">Botón correspondiente a la reina</param>
        /// <param name="destino">Botón correspondiente a la casilla a la que se quiere mover</param>
        public void movimientoReina(Button reina, Button destino)
        {
            Form1 form = new Form1();
            int columna = destino.Location.X;
            int fila = destino.Location.Y;

            int colR = reina.Location.X;
            int filaR = reina.Location.Y;

            bool movReina = false;
            //Arriba derecha
            if (fila - filaR >= -490 && columna - colR == -(fila - filaR))
            {
                movReina = true;
            }
            //Abajo derecha
            if (fila - filaR >= 490 && columna - colR == fila - filaR)
            {
                movReina = true;
            }
            //Arriba izquierda
            if (fila - filaR >= -490 && columna - colR == fila - filaR)
            {
                movReina = true;
            }
            //Abajo izquierda
            if (fila - filaR >= 490 && columna - colR == -(fila - filaR))
            {
                movReina = true;
            }
            //horizontal
            if (columna - colR <= 490 && columna - colR >= -490 && fila == filaR)
            {
                movReina = true;
            }
            //vertical
            if (fila - filaR <= 490 && fila - filaR >= -490 && columna == colR)
            {
                movReina = true;
            }

            string colorReina = reina.Name.Substring(0, 1);
            string colorVacio = destino.Name.Substring(0, 1);
            string pieza = destino.Name.Substring(1);

            if (movReina)
            {
                switch (colorVacio)
                {
                    case "n":
                        if (colorReina == "n")
                        {
                            MessageBox.Show("No puedes poner 2 piezas en el mismo lugar");
                        }
                        if (colorReina == "b")
                        {
                            int puntos = sumarPuntos(pieza);
                            if (puntos == 0)
                            {
                                form.terminarJuego();
                            }
                            else
                            {
                                puntosBlancas += puntos;
                            }

                            destino.Name = reina.Name;
                            reina.Name = "v";

                            destino.Image = reina.Image;
                            reina.Image = null;
                        }
                        break;

                    case "b":
                        if (colorReina == "b")
                        {
                            MessageBox.Show("No puedes poner 2 piezas en el mismo lugar");
                        }
                        if (colorReina == "n")
                        {
                            int puntos = sumarPuntos(pieza);
                            if (puntos == 0)
                            {
                                form.terminarJuego();
                            }
                            else
                            {
                                puntosNegras += puntos;
                            }

                            destino.Name = reina.Name;
                            reina.Name = "v";

                            destino.Image = reina.Image;
                            reina.Image = null;
                        }
                        break;

                    default:
                        string aux = destino.Name;
                        destino.Name = reina.Name;
                        reina.Name = aux;

                        Image auxI = destino.Image;
                        destino.Image = reina.Image;
                        reina.Image = auxI;
                        break;
                }
            }
        }

        /// <summary>
        /// Le asigna la posicion correspondiente a un tablero real a cada espacio de la matriz.
        /// </summary>
        public void posicionesTablero()
        {
            for (int f = 0; f < 8; f++)
            {
                for (int c = 0; c < 8; c++)
                {
                    int fila = -1;

                    switch (f)
                    {
                        case 0:
                            fila = 8;
                            break;
                        case 1:
                            fila = 7;
                            break;
                        case 2:
                            fila = 6;
                            break;
                        case 3:
                            fila = 5;
                            break;
                        case 4:
                            fila = 4;
                            break;
                        case 5:
                            fila = 3;
                            break;
                        case 6:
                            fila = 2;
                            break;
                        case 7:
                            fila = 1;
                            break;
                        default:
                            break;
                    }

                    switch (c)
                    {
                        case 0:
                            posiciones[f, c] = fila.ToString() + "a";
                            break;
                        case 1:
                            posiciones[f, c] = fila.ToString() + "b";
                            break;
                        case 2:
                            posiciones[f, c] = fila.ToString() + "c";
                            break;
                        case 3:
                            posiciones[f, c] = fila.ToString() + "d";
                            break;
                        case 4:
                            posiciones[f, c] = fila.ToString() + "e";
                            break;
                        case 5:
                            posiciones[f, c] = fila.ToString() + "f";
                            break;
                        case 6:
                            posiciones[f, c] = fila.ToString() + "g";
                            break;
                        case 7:
                            posiciones[f, c] = fila.ToString() + "h";
                            break;
                        default:
                            break;
                    }
                }
            }

        }

        /// <summary>
        /// Asigna las imagenes a los botones.
        /// </summary>
        /// <param name="fila">Fila en la que se encuentra el boton al que se le quiere asignar imagen</param>
        /// <param name="columna">Columna en la que se encuentra el boton al que se le quiere asignar imagen</param>
        /// <returns>La imagen correspondiente a la posicion del boton</returns>
        public Image asignarPiezas(int fila, int columna)
        {
            string posicion = posiciones[fila,columna];

            switch (posicion)
            {
                //negras
                case "8a":
                    return Resources.nT; 
                case "8b":
                    return Resources.nC; 
                case "8c":
                    return Resources.nA; 
                case "8d":
                    return Resources.nQ; 
                case "8e":
                    return Resources.nR; 
                case "8f":
                    return Resources.nA;
                case "8g":
                    return Resources.nC;
                case "8h":
                    return Resources.nT;

                case "7a":                //Fila peones negros
                    return Resources.nP;
                case "7b":
                    return Resources.nP;
                case "7c":
                    return Resources.nP;
                case "7d":
                    return Resources.nP;
                case "7e":
                    return Resources.nP;
                case "7f":
                    return Resources.nP;
                case "7g":
                    return Resources.nP;
                case "7h":
                    return Resources.nP;
                //blancas
                case "1a":
                    return Resources.bT; 
                case "1b":
                    return Resources.bC; 
                case "1c":
                    return Resources.bA;  
                case "1d":
                    return Resources.bQ; 
                case "1e":
                    return Resources.bR;  
                case "1f":
                    return Resources.bA;
                case "1g":
                    return Resources.bC;
                case "1h":
                    return Resources.bT;

                case "2a":
                    return Resources.bP; //fila de peones blancos
                case "2b":
                    return Resources.bP;
                case "2c":
                    return Resources.bP;
                case "2d":
                    return Resources.bP;
                case "2e":
                    return Resources.bP;
                case "2f":
                    return Resources.bP;
                case "2g":
                    return Resources.bP;
                case "2h":
                    return Resources.bP;
                default:
                    return null;

            }

        }

        /// <summary>
        /// Le asigna el nombre a los botones.
        /// La primera letra corresponde al color "n" negra o "b" blanca y la segunda al tipo de pieza: P-Peones, C-Caballos, A-Alfiles,
        /// T-Torres, Q-Reina y R-Rey.
        /// </summary>
        /// <param name="fila">Fila en la que se encuentra el boton</param>
        /// <param name="columna">Columna en la que se encuenra el boton</param>
        /// <returns>Nombre correspondiente a la posicion en la que se encuentra, en el orden inicial</returns>
        public string nombreBoton(int fila, int columna)
        {
            string posicion = posiciones[fila, columna];

            switch (posicion)
            {
                case "8a":
                    return "nT";
                case "8b":
                    return "nC";
                case "8c":
                    return "nA";
                case "8d":
                    return "nQ";
                case "8e":
                    return "nR";
                case "8f":
                    return "nA";
                case "8g":
                    return "nC";
                case "8h":
                    return "nT";

                case "7a":
                    return "nP";
                case "7b":
                    return "nP";
                case "7c":
                    return "nP";
                case "7d":
                    return "nP";
                case "7e":
                    return "nP";
                case "7f":
                    return "nP";
                case "7g":
                    return "nP";
                case "7h":
                    return "nP";

                case "1a":
                    return "bT";
                case "1b":
                    return "bC";
                case "1c":
                    return "bA";
                case "1d":
                    return "bQ";
                case "1e":
                    return "bR";
                case "1f":
                    return "bA";
                case "1g":
                    return "bC";
                case "1h":
                    return "bT";

                case "2a":
                    return "bP";
                case "2b":
                    return "bP";
                case "2c":
                    return "bP";
                case "2d":
                    return "bP";
                case "2e":
                    return "bP";
                case "2f":
                    return "bP";
                case "2g":
                    return "bP";
                case "2h":
                    return "bP";
                default:
                    return "v";

            }

        }

    }
}
