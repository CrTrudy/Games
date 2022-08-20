namespace TetrisRohbau
{
    public class Zett : IZett
    {
        public List<bool[,]> Zet { get; }
        bool[,] _zettSeite;
        bool[,] _zettHoch;


        public Zett()
        {
            Zet = new List<bool[,]>();
            _zettSeite = new bool[3, 3] { { false, false, false }, { true, true, false }, { false, true, true } };
            _zettHoch = new bool[3, 3] { { false, false, true }, { false, true, true }, { false, true, false } };
            Zet.Add(_zettHoch);
            Zet.Add(_zettSeite);
        }
    }

}