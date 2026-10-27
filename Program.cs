using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int Modalidad = 0;
            int CantJugadores = 0;
            ElegirModalidad(Modalidad);
            CantJugadores = Modalidad * 2;
            const int PuntosTotales = 40;
            const int VidaMin = 10;
            const int VidaMaxCons = 25;
            const int AtaqueMin = 5;
            const int AtaqueMax = 20;
            const int DefensaMin = 1;
            const int DefensaMax = 10;
            const int MaxRecuperaciones = 2;

            string[] Nombre = new string[CantJugadores];
            int[] Vida = new int[CantJugadores];
            int[] Ataque = new int[CantJugadores];
            int[] Defensa = new int[CantJugadores];
            int[] DañoAcumulado = new int[CantJugadores];
            int[] RecuperacionesUsadas = new int[CantJugadores];
        }
        static int ElegirModalidad(int modalidad)
        {    
            Console.WriteLine("================ JUEGO ================");
            Console.WriteLine();
            Console.WriteLine("Eliga entre las modalidad que desea jugar |1v1|, |2v2|, |3v3| y |5v5| ");          
            while (true)
            {
                string texto;
                Console.Write("Elegí la modalidad (1, 2, 3 o 5): ");
                texto = Console.ReadLine();

                if (texto == "1")
                {
                    Console.WriteLine("Se ha elegido la modalidad Uno Contra Uno");
                    return 1;
                }
                if (texto == "2")
                {
                    Console.WriteLine("Se ha elegido la modalidad Dos Contra Dos");
                    return 2;
                }
                if (texto == "3")
                {
                    Console.WriteLine("Se ha elegido la modalidad Tres Contra Tres");
                    return 3;
                }
                if (texto == "5")
                {
                    Console.WriteLine("Se ha elegido la modalidad Cinco Contra Cinco");
                    return 5;
                }

                Console.WriteLine("Modalidad inválida. Solo se acepta 1, 2, 3 o 5");
                Console.WriteLine();
            }
        }
        static int AsignarSalud(int[] Health, int CantPlayer)
        {
            int d = 1;
            Console.WriteLine("Jugador 1:");
            for (int i = 0; i <= ((CantPlayer / 2) - 1); i++)
            {
                Console.Write("Salud Gladiador " + d + " (min. 10 - max. 25): ");
                Health[i] = int.Parse(Console.ReadLine());
                d++;
            }
            d = (CantPlayer / 2);
            Console.WriteLine("Jugador 2:");
            for (int i = ((CantPlayer / 2) - 1); i <= (CantPlayer - 1); i++)
            {
                Console.Write("Salud Gladiador " + d + " (min. 10 - max. 25): ");
                Health[i] = int.Parse(Console.ReadLine());
                d++;
            }
            return Health[];
        }
        static int AsignarAtaque(int[] Atack, int CantPlayer)
        {
            int d = 1;
            Console.WriteLine("Jugador 1:");
            for (int i = 0; i <= ((CantPlayer / 2) - 1); i++)
            {
                Console.Write("Ataque Gladiador " + d + " (min. 5 - max. 20): ");
                Atack[i] = int.Parse(Console.ReadLine());
                d++;
            }
            d = (CantPlayer / 2);
            Console.WriteLine("Jugador 2:");
            for (int i = ((CantPlayer / 2) - 1); i <= (CantPlayer - 1); i++)
            {
                Console.Write("Ataque Gladiador " + d + " (min. 5 - max. 20): ");
                Atack[i] = int.Parse(Console.ReadLine());
                d++;
            }
            return Atack[];
        }
        static int AsignarDefensa(int[] Defense, int CantPlayer)
        {
            int d = 1;
            Console.WriteLine("Jugador 1:");
            for (int i = 0; i <= ((CantPlayer / 2) - 1); i++)
            {
                Console.Write("Defensa Gladiador " + d + " (min. 1 - max. 10): ");
                Defense[i] = int.Parse(Console.ReadLine());
                d++;
            }
            d = (CantPlayer / 2);
            Console.WriteLine("Jugador 2:");
            for (int i = ((CantPlayer / 2) - 1); i <= (CantPlayer - 1); i++)
            {
                Console.Write("Defensa Gladiador " + d + " (min. 1 - max. 10): ");
                Defense[i] = int.Parse(Console.ReadLine());
                d++;
            }
            return Defense[];
        }
    }
    }
