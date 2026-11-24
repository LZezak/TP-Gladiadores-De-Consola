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
            const int PuntosCuracion = 5;

            int Modalidad = ElegirModalidad();
            int CantJugadores = Modalidad * 2;

            int[] Vida = new int[CantJugadores];
            int[] CantidadVidaMaxJugadores = new int[CantJugadores];
            int[] Ataque = new int[CantJugadores];
            int[] Defensa = new int[CantJugadores];
            int[] DañoAcumulado = new int[CantJugadores];
            int[] RecuperacionesUsadas = new int[CantJugadores];
            string[] EquiposNombres = new string[2];
            string[] NombresGladiadores = new string[CantJugadores];

            AsignarNombreEquipo(EquiposNombres);
            InicializarEquipos(Modalidad, NombresGladiadores, Vida, Ataque, Defensa, EquiposNombres, PuntosTotales, VidaMaxCons, VidaMin, AtaqueMax, AtaqueMin, DefensaMax, DefensaMin);

            for (int i = 0; i < CantJugadores; i++)
            {
                CantidadVidaMaxJugadores[i] = Vida[i];
            }

            bool jugarDeNuevo;
            do
            {
                int turnosJugados = JugarCombate(Modalidad, CantJugadores, EquiposNombres, NombresGladiadores, Vida, CantidadVidaMaxJugadores, Ataque, Defensa, DañoAcumulado, RecuperacionesUsadas, MaxRecuperaciones, PuntosCuracion);

                MostrarReporteFinal(Modalidad, CantJugadores, EquiposNombres, NombresGladiadores, Vida, CantidadVidaMaxJugadores, Ataque, Defensa, DañoAcumulado, turnosJugados);

                jugarDeNuevo = PreguntarRevancha();

                if (jugarDeNuevo)
                {
                    ReiniciarParaRevancha(Vida, CantidadVidaMaxJugadores, DañoAcumulado, RecuperacionesUsadas, CantJugadores);
                }

            } while (jugarDeNuevo);
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
                string nombreEquipo;
                string nombreSinEspacios;
                string nombreFormateado;
                do
                {
                    esValido = true;
                    Console.Write("Elija el nombre de su equipo jugador " + (i + 1) + ": ");
                    nombreEquipo = Console.ReadLine();
                    nombreSinEspacios = QuitarEspacios(nombreEquipo);
                    if (nombreSinEspacios == "")
                    {
                        esValido = false;
                        Console.WriteLine("Ingresaste un valor nulo. Intentalo nuevamente");
                    }
                    else
                    {
                        nombreFormateado = FormatearNombre(nombreSinEspacios);
                        for (int j = 0; j < i; j++)
                        {
                            if (nombreFormateado == FormatearNombre(equipos[j]))
                            {
                                esValido = false;
                                Console.WriteLine("Ingrese un nombre que no este en uso");
                            }
                        }
                    }
                } while (esValido == false);
                equipos[i] = nombreSinEspacios;
            }
        }

        static void InicializarEquipos(int modalidad, string[] Nombre, int[] Vida, int[] Ataque, int[] Defensa, string[] NombreEquipos, int PuntosTotales, int VidaMax, int VidaMin, int AtaqueMax, int AtaqueMin, int DefensaMax, int DefensaMin)
        {
            for (int eq = 0; eq < 2; eq++)
            {
                Console.WriteLine("");
                Console.WriteLine(" --- EQUIPO '" + NombreEquipos[eq] + "' ---");
                Console.WriteLine("Tienes " + PuntosTotales + " puntos por gladiador para repartir entre los 3 atributos de cada gladiador (vida, ataque y defensa)");

                int desplazamiento = eq * modalidad;

                for (int i = 0; i < modalidad; i++)
                {
                    bool GladiadorValido;
                    Console.WriteLine("GLADIADOR " + (i + 1));
                    string nombre = AsignarNombre(i + desplazamiento, Nombre);
                    do
                    {
                        int vida = PedirAtributoEnRango("Salud (min. " + VidaMin + " - max. " + VidaMax + "): ", VidaMin, VidaMax);
                        int ataque = PedirAtributoEnRango("Ataque (min. " + AtaqueMin + " - max. " + AtaqueMax + "): ", AtaqueMin, AtaqueMax);
                        int defensa = PedirAtributoEnRango("Defensa (min. " + DefensaMin + " - max. " + DefensaMax + "): ", DefensaMin, DefensaMax);

                        Vida[i + desplazamiento] = vida;
                        Ataque[i + desplazamiento] = ataque;
                        Defensa[i + desplazamiento] = defensa;

                        GladiadorValido = ComprobarValores(vida, ataque, defensa, nombre, PuntosTotales);
                        Console.WriteLine("");

                    } while (GladiadorValido == false);
                }
            }
        }

        static string AsignarNombre(int Posicion, string[] Nombres)
        {
            bool NombreEsValido;
            string Nombre;
            string NombreSinEspacios;
            string NombreFormateado;
            do
            {
                NombreEsValido = true;
                Console.Write("Nombre: ");
                Nombre = Console.ReadLine();
                NombreSinEspacios = QuitarEspacios(Nombre);
                NombreFormateado = FormatearNombre(Nombre);
                if (NombreSinEspacios == "")
                {
                    NombreEsValido = false;
                    Console.WriteLine("Ingresaste un valor nulo. Intentalo nuevamente");
                }
                else
                {
                    for (int i = 0; i < Posicion; i++)
                    {
                        if (NombreFormateado == FormatearNombre(Nombres[i]))
                        {
                            NombreEsValido = false;
                            Console.WriteLine("Ingrese un nombre que no este repetido");
                        }
                    }
                }

            } while (NombreEsValido == false);

            Nombres[Posicion] = NombreSinEspacios;

            return NombreSinEspacios;
        }

        static int PedirAtributoEnRango(string mensaje, int min, int max)
        {
            string entrada;
            string entradaSinEspacios;
            int valorInt = 0;
            bool esValido;

            do
            {
                esValido = false;
                Console.Write(mensaje);
                entrada = Console.ReadLine();
                entradaSinEspacios = QuitarEspacios(entrada);
                if (EsValorNumerico(entradaSinEspacios))
                {
                    valorInt = int.Parse(entrada);
                    if (valorInt < min || valorInt > max)
                    {
                        Console.WriteLine("Valor invalido. Intente de nuevo");
                    }
                    else
                    {
                        esValido = true;
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese un valor numerico");
                }
            } while (esValido == false);

            return valorInt;
        }

        static bool ComprobarValores(int Salud, int Ataque, int Defensa, string Nombre, int PuntosTotales)
        {
            int CantTotalAtributos = Salud + Ataque + Defensa;
            bool EsValido = CantTotalAtributos == PuntosTotales;
            if (EsValido == false)
            {
                Console.WriteLine("Distribución de atributos del gladiador '" + Nombre + "' invalida");
                if (CantTotalAtributos > PuntosTotales)
                {
                    Console.WriteLine("Se pasa por " + (CantTotalAtributos - PuntosTotales) + ". Intentelo nuevamente");
                }
                else
                {
                    Console.WriteLine("Le faltan " + (PuntosTotales - CantTotalAtributos) + ". Intentelo nuevamente");
                }
            }
            return EsValido;
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
                    Console.Write("  " + (j - inicio + 1) + ". " + nombres[j]);
                    CrearEspaciado(espacio - nombres[j].Length);
                    if (vidas[j] <= 0)
                    {
                        text = "   (fuera de combate)";
                    }
                    Console.WriteLine("Vida " + vidas[j] + "/" + vidaMaxima[j] + text);
                }

                inicio += modalidad;
                fin += modalidad;
            }
        }

        static void CrearEspaciado(int Cantidad)
        {
            if (Cantidad < 1)
            {
                Cantidad = 1;
            }
            for (int i = 0; i <= Cantidad; i++)
            {
                Console.Write(" ");
            }
        }


        static bool EsValorNumerico(string valor)
        {
            if (valor == "" || valor.Length > 9)
            {
                return false;
            }

            string Numeros = "0123456789";
            for (int i = 0; i < valor.Length; i++)
            {
                bool EsNumerico = false;
                for (int j = 0; j < Numeros.Length; j++)
                {
                    if (valor[i] == Numeros[j])
                    {
                        EsNumerico = true;
                    }
                }

                if (EsNumerico == false)
                {
                    return false;
                }
            }
            return true;
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

        static int ObtenerDanioMaximo(int[] DanioAcumulado, int CantidadJugadores)
        {
            int MaxDanio = DanioAcumulado[0];
            for (int i = 1; i < CantidadJugadores; i++)
            {
                if (DanioAcumulado[i] > MaxDanio)
                {
                    MaxDanio = DanioAcumulado[i];
                }
            }
            return MaxDanio;
        }

        static void MostrarMVP(string[] NombresGladiadores, int[] DanioAcumulado, int CantidadJugadores)
        {
            int MaxDanio = ObtenerDanioMaximo(DanioAcumulado, CantidadJugadores);
            Console.Write("MVP del torneo (" + MaxDanio + " de daño causado): ");
            bool EsElPrimero = true;
            for (int i = 0; i < CantidadJugadores; i++)
            {
                if (DanioAcumulado[i] == MaxDanio)
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

        static void AnunciarGanador(string Equipo1, string Equipo2, int[] Vida, int CantJugadores, int TurnosTotales)
        {
            Console.WriteLine();
            Console.WriteLine("========== FIN DEL TORNEO ==========");

            if (EquipoDerrotado(Vida, 0, CantJugadores / 2) == false)
            {
                Console.WriteLine("Equipo ganador: " + Equipo1);
                Console.WriteLine("Ganador: Jugador 1");
            }
            else
            {
                Console.WriteLine("Equipo ganador: " + Equipo2);
                Console.WriteLine("Ganador: Jugador 2");
            }

            Console.WriteLine("La partida terminó en " + TurnosTotales + " turnos.");
        }

        static int SeleccionarMovimiento()
        {
            Console.WriteLine();
            Console.WriteLine("Acción: 1) Atacar  2) Recuperarse");

            while (true)
            {
                Console.Write("Elegí una opción (1 o 2): ");
                string texto = QuitarEspacios(Console.ReadLine());

                if (texto == "1" || texto == "2")
                {
                    return int.Parse(texto);
                }

                Console.WriteLine("Opción inválida. Solo se acepta 1 o 2.");
            }
        }

        static void Atacar(int Modalidad, int inicioPropio, int inicioRival, string[] NombresGladiadores, int[] Vida, int[] Ataque, int[] Defensa, int[] DañoAcumulado)
        {
            int idxAtacante = PedirGladiadorEnPie("Tu gladiador que ataca (número): ", Modalidad, inicioPropio, NombresGladiadores, Vida);
            int idxDefensor = PedirGladiadorEnPie("Gladiador rival que recibe (número): ", Modalidad, inicioRival, NombresGladiadores, Vida);

            int danioCalculado = Ataque[idxAtacante] - Defensa[idxDefensor];
            if (danioCalculado < 1)
            {
                danioCalculado = 1;
            }

            int danioReal = danioCalculado;
            if (danioReal > Vida[idxDefensor])
            {
                danioReal = Vida[idxDefensor];
            }

            Vida[idxDefensor] -= danioReal;
            DañoAcumulado[idxAtacante] += danioReal;

            Console.WriteLine(NombresGladiadores[idxAtacante] + " golpea a " + NombresGladiadores[idxDefensor] + " y le quita " + danioReal + " de vida.");

            if (Vida[idxDefensor] == 0)
            {
                Console.WriteLine(NombresGladiadores[idxDefensor] + " queda fuera de combate.");
            }
        }

        static int PedirGladiadorEnPie(string mensaje, int Modalidad, int inicioEquipo, string[] NombresGladiadores, int[] Vida)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = QuitarEspacios(Console.ReadLine());

                if (EsValorNumerico(entrada) == false)
                {
                    Console.WriteLine("Ingrese un valor numérico.");
                }
                else
                {
                    int eleccion = int.Parse(entrada);
                    if (eleccion < 1 || eleccion > Modalidad)
                    {
                        Console.WriteLine("Número inválido. Debe ser entre 1 y " + Modalidad + ".");
                    }
                    else
                    {
                        int indiceReal = inicioEquipo + (eleccion - 1);
                        if (Vida[indiceReal] <= 0)
                        {
                            Console.WriteLine(NombresGladiadores[indiceReal] + " está fuera de combate. Elegí otro.");
                        }
                        else
                        {
                            return indiceReal;
                        }
                    }
                }
            }
        }

        static void MostrarPromedioGanador(string nombreEquipoGanador, int[] Vida, int inicio, int fin, int Modalidad)
        {
            int sumaVida = 0;
            int sobrevivientes = 0;

            for (int i = inicio; i < fin; i++)
            {
                sumaVida += Vida[i];
                if (Vida[i] > 0)
                {
                    sobrevivientes++;
                }
            }

            double promedio = (double)sumaVida / Modalidad;
            Console.WriteLine("Promedio de vida restante de " + nombreEquipoGanador + ": " + promedio.ToString("F2") + " (sobrevivientes: " + sobrevivientes + " de " + Modalidad + ")");
        }

        static void MostrarTablaFinal(string Equipo1, string Equipo2, string[] NombresGladiadores, int[] Vida, int[] VidaMaxima, int[] Ataque, int[] Defensa, int[] DañoAcumulado, int CantJugadores)
        {
            const int anchoEquipo = 16;
            const int anchoGladiador = 16;
            const int anchoVida = 10;
            const int anchoStat = 6;
            const int anchoDanio = 8;

            Console.WriteLine();
            Console.Write("EQUIPO");
            CrearEspaciado(anchoEquipo - "EQUIPO".Length);
            Console.Write("GLADIADOR");
            CrearEspaciado(anchoGladiador - "GLADIADOR".Length);
            Console.Write("VIDA");
            CrearEspaciado(anchoVida - "VIDA".Length);
            Console.Write("ATQ");
            CrearEspaciado(anchoStat - "ATQ".Length);
            Console.Write("DEF");
            CrearEspaciado(anchoStat - "DEF".Length);
            Console.Write("DAÑO");
            CrearEspaciado(anchoDanio - "DAÑO".Length);
            Console.WriteLine("ESTADO");

            for (int i = 0; i < CantJugadores; i++)
            {
                string equipo;
                if (i < CantJugadores / 2)
                {
                    equipo = Equipo1;
                }
                else
                {
                    equipo = Equipo2;
                }

                string estado;
                if (Vida[i] > 0)
                {
                    estado = "En pie";
                }
                else
                {
                    estado = "Fuera de combate";
                }

                string textoVida = Vida[i] + "/" + VidaMaxima[i];
                string textoAtq = Ataque[i].ToString();
                string textoDef = Defensa[i].ToString();
                string textoDanio = DañoAcumulado[i].ToString();

                Console.Write(equipo);
                CrearEspaciado(anchoEquipo - equipo.Length);
                Console.Write(NombresGladiadores[i]);
                CrearEspaciado(anchoGladiador - NombresGladiadores[i].Length);
                Console.Write(textoVida);
                CrearEspaciado(anchoVida - textoVida.Length);
                Console.Write(textoAtq);
                CrearEspaciado(anchoStat - textoAtq.Length);
                Console.Write(textoDef);
                CrearEspaciado(anchoStat - textoDef.Length);
                Console.Write(textoDanio);
                CrearEspaciado(anchoDanio - textoDanio.Length);
                Console.WriteLine(estado);
            }
        }

        static int JugarCombate(int Modalidad, int CantJugadores, string[] EquiposNombres, string[] NombresGladiadores, int[] Vida, int[] VidaMaxima, int[] Ataque, int[] Defensa, int[] DañoAcumulado, int[] RecuperacionesUsadas, int MaxRecuperaciones, int PuntosCuracion)
        {
            int Turno = 1;
            int jugadorActivo = 0;
            bool combateTerminado = false;

            while (combateTerminado == false)
            {
                EstadisticasTurno(Turno, EquiposNombres, NombresGladiadores, Vida, VidaMaxima);

                int inicioPropio = jugadorActivo * Modalidad;
                int inicioRival = (1 - jugadorActivo) * Modalidad;

                Console.WriteLine();
                Console.WriteLine("Juega " + EquiposNombres[jugadorActivo] + " (Jugador " + (jugadorActivo + 1) + ")");

                bool accionCompletada = false;
                while (accionCompletada == false)
                {
                    int accion = SeleccionarMovimiento();

                    if (accion == 1)
                    {
                        Atacar(Modalidad, inicioPropio, inicioRival, NombresGladiadores, Vida, Ataque, Defensa, DañoAcumulado);
                        accionCompletada = true;
                    }
                    else
                    {
                        int idxGladiador = PedirGladiadorEnPie("Gladiador que se recupera (número): ", Modalidad, inicioPropio, NombresGladiadores, Vida);
                        accionCompletada = Recuperarse(Vida, VidaMaxima, RecuperacionesUsadas, NombresGladiadores, idxGladiador, MaxRecuperaciones, PuntosCuracion);
                    }
                }

                bool perdioEquipo1 = EquipoDerrotado(Vida, 0, Modalidad);
                bool perdioEquipo2 = EquipoDerrotado(Vida, Modalidad, CantJugadores);

                if (perdioEquipo1 || perdioEquipo2)
                {
                    combateTerminado = true;
                }
                else
                {
                    Turno++;
                    jugadorActivo = 1 - jugadorActivo;
                }
            }

            return Turno;
        }

        static void MostrarReporteFinal(int Modalidad, int CantJugadores, string[] EquiposNombres, string[] NombresGladiadores, int[] Vida, int[] VidaMaxima, int[] Ataque, int[] Defensa, int[] DañoAcumulado, int TurnosTotales)
        {
            AnunciarGanador(EquiposNombres[0], EquiposNombres[1], Vida, CantJugadores, TurnosTotales);
            MostrarMVP(NombresGladiadores, DañoAcumulado, CantJugadores);

            if (EquipoDerrotado(Vida, 0, Modalidad) == false)
            {
                MostrarPromedioGanador(EquiposNombres[0], Vida, 0, Modalidad, Modalidad);
            }
            else
            {
                MostrarPromedioGanador(EquiposNombres[1], Vida, Modalidad, CantJugadores, Modalidad);
            }

            MostrarTablaFinal(EquiposNombres[0], EquiposNombres[1], NombresGladiadores, Vida, VidaMaxima, Ataque, Defensa, DañoAcumulado, CantJugadores);
        }

        static bool PreguntarRevancha()
        {
            Console.WriteLine();
            while (true)
            {
                Console.Write("¿Quieren jugar una revancha con los mismos gladiadores? (S/N): ");
                string respuesta = FormatearNombre(QuitarEspacios(Console.ReadLine()));

                if (respuesta == "s")
                {
                    return true;
                }
                if (respuesta == "n")
                {
                    return false;
                }

                Console.WriteLine("Opción inválida. Ingresá S para sí o N para no.");
            }
        }
        
        static void ReiniciarParaRevancha(int[] Vida, int[] VidaMaxima, int[] DañoAcumulado, int[] RecuperacionesUsadas, int CantJugadores)
        {
            for (int i = 0; i < CantJugadores; i++)
            {
                Vida[i] = VidaMaxima[i];
                DañoAcumulado[i] = 0;
                RecuperacionesUsadas[i] = 0;
            }
            Console.WriteLine();
            Console.WriteLine("¡Todos los gladiadores recuperaron su vida al máximo! Comienza la revancha.");
        }


        static string FormatearNombre(string nombre)
        {
            string mayusculas = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZÁÉÍÓÚÜ";
            string minusculas = "abcdefghijklmnñopqrstuvwxyzáéíóúü";
            string nombreFormateado = "";

            for (int i = 0; i < nombre.Length; i++)
            {
                bool letraIdentificada = false;
                for (int j = 0; j < mayusculas.Length && letraIdentificada == false; j++)
                {
                    if (nombre[i] == mayusculas[j] || nombre[i] == minusculas[j])
                    {
                        nombreFormateado += minusculas[j];
                        letraIdentificada = true;
                    }
                }

                if (letraIdentificada == false)
                {
                    nombreFormateado += nombre[i];
                }
            }

            return nombreFormateado;
        }


        static string QuitarEspacios(string texto)
        {
            string textoSinEspAlComienzo = "";

            for (int i = 0; i < texto.Length; i++)
            {
                if (texto[i] != ' ')
                {
                    for (int j = i; j < texto.Length; j++)
                    {
                        textoSinEspAlComienzo += texto[j];
                    }
                    break;
                }
            }

            if (textoSinEspAlComienzo == "")
            {
                return "";
            }

            string textoSinEspacio = "";

            for (int i = (textoSinEspAlComienzo.Length - 1); i >= 0; i--)
            {
                if (textoSinEspAlComienzo[i] != ' ')
                {
                    for (int j = 0; j <= i; j++)
                    {
                        textoSinEspacio += textoSinEspAlComienzo[j];
                    }
                    break;
                }
            }
            return textoSinEspacio;
        }

    }
}
