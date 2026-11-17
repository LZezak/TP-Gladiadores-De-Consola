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

            int[] Vida = new int[CantJugadores];
            int[] CantidadVidaMaxJugadores = new int[CantJugadores];
            int[] Ataque = new int[CantJugadores];
            int[] Defensa = new int[CantJugadores];
            int[] DañoAcumulado = new int[CantJugadores];
            int[] RecuperacionesUsadas = new int[CantJugadores];
            string[] NombresGladiadores = new string[CantJugadores]; 
            string [] MVP = new string[CantJugadores];
            int CantTurnos = 0;

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
                if (SumaAtributos != PuntosTotales)
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
                    if (SumaAtributos > PuntosTotales)
                    {
                        Console.WriteLine("Se pasa por " + (SumaAtributos - PuntosTotales) + " puntos");
                    }
                    if (SumaAtributos < PuntosTotales)
                    {
                        Console.WriteLine("Le faltan " + (PuntosTotales - SumaAtributos) + " puntos");
                    }
                    Console.WriteLine(" ");
                    Vida[i] = AsignarSaludOtraVez(Vida[i], i, NombresGladiadores, VidaMaxCons, VidaMin);
                    Ataque[i] = AsignarAtaqueOtraVez(Ataque[i], i, NombresGladiadores, AtaqueMax, AtaqueMin);
                    Defensa[i] = AsignarDefensaOtraVez(Defensa[i], i, NombresGladiadores, DefensaMax, DefensaMin);
                    i--;
                }
            }
            CantidadVidaMaxJugadores = Vida;
            EstadoDelTurno(Modalidad, NombresGladiadores, Vida, Equipo1, Equipo2, turno);
     
        }

        static void EstadoDelTurno(int Modalidad, string[] NombresGladiadores, int[] Vida, string Equipo1, string Equipo2, int turno)
        {
            Console.WriteLine("----- [Comienzo del Turno " + turno + "] -----");
            Console.WriteLine("--- " + Equipo1 + " ---");
            for (int i = 0; i < Modalidad; i++)
            {
                Console.WriteLine(NombresGladiadores[i] + ": " + Vida[i] + " HP");
            }
            Console.WriteLine("--- " + Equipo2 + " ---");
            for (int i = 0; i < Modalidad; i++)
            {
                Console.WriteLine(NombresGladiadores[i] + ": " + Vida[i] + " HP");
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
        static int AsignarSaludOtraVez(int Health, int i, string[] GladiNameHealtAgain, int MaxHealthAgain, int MinHealthAgain)
        {
            bool Correcto;
            do
            {
                Correcto = true;
                Console.Write("Salud gladiador ¨" + GladiNameHealtAgain[i] + "¨ (min. 10 - max. 25): ");
                Health = int.Parse(Console.ReadLine());
                if (Health < MinHealthAgain || Health > MaxHealthAgain)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    Correcto = false;
                }
            }
            while (Correcto == false);
            return Health;
        }
        static int AsignarAtaqueOtraVez(int Atack, int i, string[] GladiNameAtackAgain, int MaxAtackAgain, int MinAtackAgain)
        {
            bool Correcto;
            do
            {
                Correcto = true;
                Console.Write("Ataque gladiador ¨" + GladiNameAtackAgain[i] + "¨ (min. 5 - max. 20): ");
                Atack = int.Parse(Console.ReadLine());
                if (Atack < MinAtackAgain || Atack > MaxAtackAgain)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    Correcto = false;
                }
            }
            while (Correcto == false);
            return Atack;
        }
        static int AsignarDefensaOtraVez(int Defense, int i, string[] GladiNameDefenseAgain, int MaxDefenseAgain, int MinDefenseAgain)
        {
            bool Correcto;
            do
            {
                Correcto = true;
                Console.Write("Defensa Gladiador ¨" + GladiNameDefenseAgain[i] + "¨ (min. 1 - max. 10): ");
                Defense = int.Parse(Console.ReadLine());
                if (Defense < MinDefenseAgain || Defense > MaxDefenseAgain)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                    Correcto = false;
                }
            }
            while (Correcto == false);
            return Defense;
        }
        static bool Recuperarse(int[] Vida, int[] VidaMaxima, int[] RecuperacionesUsadas, string[] NombresGladiadores, int indice, int MaxRecuperaciones, int PuntosCuracion)
        {
            if (RecuperacionesUsadas[indice] >= MaxRecuperaciones)
            {
                Console.WriteLine("El gladiador " + NombresGladiadores[indice] + " no tiene más curaciones disponibles. Elegí otra acción.");
                return false;
            }

            if (Vida[indice] == VidaMaxima[indice])
            {
                Console.WriteLine("El gladiador " + NombresGladiadores[indice] + " tiene su vida al máximo. Elegí otra acción.");
                return false;
            }

            RecuperacionesUsadas[indice]++;
            Vida[indice] = Vida[indice] + PuntosCuracion;

            if (Vida[indice] > VidaMaxima[indice])
            {
                Vida[indice] = VidaMaxima[indice];
            }

            Console.WriteLine(NombresGladiadores[indice] + " se recupera y queda con " + Vida[indice] + "/" + VidaMaxima[indice] + " de vida.");
            return true;
        }
        static bool EquipoDerrotado(int[] VidaGladiadores, int inicio, int fin)
        {
            for (int i = inicio; i < fin; i++)
            {
                if (VidaGladiadores[i] > 0)
                {
                    return false;
                }
            }
            return true;
        }
                static int ObtenerDañoMaximo(int[] AcumulatedDamage, int CantidadJugadores)
        {
            int MaxDaño = AcumulatedDamage[0];
            for (int i = 1; i < CantidadJugadores; i++)
            {
                if (AcumulatedDamage[i] > MaxDaño)
                {
                    MaxDaño = AcumulatedDamage[i];
                }
            }
            return MaxDaño;
        }

        static void MostrarMVP(string[] NombresGladiadores, int[] AcumulatedDamage, int CantidadJugadores)
        {
            int MaxDaño = ObtenerDañoMaximo(AcumulatedDamage, CantidadJugadores);
            Console.Write("MVP del torneo (" + MaxDaño + " de daño causado): ");
            bool EsElPrimero = true;
            for (int i = 0; i < CantidadJugadores; i++)
            {
                if (AcumulatedDamage[i] == MaxDaño)
                {
                    if (EsElPrimero == false)
                    {
                        Console.Write(", ");
                    }
                    Console.Write(NombresGladiadores[i]);
                    EsElPrimero = false;
                }
            }
            Console.WriteLine();
        }
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
    }
}
