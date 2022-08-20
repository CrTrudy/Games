using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Threading.Tasks.Dataflow;


namespace ConsoleApp2.Spiele.JumpRun.DesertRex
{
    class DesertRex 
    {
        Random rand = new Random();
        List<char> _strasse = new List<char>();
        List<char> _hindernisse = new List<char>("ȹȾɎȸȵȴ");
        char _boden = Convert.ToChar("_");
        char _character = Convert.ToChar("Ǿ");
        string _bufferEins;
        List<char> _bufferZwei = new List<char>();
        int _time = 200;

        public DesertRex()
        {
            for (int i = 0; i < 80; i++)
            {
                _strasse.Add(_boden);
            }
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
            Console.Clear();
            Laufen();
        }
        void Laufen()
        {
            ConsoleKey keyPressed;
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;
            do
            {
                StrasseBauen();
                Console.SetCursorPosition(10, 15);
                Console.Write(_character.ToString());
                Console.WriteLine(_bufferEins);
                Thread.Sleep(_time);
                
            }
            while (keyPressed != ConsoleKey.UpArrow);
            //Task task = Task.Factory.StartNew(Springen());
        }
        void Springen()
        {
            for (int i = 1; i <= 4; i++)
            {
                StrasseBauen();
                Console.SetCursorPosition(10, 15 - i);
                Console.Write(_character.ToString());
                Console.SetCursorPosition(10, 15);
                Console.WriteLine(_bufferEins);
                Thread.Sleep(_time);
                Console.SetCursorPosition(10, 15 - i);
                Console.Write(" ");
            }
            for (int i = 1; i <= 4; i++)
            {
                StrasseBauen();
                Console.SetCursorPosition(10, 10 + i);
                Console.Write(_character.ToString());
                Console.SetCursorPosition(10, 15);
                Console.WriteLine(_bufferEins);
                Thread.Sleep(_time);
                Console.SetCursorPosition(10, 10 + i);
                Console.Write(" ");
            }
            Laufen();
        }
        string StrasseBauen()
        {
            
            if (rand.Next(0, 99) > 90)
            {
                _strasse.Add(_hindernisse[rand.Next(0, _hindernisse.Count)]);
                if (rand.Next(0, 99) > 84)
                {
                    _strasse.Add(_hindernisse[rand.Next(0, _hindernisse.Count)]);

                    if (rand.Next(0, 99) > 94)
                    {
                        _strasse.Add(_hindernisse[rand.Next(0, _hindernisse.Count)]);

                        if (rand.Next(0, 99) > 94)
                        {
                            _strasse.Add(_hindernisse[rand.Next(0, _hindernisse.Count)]);
                        }
                    }
                }
                _strasse.AddRange("______");
            }
        
            if (rand.Next(0, 99) > 34)
            {
                _strasse.AddRange("____");
                if (rand.Next(0, 99) > 44)
                {
                    _strasse.AddRange("___");
                    if (rand.Next(0, 99) > 64)
                    {
                        _strasse.AddRange("___");
                        if (rand.Next(0, 99) > 74)
                        {
                            _strasse.AddRange("__");
                            if (rand.Next(0, 99) > 84)
                            {
                                _strasse.AddRange("__");
                            }
                        }
                    }
                }
            }
            _strasse.RemoveAt(0);
            try
            {
                _strasse.RemoveRange(100, (_strasse.Count - 100));
                _bufferZwei = _strasse.GetRange(0, 80);
            }
            catch (Exception)
            {
            }
            _bufferEins = String.Join("", _bufferZwei.ToArray());
            return _bufferEins;
        }

    }
}


