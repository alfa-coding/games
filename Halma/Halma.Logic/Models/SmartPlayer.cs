using System;
using System.Collections.Generic;
using System.Linq;

namespace Halma.Logic
{
    public class SmartPlayer : IPlayer
    {
        public List<Pair> PiecePositions { get; set; }

        public SmartPlayer()
        {
            this.PiecePositions = new List<Pair>();
            Utilities.InitializePositions(PiecePositions);
        }
        public Pair ProposeBestMove(IBoard board, List<IPlayer> enemies)
        {
            throw new NotImplementedException();
        }

        public void UpdateTrack(int newR, int newC, int oldR, int oldC)
        {
            Pair old= new Pair{Row= oldR, Col=oldC};
            var piece= PiecePositions.FirstOrDefault(p => (p.Col==old.Col&&p.Row==old.Row));
            piece.Row=newR;
            piece.Col=newC;
        }






    }
}
