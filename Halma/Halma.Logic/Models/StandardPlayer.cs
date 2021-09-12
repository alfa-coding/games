using System;
using System.Collections.Generic;

namespace Halma.Logic
{
    public class StandardPlayer : IPlayer
    {
        public List<Pair> PiecePositions { get; set; }
        public StandardPlayer()
        {
            this.PiecePositions= new List<Pair>();
            Utilities.InitializePositions(PiecePositions);
        }
        public Pair ProposeBestMove(IBoard board, List<IPlayer> enemies)
        {
            throw new NotImplementedException();
        }

        public void UpdateTrack(int newR, int newC, int oldR, int oldC)
        {
            throw new NotImplementedException();
        }


    }
}
