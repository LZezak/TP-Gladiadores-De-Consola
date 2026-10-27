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
            string[] nombres = new string[10];
        }

        static void ElegirNombreGladiador(int posicion, string[] nombres)
        {

            bool nombreEsValido;

            do
            {
                nombreEsValido = true;
                Console.Write("Nombre gladiador: ");
                nombres[posicion] = Console.ReadLine();

                for (int j = 0; j < posicion; j++)
                {
                    if (nombres[posicion] == nombres[j])
                    {
                        nombreEsValido = false;
                        Console.WriteLine("Utilice un nombre que no este repetido");
                    }
                }
            }
            while (nombreEsValido == false);

        }

        static void DefinirVidaGladiador(int posicion, int[] vidas)
        {

            int vidaMinima = 10;
            int vidaMaxima = 25;

            do
            {
                Console.Write("Vida: ");
                vidas[posicion] = Convert.ToInt32(Console.ReadLine());
            }
            while (vidas[posicion] < vidaMinima || vidas[posicion] > vidaMaxima);

        }

        static void DefinirAtaqueGladiador(int posicion, int[] ataques)
        {

            int ataqueMinimo = 5;
            int ataqueMaximo = 20;


            do
            {
                Console.Write("Ataque gladiador " + "N°" + (i + 1) + ": ");
                ataques[posicion] = Convert.ToInt32(Console.ReadLine());
            }
            while (ataques[posicion] < ataqueMinimo || ataques[posicion] > ataqueMaximo);


        }

        static void DefinirDefensaGladiador(int posicion, int[] defensas)
        {

            int defensaMinima = 1;
            int defensaMaxima = 10;

            do
            {
                Console.Write("Defensa gladiador " + "N°" + (i + 1) + ": ");
                defensas[posicion] = Convert.ToInt32(Console.ReadLine());
            }
            while (defensas[posicion] < defensaMinima || defensas[posicion] > defensaMaxima);

        }



    }
}
