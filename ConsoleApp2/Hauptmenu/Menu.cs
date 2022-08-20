using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Hauptmenu
{
    public class Menu 
    {
        string _titel;
        string[] _optionen;
        int _selectedIndex = 0;
        int _cursorOffsetLeft = 35;
        int _cursorOffsetTop = 14;

        public Menu(string titel, string[] optionen)
        {
            _titel = titel;
            _optionen = optionen;
        }

        void OptionenAnzeigen()
        {
            for (int i = 0; i < _optionen.Length; i++)
            {
                string aktuelleOption = _optionen[i];
                if (i == _selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.SetCursorPosition(_cursorOffsetLeft, _cursorOffsetTop + i);
                Console.WriteLine($"<< {aktuelleOption} >>");
                Console.ResetColor();
            }
        }
        public int Run()
        {
            Console.WriteLine(_titel + "\n\n\n");
            ConsoleKey keyPressed;
            do
            {
                OptionenAnzeigen();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    _selectedIndex--;
                    if (_selectedIndex == -1)
                    {
                        _selectedIndex = _optionen.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    _selectedIndex++;
                    if (_selectedIndex == _optionen.Length)
                    {
                        _selectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);
            return _selectedIndex;
        }


    }
}


