using System;
using Halma.Logic;

namespace Halma.TesterUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLogic game = new GameLogic(6,new string[]{"Dimas", "Alejandra"});
            while (!game.IsFinished)
            {
                DrawBoard(game.Board);
                var pieceToMove = AskForPieceOrPosition(true);
                //Saber si esta pieza PERTENECE al JUGADOR en TURNO.
                bool belongs = game.BelongToPlayerInTurn(pieceToMove);
                if (!belongs)
                {
                    Console.WriteLine("The selected piece is NOT yours");
                }
                else
                {
                    var newPosition = AskForPieceOrPosition(false);
                    bool wasPosible = game.TryMove(pieceToMove, newPosition);
                    if (!wasPosible)
                    {
                        Console.WriteLine("This movement can not be performed");
                    }
                    else
                    {
                        int possibleWinner = game.CheckForWinners();
                        if (possibleWinner != -1)
                        {
                            Console.WriteLine($"Player {possibleWinner} won the game");

                        }
                    }

                }

            }
            Console.WriteLine("Thank you!");
            
        }

      

        private static Pair AskForPieceOrPosition(bool forPiece)
        {
            string message = forPiece ? "piece" : "position";

            Console.WriteLine($"Choose the {message}, in the following format : r , c ");
            var line = Console.ReadLine();
            var splitted = line.Split(',');
            int r = int.Parse(splitted[0]);
            int c = int.Parse(splitted[1]);
            Pair p = new Pair(r, c);
            return p;
        }

        private static void DrawBoard(Board board)
        {

            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
