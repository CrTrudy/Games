using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Spiele.Kartenspiele.Blackjack
{
    internal class Spieler
    {
        public List<string> _kartenSpieler = new List<string>();
        string _name;
        public int punkte;
        bool _weiter = true;

        public Spieler(string name)
        {
            _name = name;
        }
        public string Name()
        {
            return _name;
        }
        public void WeitereNehmen()
        {
            if (punkte < 21)
            {
                Console.Write($"            {_name}: J für weitere Karte!    ");
                ConsoleKeyInfo entscheidung = Console.ReadKey();
                if (entscheidung.Key == ConsoleKey.J)
                {
                    Console.WriteLine("                     Noch eine!\n");
                    _weiter = true;
                }
                else
                {
                    Console.WriteLine("                     Ich höre auf!!!\n");
                    _weiter = false;
                }
            }
            else
            {
                _weiter = false;
            }
        }
        public bool Entscheidung()
        {
            return _weiter;
        }
    }
}
