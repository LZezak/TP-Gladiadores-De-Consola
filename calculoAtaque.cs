using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void CalculoAtaque(int[] Vida, int[] Ataque, int[] Defensa,
                           int[] DañoAcumulado, int Atacante, int Defensor)
        {
            if (Vida[Atacante] <= 0 || Vida[Defensor] <= 0)
            {
                Console.WriteLine("No se puede atacar. Un gladiador está fuera de combate.");
                return;
            }

            int Daño = Ataque[Atacante] - Defensa[Defensor];

            if (Daño < 1)
            {
                Daño = 1;
            }

            int VidaAnterior = Vida[Defensor];

            Vida[Defensor] = Vida[Defensor] - Daño;

            if (Vida[Defensor] < 0)
            {
                Vida[Defensor] = 0;
            }

            int DañoReal = VidaAnterior - Vida[Defensor];

            DañoAcumulado[Atacante] = DañoAcumulado[Atacante] + DañoReal;

            Console.WriteLine("El ataque causó " + DañoReal + " puntos de daño.");

            if (Vida[Defensor] == 0)
            {
                Console.WriteLine("El gladiador defensor quedó fuera de combate.");
            }
        }
    }
}