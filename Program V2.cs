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

            const int PuntosTotales = 40;
            const int VidaMin = 10;
            const int VidaMaxCons = 25;
            const int AtaqueMin = 5;
            const int AtaqueMax = 20;
            const int DefensaMin = 1;
            const int DefensaMax = 10;
            const int MaxRecuperaciones = 2;

            int Modalidad = 0;
            int CantJugadores = 0;
            Modalidad = ElegirModalidad(Modalidad);
            CantJugadores = Modalidad * 2;

            string[] Nombre = new string[CantJugadores];
            int[] Vida = new int[CantJugadores];
            int[] Ataque = new int[CantJugadores];
            int[] Defensa = new int[CantJugadores];
            int[] DañoAcumulado = new int[CantJugadores];
            int[] RecuperacionesUsadas = new int[CantJugadores];
            string[] NombresGladiadores = new string[CantJugadores]; 

            string Equipo1 = AsignarNombreEquipo(1);
            string Equipo2 = AsignarNombreEquipo(2);
            AsignarNombreGladiador(NombresGladiadores, CantJugadores, Equipo1, Equipo2);
            Console.WriteLine(" ");
            Console.WriteLine("Tienes 40 puntos por gladiador para repartir entre los 3 atributos de cada gladiador (vida, ataque y defensa)");
            AsignarSalud(Vida, CantJugadores, VidaMin, VidaMaxCons, Equipo1, Equipo2, NombresGladiadores);
            AsignarAtaque(Ataque, CantJugadores, AtaqueMin, AtaqueMax, Equipo1, Equipo2, NombresGladiadores);
            AsignarDefensa(Defensa, CantJugadores, DefensaMin, DefensaMax, Equipo1, Equipo2, NombresGladiadores);
            for (int i = 0; i != CantJugadores; i++)
            {
                int SumaAtributos = Vida[i] + Ataque[i] + Defensa[i];
                string Jugador;
                if (SumaAtributos != 40)
                {
                    if ((i + 1) <= (CantJugadores / 2))
                    {
                        Jugador = Equipo1;
                    }
                    else
                    {
                        Jugador = Equipo2;
                    }
                    int GladiadorNum = (i % (CantJugadores / 2)) + 1;
                    Console.WriteLine(" ");
                    Console.WriteLine("Distribución de atributos del gladiador ¨" + NombresGladiadores[i] + "¨ de " + Jugador + " invalida");
                    if (SumaAtributos > 40)
                    {
                        Console.WriteLine("Se pasa por " + (SumaAtributos - PuntosTotales) + " puntos");
                    }
                    if (SumaAtributos < 40)
                    {
                        Console.WriteLine("Le faltan " + (PuntosTotales - SumaAtributos) + " puntos");
                    }
                    Console.WriteLine(" ");
                    Vida[i] = AsignarSaludOtraVez(Vida[i], i, NombresGladiadores);
                    Ataque[i] = AsignarAtaqueOtraVez(Ataque[i], i, NombresGladiadores);
                    Defensa[i] = AsignarDefensaOtraVez(Defensa[i], i, NombresGladiadores);
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
                if (texto == "1" || texto == "2" || texto == "3" || texto == "5")
                {
                    Console.WriteLine("Se ha elegido la modalidad " + texto + " contra " + texto);
                    return int.Parse(texto);
                }
                Console.WriteLine("Modalidad inválida. Solo se acepta 1, 2, 3 o 5");
                Console.WriteLine();
            }
        }
        static string AsignarNombreEquipo(int Num)
        {
            Console.WriteLine(" ");
            Console.Write("Elija el nombre de su equipo jugador " + Num + ": ");
            return Console.ReadLine();
        }
        static void AsignarNombreGladiador(string[] Nombres, int CantPlayer, string Team1, string Team2)
        {
            Console.WriteLine(" ");
            for (int i = 0; i < CantPlayer; i++)
            {
                string EquipoActual;
                if (i < CantPlayer / 2)
                {
                    EquipoActual = Team1;
                }
                else
                {
                    EquipoActual = Team2;
                }
                int GladiadorNum = (i % (CantPlayer / 2)) + 1;

                bool NombreValido = false;

                while (!NombreValido)
                {
                    Console.Write("Ingrese el nombre del gladiador " + GladiadorNum + " de " + EquipoActual + ": ");
                    string NombreIngresado = Console.ReadLine();
                    bool SoloEspacios = true;
                    for (int k = 0; k < NombreIngresado.Length; k++)
                    {
                        if (NombreIngresado[k] != ' ')
                        {
                            SoloEspacios = false;
                        }
                    }

                    if (NombreIngresado == "" || SoloEspacios)
                    {
                        Console.WriteLine("El nombre no puede quedar vacío. Intentá de nuevo.");
                    }
                    else
                    {
                        bool YaExiste = false;
                        for (int j = 0; j < i && !YaExiste; j++)
                        {
                            if (Nombres[j] == NombreIngresado)
                            {
                                YaExiste = true;
                            }
                        }

                        if (YaExiste)
                        {
                            Console.WriteLine("Ese nombre ya fue elegido por otro gladiador. Elegí otro.");
                        }
                        else
                        {
                            Nombres[i] = NombreIngresado;
                            NombreValido = true;
                        }
                    }
                }
            }
        }
        static void AsignarSalud(int[] Health, int CantPlayer, int MinHealth, int MaxHealth, string Team1Healt, string Team2Healt, string[] GladiNameHealt)
        {
            Console.WriteLine(" ");
            Console.WriteLine(Team1Healt);
            for (int i = 0; i <= ((CantPlayer / 2) - 1); i++)
            {
                Console.Write("Salud gladiador ¨" + GladiNameHealt[i] + "¨ (min. 10 - max. 25): ");
                Health[i] = int.Parse(Console.ReadLine());
                if (Health[i] < MinHealth || Health[i] > MaxHealth)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    i--;
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine(Team2Healt);
            for (int i = (CantPlayer / 2); i <= (CantPlayer - 1); i++)
            {
                Console.Write("Salud gladiador ¨" + GladiNameHealt[i] + "¨ (min. 10 - max. 25): ");
                Health[i] = int.Parse(Console.ReadLine());
                if (Health[i] < MinHealth || Health[i] > MaxHealth)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    i--;
                }
            }
        }
        static void AsignarAtaque(int[] Atack, int CantPlayer, int MinAtack, int MaxAtack, string Team1Atack, string Team2Atack, string[] GladiNameAtack)
        {
            Console.WriteLine(" ");
            Console.WriteLine(Team1Atack);
            for (int i = 0; i <= ((CantPlayer / 2) - 1); i++)
            {
                Console.Write("Ataque gladiador ¨" + GladiNameAtack[i] + "¨ (min. 5 - max. 20): ");
                Atack[i] = int.Parse(Console.ReadLine());
                if (Atack[i] < MinAtack || Atack[i] > MaxAtack)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    i--;
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine(Team2Atack);
            for (int i = (CantPlayer / 2); i <= (CantPlayer - 1); i++)
            {
                Console.Write("Ataque gladiador ¨" + GladiNameAtack[i] + "¨ (min. 5 - max. 20): ");
                Atack[i] = int.Parse(Console.ReadLine());
                if (Atack[i] < MinAtack || Atack[i] > MaxAtack)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    i--;
                }
            }
        }
        static void AsignarDefensa(int[] Defense, int CantPlayer, int MinDefense, int MaxDefense, string Team1Defense, string Team2Defense, string[] GladiNameDefense)
        {
            Console.WriteLine(" ");
            Console.WriteLine(Team1Defense);
            for (int i = 0; i <= ((CantPlayer / 2) - 1); i++)
            {
                Console.Write("Defensa gladiador ¨" + GladiNameDefense[i] + "¨ (min. 1 - max. 10): ");
                Defense[i] = int.Parse(Console.ReadLine());
                if (Defense[i] < MinDefense || Defense[i] > MaxDefense)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    i--;
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine(Team2Defense);
            for (int i = (CantPlayer / 2); i <= (CantPlayer - 1); i++)
            {
                Console.Write("Defensa gladiador ¨" + GladiNameDefense[i] + "¨ (min. 1 - max. 10): ");
                Defense[i] = int.Parse(Console.ReadLine());
                if (Defense[i] < MinDefense || Defense[i] > MaxDefense)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    i--;
                }
            }
        }
        static int AsignarSaludOtraVez(int Health, int i, string[] GladiNameHealtAgain)
        {
            bool Correcto;
            do
            {
                Correcto = true;
                Console.Write("Salud gladiador ¨" + GladiNameHealtAgain[i] + "¨ (min. 10 - max. 25): ");
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
        static int AsignarAtaqueOtraVez(int Atack, int i, string[] GladiNameAtackAgain)
        {
            bool Correcto;
            do
            {
                Correcto = true;
                Console.Write("Ataque gladiador ¨" + GladiNameAtackAgain[i] + "¨ (min. 5 - max. 20): ");
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
        static int AsignarDefensaOtraVez(int Defense, int i, string[] GladiNameDefenseAgain)
        {
            bool Correcto;
            do
            {
                Correcto = true;
                Console.Write("Defensa Gladiador ¨" + GladiNameDefenseAgain[i] + "¨ (min. 1 - max. 10): ");
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
