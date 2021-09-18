using System;
using System.Collections.Generic;

namespace Halma.Logic
{
    public interface IPlayer
    {
        string Name { get; set; }

        List<Pair> PiecePositions { get; set; }

        Pair ProposeBestMove(Board board, List<IPlayer> enemies);

        void UpdateTrack(int newR, int newC, int oldR, int oldC);

    }
}
