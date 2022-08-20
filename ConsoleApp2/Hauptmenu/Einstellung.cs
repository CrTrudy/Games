namespace ConsoleApp2.Hauptmenu
{
    class Einstellung
    { 
        string _titel = "Einstellungen";
        string[] _einstellung = { "Größer", "Kleiner", "Klein", "Mittel", "Gross", "Zurück" };
        int _selectedIndex = 0;
        Menu _einstellungMenu; 
        int _origWidth = 0;
        int _origHeight = 0;
        int _newWidth = 0;
        int _newHeight = 0;

        public Einstellung()
        {
            _einstellungMenu = new Menu(_titel, _einstellung);
            Fenster();

        }
        void Fenster()
        {
            _selectedIndex = _einstellungMenu.Run();

            switch (_selectedIndex)
            {
                case 0:
                    Erweitern();
                    Fenster();
                    break;
                case 1:
                    Verkleinern();
                    Fenster();
                    break;
                case 2:
                    Klein();
                    Fenster();
                    break;
                case 3:
                    Mittel();
                    Fenster();
                    break;
                case 4:
                    Gross();
                    Fenster();
                    break;

            }
        }
        void Klein()
        {
            Console.SetWindowSize(100, 15);
        }

        void Mittel()
        {
            Console.SetWindowSize(180, 30);
        }

        void Gross()
        {
            Console.SetWindowSize(220, 50);
        }

        void Erweitern()
        {
            Console.WriteLine("Einstellung Eins ausgewählt");
            _origWidth = Console.WindowWidth;
            _origHeight = Console.WindowHeight;
            try
            {
                _newWidth = _origWidth + 2;
                _newHeight = _origHeight + 1;
                Console.SetWindowSize(_newWidth, _newHeight);
            }
            catch (Exception)
            {
                Console.WriteLine("             \n\n\nDas Fenster hat die Maximale größe erreicht!\n\n\n");
            }
            Thread.Sleep(600);
        }
        void Verkleinern()
        {
            Console.WriteLine("Einstellung Zwei ausgewählt");
            _origWidth = Console.WindowWidth;
            _origHeight = Console.WindowHeight;
            try
            {
                _newWidth = _origWidth - 2;
                _newHeight = _origHeight - 1;
                Console.SetWindowSize(_newWidth, _newHeight);
            }
            catch (Exception)
            {
                Console.WriteLine("             \n\n\nDas Fenster hat die Minimale größe erreicht!\n\n\n");
            }
            Thread.Sleep(600);
        }
    }
}


