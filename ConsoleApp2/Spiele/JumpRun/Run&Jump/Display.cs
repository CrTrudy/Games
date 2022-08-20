using System.Text;

namespace StreetRun;

class Display
{
    int _cursorLeft = 10;
    int _cursorTop = 15;
    int _time = 400;
    readonly IStreet _street;
    ICharacter _character;
    ConsoleKey _keyPressed;
    public Display(IStreet street, ICharacter character)
    {
        _street = street;
        _character = character;
    }

    public void GameDisplay()
    {
        Console.Clear();
        Console.OutputEncoding = Encoding.Unicode;
        Console.CursorVisible = false;
        do
        {
            if (Console.KeyAvailable == true)
            {
                Task.Delay(10);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                _keyPressed = keyInfo.Key;
                if (_keyPressed == ConsoleKey.Escape) { break; }
                _character.Springen(_keyPressed);
            }
            else
            {
                _character.Fallen();
                Task.Delay(5);
            }
            _street.StrasseBauen();
            Console.SetCursorPosition(_cursorLeft - 1, _cursorTop - _character.Hight);
            Console.Write(_character.CharSymbol);
            Console.SetCursorPosition(_cursorLeft - 1, _cursorTop - _character.Hight + 1);
            Console.WriteLine(" ");
            Console.SetCursorPosition(_cursorLeft - 1, _cursorTop - _character.Hight - 1);
            Console.WriteLine(" ");
            Console.SetCursorPosition(_cursorLeft, _cursorTop);
            Console.WriteLine(_street.Buffer);
            Thread.Sleep(_time);
            _time--;
        }
        while (true);
    }
    //_character._hight == 0 && _street.Buffer[0] != Convert.ToChar("_")
    void Eingabe()
    {
        if (Console.KeyAvailable == true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            _keyPressed = keyInfo.Key;
           
            Task.Delay(5);
        }
    }


}


