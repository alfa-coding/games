using System;

namespace Halma.Logic
{
    public class Pair
    {
        public Pair(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}
