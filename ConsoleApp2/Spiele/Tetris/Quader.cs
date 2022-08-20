namespace TetrisRohbau
{
    public class Quader
    {
        public List<bool[]> Quadrat { get; }
        bool[] _trueBool = new bool[] { true, true };

    public Quader()
        {
            Quadrat = new List<bool[]>();
            Quadrat.Add(_trueBool);
            Quadrat.Add(_trueBool);
        }

    }
}