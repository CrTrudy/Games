using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Hauptmenu;

namespace ConsoleApp2.Spiele.Kartenspiele.Blackjack
{
    class BlackJack
    {
        public List<Spieler> spieler = new List<Spieler>();
        Coupier coupier = new Coupier();
        string titel = @"
     _______  ___      _______  _______  ___   _        ___  _______  _______  ___   _ 
    |  _    ||   |    |   _   ||       ||   | | |      |   ||   _   ||       ||   | | |
    | |_|   ||   |    |  |_|  ||       ||   |_| |      |   ||  |_|  ||       ||   |_| |
    |       ||   |    |       ||       ||      _|      |   ||       ||       ||      _|
    |  _   | |   |___ |       ||      _||     |_    ___|   ||       ||      _||     |_ 
    | |_|   ||       ||   _   ||     |_ |    _  |  |       ||   _   ||     |_ |    _  |
    |_______||_______||__| |__||_______||___| |_|  |_______||__| |__||_______||___| |_|
";

        public BlackJack()
        {
            Console.Clear();
            Console.WriteLine(titel + "\n\n\n");
            NeueSpieler();
            ErsteRunde();
            Display();
            Wiederholung();
            coupier.Gewinner(spieler);
            Thread.Sleep(10000);
            SpielBeenden();

        }

        private int NeueSpieler()
        {
            int anzahl = 0;
            try
            {
                Console.WriteLine("                 Wie viele Spieler nehmen teil? Bitte zahlenwert eingeben.\n");
                Console.Write("                 ");
                anzahl = Convert.ToInt32(Console.ReadLine());
                SpielerErstellen(anzahl);
            }
            catch
            {
                Console.WriteLine("         Die Eingabe war invalide!!!");
                NeueSpieler();
            }

            return anzahl;
        }

        private void SpielerErstellen(int i)
        {
            for (int j = 0; j < i; j++)
            {
                Console.WriteLine($"Spieler {j} bitte gib deinen Namen ein: ");
                string name = Console.ReadLine();
                spieler.Add(new Spieler(name));
            }
        }

        private void ErsteRunde()
        {
            for (int j = 0; j < 2; j++)
            {
                coupier.KarteNehmen();
                foreach (Spieler spieler1 in spieler)
                {
                    coupier.KarteGeben(spieler1);
                }
            }
        }

        private bool Punkte()
        {
            if (coupier.summe == 21)
            {
                Console.WriteLine("         Die Bank hat gewonnen");
                return false;
            }
            foreach (Spieler spieler1 in spieler)
            {
                spieler1.punkte = coupier.Zaehlen(spieler1._kartenSpieler);
                //Console.WriteLine($"                {spieler1.Name()} hat {spieler1.punkte}\n");

                if (spieler1.punkte == 21)
                {
                    return false;
                }
            }
            return true;
        }
        private void Wiederholung()
        {
            while (Punkte() && Aufgegeben())
            {
                coupier.KarteNehmen();
                foreach (Spieler spieler2 in spieler)
                {
                    if (spieler2.Entscheidung())
                    {
                        spieler2.WeitereNehmen();
                        coupier.KarteGeben(spieler2);
                        continue;
                    }
                }
                Display();
            }
        }
        private bool Aufgegeben()
        {
            foreach (Spieler spieler in spieler)
            {
                if (spieler.Entscheidung())
                {
                    return true;
                }
            }
            return false;
        }

        private void Display()
        {
            Console.Clear();
            Console.WriteLine($"                    Bank   \n");
            Console.Write("                         ");
            GroundColore(coupier.KarteZeigen()[0]);
            for (int i = 0; i < coupier.KarteZeigen().Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("XX");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
            }
            Console.WriteLine("\n");
            SpielerKarteAufdecken();
        }

        void SpielerKarteAufdecken()
        {
            foreach (Spieler spieler in spieler)
            {
                Console.Write($"         {spieler.Name()}   ");
                Console.Write("    ");
                foreach (string karte in spieler._kartenSpieler)
                {
                    GroundColore(karte);
                }
                Console.WriteLine("\n");
            }
        }

        void GroundColore(string aktuelleKarte)
        {
            Console.BackgroundColor = ConsoleColor.White;

            string farbe = aktuelleKarte[0].ToString();

            if (aktuelleKarte[0].Equals("♦") ^ aktuelleKarte[0].Equals("♥"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Write(aktuelleKarte);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");

        }
        void SpielBeenden()
        {
            string[] gameOver = { "Neues Spiel", "Hauptmenu", "Beenden" };
            Menu menu = new Menu("Gameover!!!", gameOver);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    BlackJack bj = new BlackJack();
                    break;
                case 1:
                    GameMenu gameMenu = new GameMenu();
                    break;
                case 2:
                    Console.ReadKey(true);
                    break;
            }
        }
    }
}
