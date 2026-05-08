using DoubleList;

var list = new DoubleLinkedList<string>();
var option = string.Empty;

do
{
    Console.Clear();
    ShowMenu();
    option = Console.ReadLine() ?? string.Empty;

    switch (option)
    {
        case "1":
            AddWord(list);
            break;

        case "2":
            ShowForward(list);
            break;

        case "3":
            ShowBackward(list);
            break;

        case "4":
            SortDescending(list);
            break;

        case "5":
            ShowModes(list);
            break;

        case "6":
            ShowChart(list);
            break;

        case "7":
            SearchWord(list);
            break;

        case "8":
            DeleteOneOccurrence(list);
            break;

        case "9":
            DeleteAllOccurrences(list);
            break;

        case "0":
            Console.WriteLine("¡Hasta luego!");
            break;

        default:
            Console.WriteLine("Opción inválida. Intente nuevamente.");
            Console.ReadKey();
            break;
    }
} while (option != "0");

void ShowMenu()
{
    Console.WriteLine("\n=============== LISTA DOBLEMENTE LIGADA ================\n");
    Console.WriteLine("1. Adicionar palabra o caracter");
    Console.WriteLine("2. Mostrar hacia adelante");
    Console.WriteLine("3. Mostrar hacia atrás");
    Console.WriteLine("4. Ordenar descendentemente");
    Console.WriteLine("5. Mostrar la(s) moda(s)");
    Console.WriteLine("6. Mostrar gráfico");
    Console.WriteLine("7. Buscar palabra o caracter");
    Console.WriteLine("8. Eliminar una ocurrencia");
    Console.WriteLine("9. Eliminar todas las ocurrencias");
    Console.WriteLine("0. Salir");
    Console.WriteLine("\n========================================================");
    Console.Write("\nSeleccione una opción: ");
}

void AddWord(DoubleLinkedList<string> list)
{
    Console.Write("Ingrese una palabra o caracter: ");
    string input = Console.ReadLine() ?? string.Empty;

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Error: Ingrese una palabra o caracter válido.");
    }
    else
    {
        string word = input.Trim();
        list.InsertOrdered(word);
        Console.WriteLine($"Palabra o caracter '{word}' agregada exitosamente.");
    }

    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

void ShowForward(DoubleLinkedList<string> list)
{
    Console.WriteLine("\n--- Lista hacia adelante ---");
    if (list.IsEmpty())
        Console.WriteLine("La lista está vacía.");
    else
        Console.WriteLine(list.ToString());
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

void ShowBackward(DoubleLinkedList<string> list)
{
    Console.WriteLine("\n--- Lista hacia atrás ---");
    if (list.IsEmpty())
        Console.WriteLine("La lista está vacía.");
    else
        Console.WriteLine(list.ToStringReverse());
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

void SortDescending(DoubleLinkedList<string> list)
{
    if (list.IsEmpty())
    {
        Console.WriteLine("La lista está vacía, no hay nada que ordenar.");
    }
    else
    {
        list.SortDescending();
        Console.WriteLine("Lista ordenada descendentemente.");
        Console.WriteLine(list.ToString());
    }
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

void ShowModes(DoubleLinkedList<string> list)
{
    Console.WriteLine("\n");
    if (list.IsEmpty())
    {
        Console.WriteLine("La lista está vacía.");
    }
    else
    {
        var modes = list.GetModes();
        if (modes.Count == 0)
        {
            Console.WriteLine("No hay moda.");
        }
        else if (modes.Count == 1)
        {
            Console.WriteLine($"La Moda es: '{modes[0]}'");
        }
        else
        {
            Console.WriteLine("Las Modas son:");
            for (int i = 0; i < modes.Count; i++)
            {
                Console.WriteLine($"  - {modes[i]}");
            }
        }
    }
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

void ShowChart(DoubleLinkedList<string> list)
{
    Console.WriteLine("\n--- Gráfico de ocurrencias ---");
    if (list.IsEmpty())
    {
        Console.WriteLine("La lista está vacía.");
    }
    else
    {
        Console.WriteLine(list.GetChart());
    }
    Console.WriteLine("Presione cualquier tecla para continuar...");
    Console.ReadKey();
}

void SearchWord(DoubleLinkedList<string> list)
{
    Console.Write("Ingrese la palabra o caracter a buscar: ");
    string input = Console.ReadLine() ?? string.Empty;

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Error: Ingrese una palabra o caracter válido.");
    }
    else
    {
        string word = input.Trim();
        if (list.Contains(word))
        {
            Console.WriteLine($"La palabra o caracter '{word}' existe en la lista.");
        }
        else
        {
            Console.WriteLine($"La palabra o caracter '{word}' no existe en la lista.");
        }
    }
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

void DeleteOneOccurrence(DoubleLinkedList<string> list)
{
    Console.Write("Ingrese la palabra o caracter a eliminar: ");
    string input = Console.ReadLine() ?? string.Empty;

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Error: Ingrese una palabra o caracter válido.");
    }
    else
    {
        string word = input.Trim();
        if (list.Contains(word))
        {
            list.Remove(word);
            Console.WriteLine($"Primera ocurrencia de '{word}' eliminada.");
        }
        else
        {
            Console.WriteLine($"La palabra o caracter '{word}' no existe en la lista.");
        }
    }
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

void DeleteAllOccurrences(DoubleLinkedList<string> list)
{
    Console.Write("Ingrese la palabra o caracter a eliminar completamente: ");
    string input = Console.ReadLine() ?? string.Empty;

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Error: Ingrese una palabra o caracter válido.");
    }
    else
    {
        string word = input.Trim();
        if (list.Contains(word))
        {
            list.RemoveAll(word);
            Console.WriteLine($"Todas las ocurrencias de '{word}' fueron eliminadas.");
        }
        else
        {
            Console.WriteLine($"La palabra o caracter '{word}' no existe en la lista.");
        }
    }
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}