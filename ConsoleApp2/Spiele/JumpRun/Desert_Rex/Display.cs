using System.Text;

namespace ConsoleApp2.Spiele.JumpRun.DesertRex
{
 
    class Display
    {
        static void Laufen(string buffer)
        {
            int i = 10000;
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
            Console.Clear();
            do
            {
                i--;
                Console.SetCursorPosition(10, 15);
                Console.Write(buffer);

                Thread.Sleep(300);
            }
            while (i > 0);
        }


     
    }

    }



