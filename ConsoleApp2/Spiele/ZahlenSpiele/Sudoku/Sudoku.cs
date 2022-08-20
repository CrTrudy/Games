using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Spiele.ZahlenSpiele.Sudoku
{
    internal class Sudoku
    {
        int[] _zahlen = { 5,3,4,6,7,8,9,1,2,6,7,2,1,9,5,3,4,8,1,9,8,3,4,8,5,6,7,8,5,9,7,6,1,4,2,3,1,2,3,8,5,9,7,9,1,7,1,3,9,2,4,8,5,6,9,6,7,5,3,7,2,8,4,2,8,7,4,7,9,6,3,5,3,4,5,2,8,6,1,7,9};
        int _selectedIndex = 5;
        List<int> _simpel = new List<int>();
        Random _rand = new Random();
        List<int[]> _nummern = new List<int[]>();

        public Sudoku()
        {
            randomIndex();
            Select();
        }
        void randomIndex()
        {
            for (int i = 0; i < 12; i++)
            {
                _simpel.Add(_rand.Next(0, 80));
            }
        }

        void Spielfeld()
        {
            Console.Write("\n\n\n\n\n");
            for (int i = 0; i < 9; i++)
            {
                Console.Write("                         ");
                for (int y = 1; y <= 9; y++)
                {
                    int x = i * 9 + y - 1;
                    if (_selectedIndex == x)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (_simpel.Contains(_selectedIndex))
                        {
                            foreach (var item in _nummern)
                            {
                                if (item[0] == _selectedIndex)
                                {
                                    Console.Write(item[1]);
                                    continue;
                                }
                                else
                                {
                                    Console.Write(" ");
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(_zahlen[x]);
                        }
                    }
                    else if (_simpel.Contains(x))
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(_zahlen[x]);
                    }
                    Console.Write(" ");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        void Select()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                Spielfeld();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;


                if (keyPressed == ConsoleKey.UpArrow)
                {
                    _selectedIndex -= 9;
                    if (_selectedIndex < 0)
                    {
                        _selectedIndex = 0;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    _selectedIndex += 9;
                    if (_selectedIndex >= _zahlen.Length)
                    {
                        _selectedIndex = 80;
                    }
                }
                else if (keyPressed == ConsoleKey.LeftArrow)
                {
                    _selectedIndex --;
                    if (_selectedIndex < 0)
                    {
                        _selectedIndex = 0;
                    }
                }
                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    _selectedIndex ++;
                    if (_selectedIndex >= _zahlen.Length)
                    {
                        _selectedIndex = 80;
                    }
                }
                if (keyPressed == ConsoleKey.NumPad1 || keyPressed == ConsoleKey.NumPad2 ||
                    keyPressed == ConsoleKey.NumPad3 || keyPressed == ConsoleKey.NumPad4 ||
                    keyPressed == ConsoleKey.NumPad5 || keyPressed == ConsoleKey.NumPad6 ||
                    keyPressed == ConsoleKey.NumPad7 || keyPressed == ConsoleKey.NumPad8 ||
                    keyPressed == ConsoleKey.NumPad9)
                {
                    try
                    {
                        int nummer = Convert.ToInt32(keyPressed) - 96;
                        int[] nummern = { _selectedIndex, nummer };
                        _nummern.Add(nummern);
                        Console.WriteLine($"!!!!!!!!!!!!!!!!!!!!!!!!!!!!{nummern}");
                    }
                    catch (Exception)
                    {
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);        }
    }
}
