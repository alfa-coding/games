using System;

namespace Halma.Logic
{
    public class Board : IBoard
    {
        private int size;
        private char[,] internalBoard;
        public Board()
        {
            this.size= 16;
            internalBoard= new char[Size,Size];
        }
        
        public int Size { get=>size;  }
        
        public char this[int i, int j]
        {
            get
            {
                return internalBoard[i,j];
            }
            set{

            }
        }
    }
}
