using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Spiele.Kartenspiele.Karten
{
    public class Deck
    {
        List<Karten> _karten = new List<Karten>();
        string[] _kartenWert = { "2", "3", "4", "5", "6", "7", "8", "9", "X", "B", "D", "K", "A" };
        int[] _werte = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };
        string[] _symbol = { "♦", "♥", "♣", "♠" };
        string[] _farbe = { "Rot", "Schwarz" };

        public Deck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int y = 0; y < _kartenWert.Length; y++)
                {
                    var neueKarte = new Karten(_kartenWert[y], _symbol[i], _farbe[i / 2], _werte[y]);
                    _karten.Add(neueKarte);
                }

            }
        }
        void GetKarten()
        { 
            
        }
    }

    class Karten
    {
        string _karte;
        string _symbol;
        string _farbe;
        int _wert;

        public Karten(string karte, string symbol, string farbe, int wert)
        {
            _karte = karte;
            _symbol = symbol;
            _farbe = farbe;
            _wert = wert;
        }
    }
}
