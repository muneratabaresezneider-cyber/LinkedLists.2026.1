using DoubleList;

var list = new DoubleLinkedList<int>();
var option = string.Empty;

do
{
    Console.Clear();
    ShowMenu();
    option = Console.ReadLine() ?? string.Empty;

    switch (option)
    {
        case "1":
            AddNumber(list);
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
            SearchNumber(list);
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
    Console.WriteLine("\n========== LISTA DOBLEMENTE LIGADA ==========\n");
    Console.WriteLine("1. Adicionar número");
    Console.WriteLine("2. Mostrar hacia adelante");
    Console.WriteLine("3. Mostrar hacia atrás");
    Console.WriteLine("4. Ordenar descendentemente");
    Console.WriteLine("5. Mostrar la(s) moda(s)");
    Console.WriteLine("6. Mostrar gráfico");
    Console.WriteLine("7. Existe número");
    Console.WriteLine("8. Eliminar una ocurrencia");
    Console.WriteLine("9. Eliminar todas las ocurrencias");
    Console.WriteLine("0. Salir");
    Console.WriteLine("\n==============================================");
    Console.Write("\nSeleccione una opción: ");
}

void AddNumber(DoubleLinkedList<int> list)
{
    Console.Write("Ingrese un número: ");
    if (int.TryParse(Console.ReadLine(), out int number))
    {
        list.InsertOrdered(number);
        Console.WriteLine($"Número {number} agregado exitosamente.");
    }
    else
    {
        Console.WriteLine("Error: Ingrese un número válido.");
    }
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

void ShowForward(DoubleLinkedList<int> list)
{
    Console.WriteLine("\n--- Lista hacia adelante ---");
    if (list.IsEmpty())
        Console.WriteLine("La lista está vacía.");
    else
        Console.WriteLine(list.ToString());
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

void ShowBackward(DoubleLinkedList<int> list)
{
    Console.WriteLine("\n--- Lista hacia atrás ---");
    if (list.IsEmpty())
        Console.WriteLine("La lista está vacía.");
    else
        Console.WriteLine(list.ToStringReverse());
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

void SortDescending(DoubleLinkedList<int> list)
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

void ShowModes(DoubleLinkedList<int> list)
{
    Console.WriteLine("\n--- Moda(s) ---");
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
            Console.WriteLine($"La moda es: {modes[0]}");
        }
        else
        {
            Console.Write("Las modas son: ");
            for (int i = 0; i < modes.Count; i++)
            {
                if (i > 0) Console.Write(", ");
                Console.Write(modes[i]);
            }
            Console.WriteLine();
        }
    }
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

void ShowChart(DoubleLinkedList<int> list)
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

void SearchNumber(DoubleLinkedList<int> list)
{
    Console.Write("Ingrese el número a buscar: ");
    if (int.TryParse(Console.ReadLine(), out int number))
    {
        if (list.Contains(number))
        {
            Console.WriteLine($"El número {number} existe en la lista.");
        }
        else
        {
            Console.WriteLine($"El número {number} no existe en la lista.");
        }
    }
    else
    {
        Console.WriteLine("Error: Ingrese un número válido.");
    }
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

void DeleteOneOccurrence(DoubleLinkedList<int> list)
{
    Console.Write("Ingrese el número a eliminar: ");
    if (int.TryParse(Console.ReadLine(), out int number))
    {
        if (list.Contains(number))
        {
            list.Remove(number);
            Console.WriteLine($"Primera ocurrencia de {number} eliminada.");
        }
        else
        {
            Console.WriteLine($"El número {number} no existe en la lista.");
        }
    }
    else
    {
        Console.WriteLine("Error: Ingrese un número válido.");
    }
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

void DeleteAllOccurrences(DoubleLinkedList<int> list)
{
    Console.Write("Ingrese el número a eliminar completamente: ");
    if (int.TryParse(Console.ReadLine(), out int number))
    {
        if (list.Contains(number))
        {
            list.RemoveAll(number);
            Console.WriteLine($"Todas las ocurrencias de {number} fueron eliminadas.");
        }
        else
        {
            Console.WriteLine($"El número {number} no existe en la lista.");
        }
    }
    else
    {
        Console.WriteLine("Error: Ingrese un número válido.");
    }
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}