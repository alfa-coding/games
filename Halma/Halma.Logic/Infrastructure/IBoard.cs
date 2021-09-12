using System;

namespace Halma.Logic
{
    public interface IBoard
    {
        int Size { get; }

        char this [int i,int j]{get;set;}
    }
}
