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
        public bool IsFinished { get; set; }

        public GameLogic(int size, string[] names)
        {
            this.Players = new List<Player>() { new Player(names[0]), new Player(names[1]) };
            Utilities.InitializePosition(this.Players, size);
            this.Board = new Board(size);
            Utilities.FillBoard(this.Players, this.Board);
            this.IsFinished = false;
        }



        public bool BelongToPlayerInTurn(Pair pieceToMove)
        {
            //como saber cuál es el jugador que esta en turno?
            var playerInTurn = Players[IndexPlayerInTurn];
            var hasPiece = playerInTurn.HasPiece(pieceToMove);
            return hasPiece;

        }

        //Player A, starts at the bottom rigth corner it needs to reach UpLeftCorner
        //Player B, starts at the upLeftCorner it needs to reach bottom rigth corner        
        public int CheckForWinners()
        {
            

            //asuming is A's turn
            bool upLeftCorner =true;
            string letterValue ="A";
            
            //if B were in turn, I update its values
            if (IndexPlayerInTurn == 1)
            {
               upLeftCorner=false;
               letterValue="B";

            }

            bool won= DidPlayerWon(upLeftCorner,letterValue);
            if (won)
            {
                return this.IndexPlayerInTurn;
            }

            return -1;

        }

        private bool DidPlayerWon(bool upLeftCorner, string letter)
        {
            int sizeBoard = this.Board.Size;
            for (int i = 0; i < sizeBoard - 3; i++)
            {
                for (int j = 0; j < sizeBoard - 3 - i; j++)
                {

                    string currentLetter = upLeftCorner ? this.Board[i, j] : this.Board[sizeBoard - i - 1, sizeBoard - j - 1];
                    if (currentLetter != letter)
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
            return Utilities.BFS(pieceToMove, newPosition, this.Board);
        }

        private void UpdateTurn()
        {
            IndexPlayerInTurn = (++IndexPlayerInTurn) % Players.Count;//asi actualizo el turno, pero aun no se si es a este jugador al que le toca jugar

        }
    }
}
