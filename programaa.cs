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
            Modalidad = ElegirModalidad();
            CantJugadores = Modalidad * 2;
            const int PuntosTotales = 40;
            const int VidaMin = 10;
            const int VidaMaxCons = 25;

            const int DefensaMin = 1;
            const int DefensaMax = 10;
            const int MaxRecuperaciones = 2;

            string[] EquiposNombres = new string[2];

            string[] Nombre = new string[CantJugadores];
            int[] Vida = new int[CantJugadores];
            int[] Ataque = new int[CantJugadores];
            int[] Defensa = new int[CantJugadores];
            int[] DañoAcumulado = new int[CantJugadores];
            int[] RecuperacionesUsadas = new int[CantJugadores];

            AsignarNombreEquipo(EquiposNombres);
            InicializarEquipos(Modalidad, Nombre, Vida, Ataque, Defensa, EquiposNombres);


        }
        static int ElegirModalidad()
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

        static void AsignarNombreEquipo(string[] equipos)
        {

            for (int i = 0; i < equipos.Length; i++)
            {
                Console.WriteLine("");

                bool esValido;
                do
                {
                    esValido = true;
                    Console.Write("Nombre Equipo " + (i + 1) + ": ");
                    equipos[i] = Console.ReadLine();
                    for (int j = 0; j < i; j++)
                    {
                        if (equipos[i] == equipos[j])
                        {
                            esValido = false;
                            Console.WriteLine("Ingrese un nombre que no este en uso");
                        }
                    }

                } while (!esValido);

            }



        }
        static void InicializarEquipos(int modalidad, string[] Nombre, int[] Vida, int[] Ataque, int[] Defensa, string[] NombreEquipos)
        {
            Console.WriteLine("");
            Console.WriteLine("--- EQUIPO '" +  NombreEquipos[0] + "' ---");
            for (int i = 0; i < modalidad; i++)
            {
                bool gladiadorValido;
                do
                {
                    Console.WriteLine("GLADIADOR " + (i + 1));
                    AsignarNombre(i, Nombre);
                    int vida = AsignarSalud(i, Vida);
                    int ataque = AsignarAtaque(i, Ataque);
                    int defensa = AsignarDefensa(i, Defensa);
                    gladiadorValido = ComprobarValores(vida, ataque, defensa);
                    Console.WriteLine("");

                } while (!gladiadorValido);
            }

            Console.WriteLine("--- EQUIPO '" + NombreEquipos[1] + "' ---");

            for (int i = 0; i < modalidad; i++)
            {
                bool gladiadorValido;
                do
                {
                    Console.WriteLine("GLADIADOR " + (i + 1));
                    AsignarNombre((i + modalidad), Nombre);
                    int vida = AsignarSalud((i + modalidad), Vida);
                    int ataque = AsignarAtaque((i + modalidad), Ataque);
                    int defensa = AsignarDefensa((i + modalidad), Defensa);
                    gladiadorValido = ComprobarValores(vida, ataque, defensa);
                    Console.WriteLine("");

                } while (!gladiadorValido);
            }


        }

        static void AsignarNombre(int posicion, string[] nombres)
        {

            string nombre;
            bool nombreEsValido;

            do
            {
                nombreEsValido = true;
                Console.Write("Nombre: ");
                nombres[posicion] = Console.ReadLine();
                for (int i = 0; i < posicion; i++)
                {
                    if (nombres[posicion] == nombres[i])
                    {
                        nombreEsValido = false;
                        Console.WriteLine("Ingrese un nombre que no este repetido");
                    }
                }
            } while (nombreEsValido == false);

        }

        static int AsignarSalud(int posicion, int[] vidas)
        {
            const int VidaMin = 10;
            const int VidaMaxCons = 25;

            int salud;

            do
            {
                Console.Write("Salud (10-25): ");
                salud = int.Parse(Console.ReadLine());
                if (salud < VidaMin || salud > VidaMaxCons)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                }
            }
            while (salud < VidaMin || salud > VidaMaxCons);

            vidas[posicion] = salud;

            return salud;

        }


        static int AsignarAtaque(int posicion, int[] ataques)
        {
            const int AtaqueMin = 5;
            const int AtaqueMax = 20;

            int ataque;

            do
            {
                Console.Write("Ataque (5-20): ");
                ataque = int.Parse(Console.ReadLine());
                if (ataque < AtaqueMin || ataque > AtaqueMax)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                }
            } while (ataque < AtaqueMin || ataque > AtaqueMax);

            ataques[posicion] = ataque;

            return ataque;

        }


        static int AsignarDefensa(int posicion, int[] defensas)
        {
            const int DefensaMin = 1;
            const int DefensaMax = 10;

            int defensa;

            do
            {
                Console.Write("Defensa (1-10): ");
                defensa = int.Parse(Console.ReadLine());
                if (defensa < DefensaMin || defensa > DefensaMax)
                {
                    Console.WriteLine("Valor invalido. Intente de nuevo");
                }
            } while (defensa < DefensaMin || defensa > DefensaMax);

            defensas[posicion] = defensa;

            return defensa;
        }


        static bool ComprobarValores(int salud, int ataque, int defensa)
        {
            bool esValido = (salud + ataque + defensa) == 40;
            if (!esValido)
            {
                Console.WriteLine("La suma de los atributos tiene que ser 40");
            }
            return esValido;
        }

    }
}