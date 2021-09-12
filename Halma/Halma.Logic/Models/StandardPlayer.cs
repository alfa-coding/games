using System;
using System.Collections.Generic;

namespace Halma.Logic
{
    public class StandardPlayer : IPlayer
    {
        public List<Pair> PiecePositions { get; set; }
        public Pair ProposeBestMove(IBoard board, List<IPlayer> enemies)
        {
            throw new NotImplementedException();
        }

        public void UpdateTrack(int newR, int newC, int oldR, int oldC)
        {
            throw new NotImplementedException();
        }

        void IPlayer.InitializePositions()
        {
            throw new NotImplementedException();
        }
    }
}
