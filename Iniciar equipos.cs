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
                    Console.Write("Elija el nombre de su equipo jugador " + (i + 1) + ": ");
                    equipos[i] = Console.ReadLine();
                    bool esNulo = EsNulo(equipos[i]);
                    if (esNulo)
                    {
                        esValido = false;
                        Console.WriteLine("Ingresaste un valor nulo. Intentalo nuevamente");
                    }
                    else
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if (equipos[i] == equipos[j])
                            {
                                esValido = false;
                                Console.WriteLine("Ingrese un nombre que no este en uso");
                            }
                        }
                    }
                } while (!esValido);

            }

        }
        static void InicializarEquipos(int modalidad, string[] Nombre, int[] Vida, int[] Ataque, int[] Defensa, string[] NombreEquipos)
        {
            Console.WriteLine("");
            Console.WriteLine(" --- EQUIPO '" + NombreEquipos[0] + "' ---");
            Console.WriteLine("Tienes 40 puntos por gladiador para repartir entre los 3 atributos de cada gladiador (vida, ataque y defensa)");
            for (int i = 0; i < modalidad; i++)
            {
                bool gladiadorValido;
                Console.WriteLine("GLADIADOR " + (i + 1));
                string nombre = AsignarNombre(i, Nombre);
                do
                {
                    int vida = AsignarSalud(i, Vida);
                    int ataque = AsignarAtaque(i, Ataque);
                    int defensa = AsignarDefensa(i, Defensa);
                    gladiadorValido = ComprobarValores(vida, ataque, defensa, nombre);
                    Console.WriteLine("");

                } while (!gladiadorValido);
            }

            Console.WriteLine(" --- EQUIPO '" + NombreEquipos[1] + "' ---");
            Console.WriteLine("Tienes 40 puntos por gladiador para repartir entre los 3 atributos de cada gladiador (vida, ataque y defensa)");

            for (int i = 0; i < modalidad; i++)
            {
                bool gladiadorValido;
                Console.WriteLine("GLADIADOR " + (i + 1));
                string nombre = AsignarNombre((i + modalidad), Nombre);
                do
                {
                    int vida = AsignarSalud((i + modalidad), Vida);
                    int ataque = AsignarAtaque((i + modalidad), Ataque);
                    int defensa = AsignarDefensa((i + modalidad), Defensa);
                    gladiadorValido = ComprobarValores(vida, ataque, defensa, nombre);
                    Console.WriteLine("");

                } while (!gladiadorValido);
            }
        }

        static string AsignarNombre(int posicion, string[] nombres)
        {
            bool nombreEsValido;
            string nombre;
            do
            {
                nombreEsValido = true;
                Console.Write("Nombre: ");
                nombre = Console.ReadLine();
                bool esNulo = EsNulo(nombre);
                if (esNulo)
                {
                    nombreEsValido = false;
                    Console.WriteLine("Ingresaste un valor nulo. Intentalo nuevamente");
                }
                else
                {
                    for (int i = 0; i < posicion; i++)
                    {
                        if (nombre == nombres[i])
                        {
                            nombreEsValido = false;
                            Console.WriteLine("Ingrese un nombre que no este repetido");
                        }
                    }
                }

            } while (nombreEsValido == false);

            nombres[posicion] = nombre;

            return nombre;
        }

        static int AsignarSalud(int posicion, int[] vidas)
        {
            const int VidaMin = 10;
            const int VidaMax = 25;

            string salud;
            int saludInt = 0;
            bool esSaludValida;

            do
            {
                esSaludValida = false;
                Console.Write("Salud (min. 10 - max. 25): ");
                salud = Console.ReadLine();
                if (EsValorNumerico(salud))
                {
                    saludInt = int.Parse(salud);
                    if (saludInt < VidaMin || saludInt > VidaMax)
                    {
                        Console.WriteLine("Valor invalido. Intente de nuevo");
                    }
                    else
                    {
                        esSaludValida = true;
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese un valor numerico");
                }
            }
            while (esSaludValida == false);

            vidas[posicion] = saludInt;

            return saludInt;
        }

        static int AsignarAtaque(int posicion, int[] ataques)
        {
            const int AtaqueMin = 5;
            const int AtaqueMax = 20;

            string ataque;
            int ataqueInt = 0;
            bool esAtaqueValido;

            do
            {
                esAtaqueValido = false;
                Console.Write("Ataque (min. 5 - max. 20): ");
                ataque = Console.ReadLine();
                if (EsValorNumerico(ataque))
                {
                    ataqueInt = int.Parse(ataque);
                    if (ataqueInt < AtaqueMin || ataqueInt > AtaqueMax)
                    {
                        Console.WriteLine("Valor invalido. Intente de nuevo");
                    }
                    else
                    {
                        esAtaqueValido = true;
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese un valor numerico");
                }

            } while (esAtaqueValido == false);

            ataques[posicion] = ataqueInt;

            return ataqueInt;
        }


        static int AsignarDefensa(int posicion, int[] defensas)
        {
            const int DefensaMin = 1;
            const int DefensaMax = 10;

            string defensa;
            int defensaInt = 0;
            bool esDefensaValida;

            do
            {
                esDefensaValida = false;
                Console.Write("Defensa (min. 1 - max. 10): ");
                defensa = Console.ReadLine();
                if (EsValorNumerico(defensa))
                {
                    defensaInt = int.Parse(defensa);
                    if (defensaInt < DefensaMin || defensaInt > DefensaMax)
                    {
                        Console.WriteLine("Valor invalido. Intente de nuevo");
                    }
                    else
                    {
                        esDefensaValida = true;
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese un valor numerico");
                }

            } while (esDefensaValida == false);

            defensas[posicion] = defensaInt;

            return defensaInt;
        }


        static bool ComprobarValores(int salud, int ataque, int defensa, string nombre)
        {
            int cantTotalAtributos = salud + ataque + defensa;
            bool esValido = cantTotalAtributos == 40;
            if (!esValido)
            {
                Console.WriteLine("Distribución de atributos del gladiador '" + nombre + "' invalida");
                if (cantTotalAtributos > 40)
                {
                    Console.WriteLine("Se pasa por " + (cantTotalAtributos - 40) + ". Intentelo nuevamente");
                }
                else
                {
                    Console.WriteLine("Le faltan " + (40 - cantTotalAtributos) + ". Intentelo nuevamente");
                }
            }
            return esValido;
        }

        static void EstadisticasTurno(int turno, string[] equipos, string[] nombres, int[] vidas, int[] vidaMaxima)
        {

            Console.WriteLine("");
            Console.WriteLine("================ TURNO " + turno + " ================");

            const int espacio = 10;

            int modalidad = nombres.Length / 2;
            int inicio = 0;
            int fin = modalidad;
            for (int i = 0; i < equipos.Length; i++)
            {
                Console.WriteLine("");
                Console.WriteLine("[" + equipos[i] + "]");
                for (int j = inicio; j < fin; j++)
                {
                    string text = "";
                    Console.Write("  " + (j + 1) + ". " + nombres[j]);
                    CrearEspaciado(espacio - nombres[j].Length);

                    if (vidas[i] <= 0)
                    {
                        text = "   (fuera de combate)";
                    }
                    Console.WriteLine("Vida " + vidas[j] + "/" + vidaMaxima[j] + text);


                }

                inicio += modalidad;
                fin += modalidad;
            }
        }

        static void CrearEspaciado(int cantidad)
        {
            for (int i = 0; i <= cantidad; i++)
            {
                Console.Write(" ");
            }
        }

        static bool EsNulo(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        static bool EsValorNumerico(string valor)
        {
            if (valor == "")
            {
                return false;
            }

            string numeros = "0123456789";
            for (int i = 0; i < valor.Length; i++)
            {
                bool esNumerico = false;
                for (int j = 0; j < numeros.Length; j++)
                {
                    if (valor[i] == numeros[j])
                    {
                        esNumerico = true;
                    }
                }

                if (esNumerico == false)
                {
                    return false;
                }
            }

            return true;
        }

    }
}