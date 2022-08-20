namespace TetrisRohbau
{
    public class Steine : ISteine
    {
        Random rand = new Random();

        List<List<bool[,]>> randList;
        List<bool[,]> Ll { get; }
        bool[,] _LlSeiteL;
        bool[,] _LlSeiteR;
        bool[,] _LlHoch;
        bool[,] _LlRunter;

        List<bool[,]> Jj { get; }
        bool[,] _jJSeiteL;
        bool[,] _jJSeiteR;
        bool[,] _jJHoch;
        bool[,] _jJRunter;
        List<bool[,]> Quadrat { get; }
        bool[,] _trueBool;

        List<bool[,]> Zett { get; }
        bool[,] _zettSeite;
        bool[,] _zettHoch;

        List<bool[,]> Sett { get; }
        bool[,] _settSeite;
        bool[,] _settHoch;


        public Steine()
        {
            Ll = new List<bool[,]>();
            _LlSeiteL = new bool[3, 3] { { false, true, false }, { false, true, false }, { false, true, true } };
            _LlHoch = new bool[3, 3] { { false, false, false }, { false, false, true }, { true, true, true } };
            _LlSeiteR = new bool[3, 3] { { true, true, false }, { false, true, false }, { false, true, false } };
            _LlRunter = new bool[3, 3] { { false, false, false }, { true, true, true }, { false, false, true } };
            Ll.Add(_LlHoch);
            Ll.Add(_LlSeiteL);
            Ll.Add(_LlRunter);
            Ll.Add(_LlSeiteR);

            Jj = new List<bool[,]>();
            _jJSeiteL = new bool[3, 3] { { false, true, false }, { false, true, false }, { true, true, false } };
            _jJHoch = new bool[3, 3] { { false, false, false }, { true, false, false }, { true, true, true } };
            _jJSeiteR = new bool[3, 3] { { false, true, true }, { false, true, false }, { false, true, false } };
            _jJRunter = new bool[3, 3] { { false, false, false }, { true, true, true }, { true, false, false } };
            Jj.Add(_jJHoch);
            Jj.Add(_jJSeiteL);
            Jj.Add(_jJRunter);
            Jj.Add(_jJSeiteR);

            Quadrat = new List<bool[,]>();
            _trueBool = new bool[2, 2] { { true, true }, { true, true } };
            Quadrat.Add(_trueBool);

            Zett = new List<bool[,]>();
            _zettSeite = new bool[3, 3] { { false, false, false }, { true, true, false }, { false, true, true } };
            _zettHoch = new bool[3, 3] { { false, false, true }, { false, true, true }, { false, true, false } };
            Zett.Add(_zettHoch);
            Zett.Add(_zettSeite);

            Sett = new List<bool[,]>();
            _settSeite = new bool[3, 3] { { false, false, false }, { false, true, true }, { true, true, false } };
            _settHoch = new bool[3, 3] { { true, false, false }, { true, true, false }, { false, true, false } };
            Sett.Add(_settHoch);
            Sett.Add(_settSeite);

            randList = new List<List<bool[,]>>();
            randList.Add(Zett);
            randList.Add(Sett);
            randList.Add(Jj);
            randList.Add(Ll);
            randList.Add(Quadrat);

        }
        public List<bool[,]> GetRandom()
        {
            return randList[rand.Next(0, randList.Count)];
        }
    }

}