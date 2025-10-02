//Importera färdiga bibliotek
using System.Collections.Generic; //Används för List
using System.IO; //Filhantering
using System.Text.Json; //JSON-serialisering och deserialisering

namespace guestbook
{
    public class GuestbookStore
    {
        //Instansfält, private = kan bara nås inne i klassen.
        private string filename = @"guestbook.json";
        //Skapa ett nytt listobjekt 
        private List<Entry> entries = new List<Entry>();

        //Konstruktor
        public GuestbookStore()
        {
            if (File.Exists(filename))
            {   // Läs in tidigare sparade inlägg om fil finns
                string jsonString = File.ReadAllText(filename);
                entries = JsonSerializer.Deserialize<List<Entry>>(jsonString)!;
            }
        }
        //Metoder för lägga till, ta bort och lista "inlägg"
        public Entry addEntry(string owner, string text)
        {
            Entry obj = new Entry();
            obj.Owner = owner;
            obj.Text  = text;
            entries.Add(obj);
            save();
            return obj;
        }

        public int delEntry(int index)
        {
            entries.RemoveAt(index);
            save();
            return index;
        }

        public List<Entry> getEntries()
        {
            return entries;
        }

        private void save()
        {
            // Serialisera alla inlägg och skriv till fil
            var jsonString = JsonSerializer.Serialize(entries);
            File.WriteAllText(filename, jsonString);
        }
    }
}
