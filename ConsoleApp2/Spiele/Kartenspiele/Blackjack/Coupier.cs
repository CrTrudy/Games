using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Spiele.Kartenspiele.Blackjack
{
    internal class Coupier
    {

        List<string> _coupierKarten = new List<string>();
        Deck _kartenDeck = new Deck();
        public int summe = 0;
        Random rand = new Random();


        public Coupier()
        {
            Console.WriteLine("         Herzlich Willkommen!!!");
        }

        public List<string> KarteZeigen()
        {

            return _coupierKarten;

        }

        public void KarteNehmen()
        {
            if (_coupierKarten != null)
            {
                summe = Zaehlen(_coupierKarten);
            }
            if (_coupierKarten != null && summe <= 17)
            {
                _coupierKarten.Add(KarteWählen());
            }
        }

        public void KarteGeben(Spieler spieler)
        {
            if (spieler != null && spieler.Entscheidung())
            {
                spieler._kartenSpieler.Add(KarteWählen());
            }
        }


        private string KarteWählen()
        {
            var idx = rand.Next(_kartenDeck.karte.Count);
            var auswahl = _kartenDeck.karte[idx];
            _kartenDeck.karte.RemoveAt(idx);
            return auswahl;
        }
        public int Zaehlen(List<string> karten)
        {
            int wert = 0;
            foreach (string karte in karten)
            {
                string kartenWert = Convert.ToString(karte[1]);
                try
                {
                    if (kartenWert == "X")
                    {
                        wert += 10;
                    }
                    else
                    {
                        wert += Convert.ToInt32(kartenWert);
                    }
                }
                catch { }
                if (kartenWert == "B" ^ kartenWert == "D" ^ kartenWert == "K")
                {
                    wert += 10;
                }
                if (kartenWert == "A")
                {
                    wert += 11;
                }
            }
            return wert;
        }
        public void Gewinner(List<Spieler> spieler)
        {
            int zahl = 0;
            foreach (Spieler spieler1 in spieler)
            {
                Zaehlen(spieler1._kartenSpieler);
                if (spieler1.punkte >= zahl && spieler1.punkte <= 21)
                {
                    zahl = spieler1.punkte;
                }
            }
            if (summe == 21)
            {
                Console.WriteLine("         Die bank hat mit 21 Punkten gewonnen!!!");
            }
            else
            {
                Console.WriteLine($"            Die Bank hat {summe} Punkte");
            }

            foreach (Spieler spieler1 in spieler)
            {
                if (spieler1.punkte == zahl)
                {
                    if (summe == zahl)
                    {
                        Console.WriteLine($"            Split zwischen Spieler {spieler1.Name()} und der Bank");
                    }
                    if (summe > zahl && summe <= 21)
                    {
                        Console.WriteLine("         Die Bank hat Gewonnen!!!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"            {spieler1.Name()} hat gewonnen!!!");
                    }
                }
            }
        }

    }
}
