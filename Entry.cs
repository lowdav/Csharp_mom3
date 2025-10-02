namespace guestbook
{
    //publik klass
    public class Entry
    {
        //Klassen innehåller två properties
        //Get och set möjliggör läsning och skrivning
        //? innebär att värdet kan vara null
        public string? Owner
        {
            get; set;
        }
        public string? Text
        {
            get; set;
        }
    }
}