using System;
using System.Collections.Generic;

class Torneo
{
    static Dictionary<string, HashSet<string>> equipos = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

    static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n--- MENÚ TORNEO DE FÚTBOL ---");
            Console.WriteLine("1. Registrar equipo");
            Console.WriteLine("2. Agregar jugador");
            Console.WriteLine("3. Mostrar equipos y jugadores");
            Console.WriteLine("4. Eliminar jugador");
            Console.WriteLine("5. Buscar jugador");
            Console.WriteLine("6. Contar jugadores por equipo");
            Console.WriteLine("7. Salir");

            Console.Write("Seleccione una opción: ");
            string entrada = Console.ReadLine();
            if (!int.TryParse(entrada, out int opcion))
            {
                Console.WriteLine("Entrada inválida. Ingresa un número del 1 al 7.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    RegistrarEquipo();
                    break;
                case 2:
                    AgregarJugador();
                    break;
                case 3:
                    MostrarEquipos();
                    break;
                case 4:
                    EliminarJugador();
                    break;
                case 5:
                    BuscarJugador();
                    break;
                case 6:
                    ContarJugadores();
                    break;
                case 7:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void RegistrarEquipo()
    {
        Console.Write("Nombre del equipo: ");
        string nombre = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(nombre))
        {
            Console.WriteLine("Nombre inválido.");
            return;
        }

        if (!equipos.ContainsKey(nombre))
        {
            equipos[nombre] = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("Equipo registrado.");
        }
        else
        {
            Console.WriteLine("El equipo ya existe.");
        }
    }

    static void AgregarJugador()
    {
        Console.Write("Equipo: ");
        string equipo = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(equipo))
        {
            Console.WriteLine("Equipo inválido.");
            return;
        }

        if (equipos.TryGetValue(equipo, out var jugadores))
        {
            Console.Write("Nombre del jugador: ");
            string jugador = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(jugador))
            {
                Console.WriteLine("Nombre de jugador inválido.");
                return;
            }

            if (jugadores.Add(jugador))
                Console.WriteLine("Jugador agregado.");
            else
                Console.WriteLine("El jugador ya está registrado en este equipo.");
        }
        else
        {
            Console.WriteLine("El equipo no existe.");
        }
    }

    static void MostrarEquipos()
    {
        if (equipos.Count == 0)
        {
            Console.WriteLine("No hay equipos registrados.");
            return;
        }

        foreach (var equipo in equipos)
        {
            Console.WriteLine("\nEquipo: " + equipo.Key);
            if (equipo.Value.Count == 0)
            {
                Console.WriteLine("  No hay jugadores registrados.");
            }
            else
            {
                foreach (var jugador in equipo.Value)
                {
                    Console.WriteLine("  - " + jugador);
                }
            }
        }
    }

    static void EliminarJugador()
    {
        Console.Write("Equipo: ");
        string equipo = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(equipo))
        {
            Console.WriteLine("Equipo inválido.");
            return;
        }

        if (equipos.TryGetValue(equipo, out var jugadores))
        {
            Console.Write("Jugador a eliminar: ");
            string jugador = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(jugador))
            {
                Console.WriteLine("Nombre de jugador inválido.");
                return;
            }

            if (jugadores.Remove(jugador))
                Console.WriteLine("Jugador eliminado.");
            else
                Console.WriteLine("El jugador no existe en este equipo.");
        }
        else
        {
            Console.WriteLine("El equipo no existe.");
        }
    }

    static void BuscarJugador()
    {
        Console.Write("Nombre del jugador: ");
        string jugador = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(jugador))
        {
            Console.WriteLine("Nombre de jugador inválido.");
            return;
        }

        bool encontrado = false;

        foreach (var equipo in equipos)
        {
            if (equipo.Value.Contains(jugador))
            {
                Console.WriteLine($"{jugador} está en el equipo {equipo.Key}");
                encontrado = true;
            }
        }

        if (!encontrado)
            Console.WriteLine("Jugador no encontrado en ningún equipo.");
    }

    static void ContarJugadores()
    {
        if (equipos.Count == 0)
        {
            Console.WriteLine("No hay equipos registrados.");
            return;
        }

        foreach (var equipo in equipos)
        {
            Console.WriteLine($"El equipo {equipo.Key} tiene {equipo.Value.Count} jugador(es).");
        }
    }
}