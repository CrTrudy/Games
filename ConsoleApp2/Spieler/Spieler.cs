using ConsoleApp2.Spiele.Kartenspiele.Karten;

namespace ConsoleApp2.Hauptmenu
{
    class Spieler
    {
        public List<Karten> _kartenSpieler = new List<Karten>();
        string _name { get; }
         
        bool _weiter = true;

        public Spieler(string nameSpieler)
        {
            _name = nameSpieler;
        }

        public bool Entscheidung()
        {
            ConsoleKey keyPressed;
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;
            if (keyPressed == ConsoleKey.Enter)
            {
                _weiter = true;
                return _weiter;
            }
            _weiter = false;
            return _weiter;
        }

        
    }
    class Save
    {
        public Save(Spieler spieler)
        {
            
        }


    }
    class Load
    {
        public Load(Spieler spieler)
        {

        }
    }
}


