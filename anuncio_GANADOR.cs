using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void AnunciarGanador(string Equipo1, string Equipo2, string[] NombresGladiadores, int[] Vida, int CantJugadores, int TurnosTotales)
        {
            int VivosEquipo1 = 0;
            int VivosEquipo2 = 0;

            for (int i = 0; i < CantJugadores; i++)
            {
                if (Vida[i] > 0)
                {
                    if (i < CantJugadores / 2)
                    {
                        VivosEquipo1++;
                    }
                    else
                    {
                        VivosEquipo2++;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("========== FIN DEL TORNEO ==========");

            if (VivosEquipo1 > 0)
            {
                Console.WriteLine("Equipo ganador: " + Equipo1);
                Console.WriteLine("Ganador: Jugador 1");

                Console.WriteLine("Gladiadores que quedaron en pie:");

                for (int i = 0; i < CantJugadores / 2; i++)
                {
                    if (Vida[i] > 0)
                    {
                        Console.WriteLine("- " + NombresGladiadores[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("Equipo ganador: " + Equipo2);
                Console.WriteLine("Ganador: Jugador 2");

                Console.WriteLine("Gladiadores que quedaron en pie:");

                for (int i = CantJugadores / 2; i < CantJugadores; i++)
                {
                    if (Vida[i] > 0)
                    {
                        Console.WriteLine("- " + NombresGladiadores[i]);
                    }
                }
            }

            Console.WriteLine("La partida terminó en " + TurnosTotales + " turnos.");
        }
    }
}