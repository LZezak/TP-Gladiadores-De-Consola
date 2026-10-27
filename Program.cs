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
            int CantPlayer = 0;
            ElegirModalidad(Modalidad);
            CantPlayer = Modalidad * 2;
            const int PuntosTotales = 40;
            const int VidaMin = 10;
            const int VidaMaxCons = 25;
            const int AtaqueMin = 5;
            const int AtaqueMax = 20;
            const int DefensaMin = 1;
            const int DefensaMax = 10;
            const int MaxRecuperaciones = 2;

            string[] Nombre = new string[CantPlayer];
            int[] VidaActual = new int[CantPlayer];
            int[] VidaMax = new int[CantPlayer];
            int[] Ataque = new int[CantPlayer];
            int[] Defensa = new int[CantPlayer];
            int[] DañoAcumulado = new int[CantPlayer];
            int[] RecuperacionesUsadas = new int[CantPlayer];
        }
        static int ElegirModalidad(int modalidad)
        {
            Console.Write("Eliga entre las modalidades |1v1|, |2v2|, |3v3| y |5v5| - usando los numeros 1, 2, 3 y 5: ");
            modalidad = Convert.ToInt32(Console.ReadLine());
            while (true)
            { 
                if (modalidad == 1)
                {
                    Console.WriteLine("Se a elegido la modalidad Uno Contra Uno");
                    return 1;
                }
                if (modalidad == 2)
                {
                    Console.WriteLine("Se a elegido la modalidad Dos Contra Dos");
                    return 2;
                }
                if (modalidad == 3)
                {
                    Console.WriteLine("Se a elegido la modalidad Tres Contra Tres");
                    return 3;
                }
                if (modalidad == 5)
                {
                    Console.WriteLine("Se a elegido la modalidad Cinco Contra Cinco");
                    return 5;
                }
            }
        }
    }
}
