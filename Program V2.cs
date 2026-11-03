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
            Modalidad = ElegirModalidad(Modalidad);
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
            Console.WriteLine("Tienes 40 puntos por gladiador para repartir entre los 3 atributos de cada gladiador (vida, ataque y defensa)");
            AsignarSalud(Vida, CantJugadores, VidaMin, VidaMaxCons);
            AsignarAtaque(Ataque, CantJugadores, AtaqueMin, AtaqueMax);
            AsignarDefensa(Defensa, CantJugadores, DefensaMin, DefensaMax);
            for (int i = 0; i != CantJugadores; i++)
            {
                int SumaAtributos = Vida[i] + Ataque[i] + Defensa[i];
                int Jugador = 0;
                if (SumaAtributos != 40)
                {
                    if ((i + 1) <= (CantJugadores / 2))
                    {
                        Jugador = 1;
                    }
                    else
                    {
                        Jugador = 2;
                    }
                    int GladiadorNum = (i % (CantJugadores / 2)) + 1;
                    Console.WriteLine("Distribución de atributos del gladiador " + GladiadorNum + " de jugador " + Jugador + " invalida");
                    if (SumaAtributos > 40)
                    {
                        Console.WriteLine("Se pasa por " + (SumaAtributos - PuntosTotales) + " puntos");
                    }
                    if (SumaAtributos < 40)
                    {
                        Console.WriteLine("Le faltan " + (PuntosTotales - SumaAtributos) + " puntos");
                    }
                    Vida[i] = AsignarSaludOtraVez(Vida[i], i);
                    Ataque[i] = AsignarAtaqueOtraVez(Ataque[i], i);
                    Defensa[i] = AsignarDefensaOtraVez(Defensa[i], i);
                    i--;
                }
            }
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

                if (texto ==  "1" || texto == "2" || texto == "3" || texto == "5")
                {
                    Console.WriteLine("Se ha elegido la modalidad " + texto + " contra " + texto);
                    return int.Parse(texto);
                }       

                Console.WriteLine("Modalidad inválida. Solo se acepta 1, 2, 3 o 5");
                Console.WriteLine();
            }
        }
        static int[] AsignarSalud(int[] Health, int CantPlayer, int MinHealth, int MaxHealth)
        {
            int d = 1;
            Console.WriteLine("Jugador 1:");
            for (int i = 0; i <= ((CantPlayer / 2) - 1); i++)
            {
                Console.Write("Salud Gladiador " + d + " (min. 10 - max. 25): ");
                Health[i] = int.Parse(Console.ReadLine());
                if (Health[i] < MinHealth || Health[i] > MaxHealth)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    i--;
                    d--;
                }
                d++;
            }
            d = 1;
            Console.WriteLine("Jugador 2:");
            for (int i = (CantPlayer / 2); i <= (CantPlayer - 1); i++)
            {
                Console.Write("Salud Gladiador " + d + " (min. 10 - max. 25): ");
                Health[i] = int.Parse(Console.ReadLine());
                if (Health[i] < MinHealth || Health[i] > MaxHealth)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    i--;
                    d--;
                }
                d++;
            }
            return Health;
        }
        static int[] AsignarAtaque(int[] Atack, int CantPlayer, int MinAtack, int MaxAtack)
        {
            int d = 1;
            Console.WriteLine("Jugador 1:");
            for (int i = 0; i <= ((CantPlayer / 2) - 1); i++)
            {
                Console.Write("Ataque Gladiador " + d + " (min. 5 - max. 20): ");
                Atack[i] = int.Parse(Console.ReadLine());
                if (Atack[i] < MinAtack || Atack[i] > MaxAtack)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    i--;
                    d--;
                }
                d++;
            }
            d = 1;
            Console.WriteLine("Jugador 2:");
            for (int i = (CantPlayer / 2); i <= (CantPlayer - 1); i++)
            {
                Console.Write("Ataque Gladiador " + d + " (min. 5 - max. 20): ");
                Atack[i] = int.Parse(Console.ReadLine());
                if (Atack[i] < MinAtack || Atack[i] > MaxAtack)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    i--;
                    d--;
                }
                d++;
            }
            return Atack;
        }
        static int[] AsignarDefensa(int[] Defense, int CantPlayer, int MinDefense, int MaxDefense)
        {
            int d = 1;
            Console.WriteLine("Jugador 1:");
            for (int i = 0; i <= ((CantPlayer / 2) - 1); i++)
            {
                Console.Write("Defensa Gladiador " + d + " (min. 1 - max. 10): ");
                Defense[i] = int.Parse(Console.ReadLine());
                if (Defense[i] < MinDefense || Defense[i] > MaxDefense)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    i--;
                    d--;
                }
                d++;
            }
            d = 1;
            Console.WriteLine("Jugador 2:");
            for (int i = (CantPlayer / 2); i <= (CantPlayer - 1); i++)
            {
                Console.Write("Defensa Gladiador " + d + " (min. 1 - max. 10): ");
                Defense[i] = int.Parse(Console.ReadLine());
                if (Defense[i] < MinDefense || Defense[i] > MaxDefense)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    i--;
                    d--;
                }
                d++;
            }
            return Defense;
        }
        static int AsignarSaludOtraVez(int Health, int i)
        {
            bool Correcto;
            do
            {
                Correcto = true;
                Console.Write("Salud Gladiador " + (i + 1) + " (min. 10 - max. 25): ");
                Health = int.Parse(Console.ReadLine());
                if (Health < 10 || Health > 25)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    Correcto = false;
                }
            }
            while (Correcto == false);
            return Health;
        }
        static int AsignarAtaqueOtraVez(int Atack, int i)
        {
            bool Correcto;
            do
            {
                Correcto = true;
                Console.Write("Ataque Gladiador " + (i + 1) + " (min. 5 - max. 20): ");
                Atack = int.Parse(Console.ReadLine());
                if (Atack < 5 || Atack > 20)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    Correcto = false;
                }
            }
            while (Correcto == false);
            return Atack;
        }
        static int AsignarDefensaOtraVez(int Defense, int i)
        {
            bool Correcto;
            do
            {
                Correcto = true;
                Console.Write("Defensa Gladiador " + (i + 1) + " (min. 1 - max. 10): ");
                Defense = int.Parse(Console.ReadLine());
                if (Defense < 1 || Defense > 10)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    Correcto = false;
                }
            }
            while (Correcto == false);
            return Defense;
        }
    }
}
