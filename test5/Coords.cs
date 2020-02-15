namespace test
{
    class Coords
    {
        public int Left;
        public int Right;

        Coords() { }

        public Coords(string[] t)
        {
            Left = int.Parse(t[0]);
            Right = int.Parse(t[1]);
        }
    }
}
