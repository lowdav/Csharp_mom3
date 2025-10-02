using System;

namespace guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Skapa ett nytt objekt av typen GuestbookStore
            var store = new GuestbookStore();

            //While-loop för att hantera meny, utskrift och användarinteraktion
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("GÄSTBOKEN\n");

                Console.WriteLine("1. Lägg till inlägg");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("X. Avsluta\n");

                // Lista alla inlägg
                var entries = store.getEntries();
                if (entries.Count > 0)
                {
                    Console.WriteLine("Inlägg i gästboken:\n");
                    for (int i = 0; i < entries.Count; i++)
                    {
                        var e = entries[i];
                        // Visa [index] Owner: Text (hanterar ev. null med ??)
                        Console.WriteLine($"[{i}] {(e.Owner ?? "<okänd>")}: {e.Text ?? ""}");
                    }
                }
                else
                {
                    Console.WriteLine("\nGästboken är tom.");
                }
                // Läs menyval
                var key = Console.ReadKey(true);
                switch (char.ToUpperInvariant(key.KeyChar))
                {
                    case '1':
                        Console.CursorVisible = true;
                        Console.Write("Ange namn/ägare: ");
                        string? owner = Console.ReadLine();

                        Console.Write("Skriv ditt inlägg: ");
                        string? text = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(owner) && !string.IsNullOrWhiteSpace(text))
                        {
                            store.addEntry(owner, text);
                            Console.WriteLine("\nInlägg tillagt. [Valfri tangent för att fortsätta]");
                        }
                        else
                        {
                            Console.WriteLine("\nInlägget måste innehålla både namn och text. [Valfri tangent för att fortsätta]");
                        }
                        Console.ReadKey(true);
                        break;

                    case '2':
                        Console.CursorVisible = true;
                        if (entries.Count == 0)
                        {
                            Console.WriteLine("Det finns inget att radera. [Valfri tangent för att fortsätta]");
                        }
                        else
                        {
                            Console.Write("Ange index att radera: ");
                            string? s = Console.ReadLine();
                            if (int.TryParse(s, out int index))
                            {
                                if (index >= 0 && index < entries.Count)
                                {
                                    store.delEntry(index);
                                    Console.WriteLine("\nInlägg borttaget. [Valfri tangent för att fortsätta]");
                                }
                                else
                                {
                                    Console.WriteLine("\nIndex finns inte. [Valfri tangent för att fortsätta]");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nOgiltigt tal. [Valfri tangent för att fortsätta]");
                            }
                        }
                        Console.ReadKey(true);
                        break;

                    case 'X':
                        return; // Avsluta programmet

                    default:
                        // Ignorera andra tangenter
                        break;
                }
            }
        }
    }
}
