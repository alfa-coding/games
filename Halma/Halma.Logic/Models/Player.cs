using System;
using System.Collections.Generic;
using System.Linq;

namespace Halma.Logic
{
    public class Player
    {
        public string Name { get; set; }

        public Player(string name)
        {
            this.Name= name;
            this.Pieces= new List<Pair>();
        }

        //Todo Player necesita una lista de fichas y a la misma vez necesita saber si una ficha le pertenece o no
        public List<Pair> Pieces { get; set; }

        public bool HasPiece(Pair piece)
        {
            var myPiece = Pieces.FirstOrDefault(p => (p.Row == piece.Row && p.Col == piece.Col));
            //if (myPiece == null)
            //{
            //    return false;
            //}
            //return true;
            return myPiece != null;
        }

        internal void UpdatePieces(Pair pieceToMove, Pair newPosition)
        {
            var myPiece = Pieces.FirstOrDefault(p => (p.Row == pieceToMove.Row && p.Col == pieceToMove.Col));
            myPiece.Row = newPosition.Row;
            myPiece.Col = newPosition.Col;

        }
    }
}