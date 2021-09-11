using System;
using System.Collections.Generic;

namespace Halma.Logic
{
    public interface IPlayer
    {
       List<Pair> PiecePositions { get; set; }

       Pair ProposeBestMove(IBoard board, List<IPlayer> enemies );
    }
}
