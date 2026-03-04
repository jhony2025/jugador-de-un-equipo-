using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

class Program
{
    // Diccionario que se cargará desde archivo o iniciará con valores base
    static Dictionary<string, string> diccionario = new Dictionary<string, string>();

    static string archivoDiccionario = "diccionario.json";

    static void Main()
    {
        CargarDiccionario();

        int opcion;
        do
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            bool valido = int.TryParse(Console.ReadLine(), out opcion);
            if (!valido)
            {
                Console.WriteLine("Por favor ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase();
                    break;
                case 2:
                    AgregarPalabra();
                    break;
                case 0:
                    GuardarDiccionario();
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 0);
    }

    // Cargar diccionario desde JSON o inicializarlo
    static void CargarDiccionario()
    {
        if (File.Exists(archivoDiccionario))
        {
            string json = File.ReadAllText(archivoDiccionario);
            diccionario = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        }
        else
        {
            diccionario = new Dictionary<string, string>()
            {
                {"time", "tiempo"},
                {"person", "persona"},
                {"year", "año"},
                {"way", "camino"},
                {"day", "día"},
                {"thing", "cosa"},
                {"man", "hombre"},
                {"world", "mundo"},
                {"life", "vida"},
                {"hand", "mano"},
                {"part", "parte"},
                {"child", "niño"},
                {"eye", "ojo"},
                {"woman", "mujer"},
                {"place", "lugar"},
                {"work", "trabajo"},
                {"week", "semana"},
                {"case", "caso"},
                {"point", "punto"},
                {"government", "gobierno"},
                {"company", "empresa"}
            };
        }
    }

    // Guardar diccionario en JSON
    static void GuardarDiccionario()
    {
        string json = JsonSerializer.Serialize(diccionario, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(archivoDiccionario, json);
    }

    static void TraducirFrase()
    {
        Console.Write("\nIngrese la frase: ");
        string frase = Console.ReadLine();

        // Separar palabras y signos usando expresion regular
        string[] tokens = Regex.Split(frase, @"(\W)"); // conserva los signos
        string traduccion = "";
        int traducidas = 0;
        int noTraducidas = 0;

        foreach (string token in tokens)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                traduccion += token;
                continue;
            }

            string palabraLimpia = token.ToLower();
            if (diccionario.ContainsKey(palabraLimpia))
            {
                string valor = diccionario[palabraLimpia];

                // Mantener mayúscula inicial si la palabra original la tenía
                if (char.IsUpper(token[0]))
                    valor = char.ToUpper(valor[0]) + valor.Substring(1);

                traduccion += valor;
                traducidas++;
            }
            else
            {
                traduccion += token;
                noTraducidas++;
            }
        }

        Console.WriteLine("\nTraducción parcial:");
        Console.WriteLine(traduccion);

        Console.WriteLine($"\nReporte:");
        Console.WriteLine($"Palabras traducidas: {traducidas}");
        Console.WriteLine($"Palabras no traducidas: {noTraducidas}");
    }

    static void AgregarPalabra()
    {
        Console.Write("\nIngrese palabra en inglés: ");
        string ingles = Console.ReadLine().Trim().ToLower();

        Console.Write("Ingrese traducción en español: ");
        string espanol = Console.ReadLine().Trim().ToLower();

        if (!diccionario.ContainsKey(ingles))
        {
            diccionario.Add(ingles, espanol);
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }

        GuardarDiccionario(); // guardar cambios automáticamente
    }
}