using System;

namespace Halma.Logic
{
    public class Board 
    {
        private int size;
        private string[,] internalBoard;
        public Board(int size)
        {
            this.size= size;
            internalBoard= new string[Size,Size];
        }
        
        public int Size { get=>size;  }
        
        public string this[int i, int j]
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
