namespace test
{
    class Coords
    {
        public int Left;
        public int Right;

        Coords() { }

        public Coords(int[] c)
        {
            Left = c[0];
            Right = c[1];
        }
    }
}
