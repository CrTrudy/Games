using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Spiele.Kartenspiele.Blackjack
{
    public class Deck
    {
        public List<string> karte = new List<string>();

        public Deck()
        {
            List<string> werte = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "X", "B", "D", "K", "A" };
            List<string> symbol = new List<string> { "♦", "♣", "♥", "♠" };

            for (int i = 0; i < 4; i++)
            {
                for (int y = 0; y < werte.Count; y++)
                {
                    string bild = symbol[i] + werte[y];
                    karte.Add(bild);
                }

            }
        }
    }
}
