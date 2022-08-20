namespace TetrisRohbau
{
    public class TetrisDisplay
    {
        int _sleepTime = 200;
        string _randLeft = "|";
        string _randOben = "_";
        string _randUnten = "¯";
        int _cursorTop = 3;
        int _cursorBottom = 18;
        int _cursorLeft = 28;
        int _cursorRight = 52;

        public TetrisDisplay()
        {
            Console.Clear();
            Console.SetCursorPosition(_cursorLeft, _cursorTop);
            Console.Write(_randOben);
            Console.CursorVisible = false;
            for (int i = 0; i < _cursorBottom-_cursorTop; i++)
            {
                Console.SetCursorPosition(_cursorLeft - 1, _cursorTop + i);
                Console.Write(_randLeft);
            }
            for (int i = 0; i < 15; i++)
            {
                Console.SetCursorPosition(_cursorRight + 1, _cursorTop + i);
                Console.Write(_randLeft);
            }
            Console.SetCursorPosition(_cursorRight + 1, _cursorBottom);
            Console.Write(_randUnten);
        }

        
        public void DisplayGame(bool[,] sFeld)
            {
            Console.WriteLine();
            Console.SetCursorPosition(_cursorLeft, _cursorTop);
            for (var i = 0; i < sFeld.GetLength(0); i++)
            {
                Console.WriteLine(i);
                for (var j = 0; j < sFeld.GetLength(1); j++)
                {
                    Console.WriteLine(j);
                    Console.SetCursorPosition(_cursorLeft + j * 2, _cursorTop + i);
                    if (sFeld[i,j])
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("xx");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("  ");
                    }
                    
                }
            }
            Thread.Sleep(_sleepTime);         
        }        
    }
}