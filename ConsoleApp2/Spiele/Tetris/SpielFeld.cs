namespace TetrisRohbau
{
    public class SpielFeld : ISpielFeld
    {
        int _breite = 12;
        int _hight = 15;
        public bool[,] Feld { get; set; }
        public SpielFeld()
        {

            Feld = new bool[15, 12];
            for (int i = 0; i < _hight; i++)
            {
                for (int j = 0; j < _breite; j++)
                {
                    Feld[i, j] = false;
                }
            }
        }
    }
}