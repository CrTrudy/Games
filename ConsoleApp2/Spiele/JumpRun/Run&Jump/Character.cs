namespace StreetRun;

public class Character : ICharacter
{
    public char CharSymbol { get; set; }
    public int Hight { get; set; }
    int _sprung { get; set; }
    int _sprungKraft = 6;
    int _gravitation = 3;

    
    public Character()
    {
        CharSymbol = Convert.ToChar("Ǿ");
        Hight = 0;
        _sprung = 0;
    }

    public void Springen(ConsoleKey key)
    {
        if (key == ConsoleKey.UpArrow && _sprung < 5 * _sprungKraft)
        {
            _sprung += _sprungKraft;
        }
        else if (key != ConsoleKey.UpArrow && _sprung > 0)
        {
            _sprung -= _sprungKraft / _gravitation;
        }
        Hight = _sprung / _sprungKraft;
    }
    public void Fallen()
    {
        if (_sprung > 0)
        {
            _sprung -= _sprungKraft / _gravitation;
        }
        Hight = _sprung / _sprungKraft;
    }

}
