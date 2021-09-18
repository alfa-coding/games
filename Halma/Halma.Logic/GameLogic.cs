using System;
using System.Collections.Generic;

namespace Halma.Logic
{
    public class GameLogic
    {
        public Board Board { get; set; }
        public string Winner { get; set; }
        public List<Player> Players { get; set; }
        public int IndexPlayerInTurn { get; set; }
        public bool IsFinished{ get; set;}

    public GameLogic(int size, string[] names)
    {
        this.Players = new List<Player>(){new Player(names[0]),new Player(names[1])};
        Utilities.InitializePosition(this.Players,size);
        this.Board = new Board(size);
        Utilities.FillBoard(this.Players,this.Board);
        this.IsFinished = false;
    }
        
       

        public bool BelongToPlayerInTurn(Pair pieceToMove)
        {
            //como saber cuál es el jugador que esta en turno?
            var playerInTurn = Players[IndexPlayerInTurn];
            var hasPiece = playerInTurn.HasPiece(pieceToMove);
            return hasPiece;
            
        }

        public int CheckForWinners()
        {
           for (int i = 0; i < this.Board.Size; i++)
           {
                for (int j = 0; j < this.Board.Size; j++)
                {
                    
                }
           }
            
        }

        private bool DidPlayerWon()
        {
            for (int i = 0; i < this.Board.Size - 3; i++)
            {
                for (int j = 0; j < this.Board.Size - 3 - i; j++)
                {
                    string currentLetter = this.Board[i,j];
                  if (currentLetter != "A")
                  {
                      return false;
                  }


                }
            }
            return true;
        }

        public bool TryMove(Pair pieceToMove, Pair newPosition)
        {
            if (CanMove(pieceToMove, newPosition))
            {
                var playerInTurn = Players[IndexPlayerInTurn];//aqui obtengo el jugador en turno
                playerInTurn.UpdatePieces(pieceToMove, newPosition); //ahora actualizamos la pieza vieja con la nueva posicion de que esta pieza estara                                             
                UpdateTurn();
                return true;
            }
            return false;
        }

        private bool CanMove(Pair pieceToMove, Pair newPosition)
        {
            return Utilities.BFS(pieceToMove,newPosition,this.Board);
        }

        private void UpdateTurn()
        {
            IndexPlayerInTurn = (++IndexPlayerInTurn) % Players.Count;//asi actualizo el turno, pero aun no se si es a este jugador al que le toca jugar

        }
    }
}
