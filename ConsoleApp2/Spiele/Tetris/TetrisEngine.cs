namespace TetrisRohbau
{
    public class TetrisEngine
    {
        ISpielFeld _spielFeld = new SpielFeld();
        TetrisDisplay _tetrisDisplay = new TetrisDisplay();
        ISteine Isteine = new Steine();
        int _posLeft = 5;
        int _breite = 12;
        int _posTop = 0;
        int _hight = 15;
        int _version = 0;
        List<bool[,]> _stein = new List<bool[,]>();
        int _zeit = 200;
        ConsoleKey _key;

        public TetrisEngine()
        {
            Task.Run(() => Steuerung());
            Step();
        }

        void Steuerung()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                ConsoleKey _key = keyInfo.Key;
                switch (((byte)_key))
                {
                    case ((byte)ConsoleKey.UpArrow):
                        Drehen();
                        break;
                    case ((byte)ConsoleKey.DownArrow):
                        NachRechts();
                        break;
                    case ((byte)ConsoleKey.LeftArrow):
                        NachLinks();
                        break;
                }

            }
            Thread.Sleep(300);
            Steuerung();
        }

        void Drehen()
        {
            if (_stein.Count > _version)
            {
                DeleteTrue();
                _version++;
            }
            else
            {
                DeleteTrue();
                _version = 0;
            }
        }
        void NachRechts()
        {
            if (_posLeft + _stein[_version].GetLength(1) < _breite)
            {
                DeleteTrue();
                _posLeft++;
            }
        }
        void NachLinks()
        {
            if (_posLeft > 0)
            {
                DeleteTrue();
                _posLeft--;
            }
        }

        void Step()
        {
            _version = 0;
            _posLeft = 5;
            _posTop = 0;
            _stein.Clear();
            _stein = Isteine.GetRandom();

            do
            {
                if (DerFall()) { break; };
                _posTop++;
                Thread.Sleep(_zeit);
            } while (_posTop < _hight);

            Step();
        }

        bool DerFall()
        {
            int _newPosTop = 0;
            int _newPosLeft = 0;
            for (var i = 0; i < _stein[_version].GetLength(0); i++)
            {
                for (var j = 0; j < _stein[_version].GetLength(1); j++)
                {
                    if (_posTop + i < _hight && _posTop + i >= 0) { _newPosTop = _posTop + i; }
                    if (_posLeft + j < _breite && _posLeft + j >= 0) { _newPosLeft = _posLeft + j; }
                    if (_spielFeld.Feld[_newPosTop, _newPosLeft] == true && _stein[_version][i, j] == true)
                    {
                        Console.WriteLine("Gameover!!!");
                        return true; 
                    }
                    if (_spielFeld.Feld[_newPosTop, _newPosLeft] == false && _stein[_version][i, j] == true)
                    {
                        _spielFeld.Feld[_newPosTop, _newPosLeft] = true;
                    }
                    if (_spielFeld.Feld[_newPosTop, _newPosLeft] == false && _stein[_version][i, j] == false)
                    {
                        _spielFeld.Feld[_newPosTop, _newPosLeft] = false;
                    }
                }
            }
            _tetrisDisplay.DisplayGame(_spielFeld.Feld);
            DeleteTrue();
            return false;
        }

        void DeleteTrue()
        {
            int newPosTop = 0;
            int newPosLeft = 0;
            for (var i = 0; i < _stein[_version].GetLength(0); i++)
            {
                for (var j = 0; j < _stein[_version].GetLength(1); j++)
                {
                    if (_posTop + i < _hight) { newPosTop = _posTop + i; }
                    if (_posLeft + j < _breite) { newPosLeft = _posLeft + j; }

                    if (_spielFeld.Feld[newPosTop, newPosLeft] == true && _stein[_version][i,j] == true)
                    {
                        _spielFeld.Feld[newPosTop, newPosLeft] = false;
                    }   
                }
            }
        }
    }
}