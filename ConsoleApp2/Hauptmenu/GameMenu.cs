using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Spiele.Kartenspiele.Blackjack;
using ConsoleApp2.Spiele.ZahlenSpiele.Sudoku;
using ConsoleApp2.Spiele.JumpRun.DesertRex;
using StreetRun;
using TetrisRohbau;

namespace ConsoleApp2.Hauptmenu
{
    internal class GameMenu
    {
        
        string _titel = @"

      _________        .__         .__              _________                          .__                           
     /   _____/______  |__|  ____  |  |    ____    /   _____/_____     _____    _____  |  |   __ __   ____     ____  
     \_____  \ \____ \ |  |_/ __ \ |  |  _/ __ \   \_____  \ \__  \   /     \  /     \ |  |  |  |  \ /    \   / ___\ 
     /        \|  |_> >|  |\  ___/ |  |__\  ___/   /        \ / __ \_|  Y Y  \|  Y Y  \|  |__|  |  /|   |  \ / /_/  >
    /_______  /|   __/ |__| \___  >|____/ \___  > /_______  /(____  /|__|_|  /|__|_|  /|____/|____/ |___|  / \___  / 
            \/ |__|             \/            \/          \/      \/       \/       \/                   \/ /_____/  


        Herzlich Willkommen";
        

        public GameMenu()
        {
            RunMainMenu();

        }

        void RunMainMenu()
        {
            string[] optionen = { "Spiel Kategorie wählen", "Spieler", "Einstellungen", "Exit" };

            Menu mainMenu = new Menu(_titel, optionen);
            var selectedIndex = mainMenu.Run();
            Console.Clear();
            Console.CursorVisible = false;
            switch (selectedIndex)
            {
                case 0:
                    SpieleKathegorie();
                    break;
                case 1:
                    //spieler = new SpielerListe();
                    RunMainMenu();
                    break;
                case 2:
                    var einstellung = new Einstellung();
                    RunMainMenu();
                    break;
                case 3:
                    ExitGame();
                    break;
            }

        }

        void SpieleKathegorie()
        {
            string[] spiele = { "KartenSpiele", "ZahlenSpiele", "JumpRun", "Tetris", "Zurück" };
            Menu katMenu = new Menu(_titel, spiele);
            int selectedIndex = katMenu.Run();
            Console.Clear();
            Console.CursorVisible = false;
            switch (selectedIndex)
            {
                case 0:
                    KartenSpiele();
                    break;
                case 1:
                    ZahlenSpiele();
                    break;
                case 2:
                    try
                    {
                        DesertRex rex = new DesertRex();
                    }
                    catch (Exception)
                    {
                    }
                    break;
                case 3:
                    try
                    {
                        TetrisEngine displ = new TetrisEngine();

                    }
                    catch (Exception)
                    {
                    }
                    break;
                case 4:
                    RunMainMenu();
                    break;
            }
        }

        void KartenSpiele()
        {
            string[] spiele = { "Blackjack", "StreetRun", "Mau mau", "Zurück", "Hauptmenu" };
            Menu kartenMenu = new Menu(_titel, spiele);
            int selectedIndex = kartenMenu.Run();
            Console.Clear();
            Console.CursorVisible = false;
            switch (selectedIndex)
            {
                case 0:
                    BlackJack blackj = new BlackJack();
                    break;
                case 1:
                    try
                    {
                        StreetRun.Display display = new StreetRun.Display(new Street(), new Character());
                        display.GameDisplay();
                    }
                    catch (Exception)
                    {
                    }
                    break;
                case 2:
                    SpieleKathegorie();
                    break;
                case 3:
                    SpieleKathegorie();
                    break;
                case 4:
                    RunMainMenu();
                    break;
            }
        }
        void ZahlenSpiele()
        {
            string[] spiele = { "Sudoku", "Zurück", "Hauptmenu" };
            Menu zahlenMenu = new Menu(_titel, spiele);
            int selectedIndex = zahlenMenu.Run();
            Console.Clear();
            Console.CursorVisible = false;
            switch (selectedIndex)
            {
                case 0:
                    var sudoku = new Sudoku();
                    RunMainMenu();
                    break;
                case 1:
                    SpieleKathegorie();
                    break;
                case 2:
                    RunMainMenu();
                    break;
            }
        }

        private void WuerfelSpiele()
        {
            string[] spiele = { "Maiern", "Würfel Sim", "...", "Zurück", "Hauptmenu" };
            Menu wuerfelMenu = new Menu(_titel, spiele);
            int selectedIndex = wuerfelMenu.Run();
            Console.Clear();
            Console.CursorVisible = false;
            switch (selectedIndex)
            {
                case 0:
                    StreetRun.Display display = new StreetRun.Display(new Street(), new Character());
                    display.GameDisplay();
                    break;
                case 1:
                    SpieleKathegorie();
                    break;
                case 2:
                    SpieleKathegorie();
                    break;
                case 3:
                    SpieleKathegorie();
                    break;
                case 4:
                    RunMainMenu();
                    break;
            }
        }
        private void ExitGame()
        {
            Console.ReadKey(true);
        }
    }
}


