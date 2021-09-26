using System;
using Halma.Logic;

namespace Halma.TesterUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunConsoleGUI();
            TestBFS_2x2_closeN_False();
            TestBFS_5x5_closeN_True();
            TestBFS_5x5_farN_False();
            TestBFS_7x7_farN_withStep_False();
            TestBFS_7x7_farN_withStep_True();
            

        }
        private static void TestBFS_2x2_closeN_False()
        {
            System.Console.WriteLine("TestBFS_2x2_closeN_False");  
            Board board = new Board(2);
            Pair initial = new Pair(0, 0);
            Pair dest = new Pair(1, 1);

            board[0, 0] = "A";
            board[1, 1] = "A";

            System.Console.WriteLine(Utilities.BFS(initial, dest, board));
        }
        private static void TestBFS_5x5_closeN_True()
        {
            System.Console.WriteLine("TestBFS_5x5_closeN_True");
            Board board = new Board(5);
            Pair initial = new Pair(2,2);
            Pair dest = new Pair(1, 3);

            board[0,0]="B";
            board[1,1]="B";
            board[2,2]="A";
            board[3,3]="B";

            System.Console.WriteLine(Utilities.BFS(initial, dest, board));

        }
        private static void TestBFS_5x5_farN_True()
        {
            System.Console.WriteLine("TestBFS_5x5_farN_True");
            Board board = new Board(5);
            Pair initial = new Pair(2,2);
            Pair dest = new Pair(4,4);
            board[0,0]="B";
            board[1,1]="B";
            board[2,2]="A";
            board[3,3]="B";

            System.Console.WriteLine(Utilities.BFS(initial, dest, board));


        }
        private static void TestBFS_5x5_farN_False()
        {
            System.Console.WriteLine("TestBFS_5x5_farN_False");
            Board board = new Board(5);
            Pair initial = new Pair(2,2);
            Pair dest = new Pair(0,0);
            board[0,0]="B";
            board[1,1]="B";
            board[2,2]="A";
            board[3,3]="B";
            System.Console.WriteLine(Utilities.BFS(initial, dest, board));

        }
        private static void TestBFS_7x7_farN_withStep_False()
        {
            System.Console.WriteLine("TestBFS_7x7_farN_withStep_False");
            Board board = new Board(7);
            Pair initial = new Pair(0, 0);
            Pair dest = new Pair(1,5);
            board[0,0]="B";
            board[1,1]="B";
            board[2,2]="A";
            board[3,3]="B";
            board[1,3]="A";
            board[3,5]="A";
            System.Console.WriteLine(Utilities.BFS(initial, dest, board));

        }
        private static void TestBFS_7x7_farN_withStep_True()
        {
            System.Console.WriteLine("TestBFS_7x7_farN_withStep_True");
            Board board = new Board(7);
            Pair initial = new Pair(0, 0);
            Pair dest = new Pair(2,6);
            board[0,0]="B";
            board[1,1]="B";
            board[2,2]="A";
            board[3,3]="B";
            board[1,3]="A";
            board[3,5]="A";
            System.Console.WriteLine(Utilities.BFS(initial, dest, board));

        }

        private static void TestBFS_8x8_farN_withStep_True()
        {
            Board board = new Board(8);
            Pair initial = new Pair(6, 7);
            Pair dest = new Pair(4, 1);

            board[3, 2] = "A";
            board[1, 2] = "A";
            board[1, 4] = "A";
            board[1, 6] = "A";
            board[3, 4] = "A";
            board[3, 6] = "A";
            board[5, 6] = "A";


            System.Console.WriteLine(Utilities.BFS(initial, dest, board));
        }

        private static void RunConsoleGUI()
        {
            GameLogic game = new GameLogic(6, new string[] { "Dimas", "Alejandra" });
            while (!game.IsFinished)
            {

                DrawBoard(game.Board, game.IndexPlayerInTurn);
                var pieceToMove = AskForPieceOrPosition(true);
                //Saber si esta pieza PERTENECE al JUGADOR en TURNO.
                bool belongs = game.BelongToPlayerInTurn(pieceToMove);
                if (!belongs)
                {
                    Console.WriteLine("The selected piece|position is NOT valid");
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
                        System.Console.WriteLine("Valid Movement. Thank you.");
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

        private static void DrawBoard(Board board, int playerInTurn)
        {
            System.Console.WriteLine();
            System.Console.WriteLine($"Is Player:{playerInTurn} turn");
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    string box = board[i, j] != null ? board[i, j] : "0";
                    if (box == "A")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                    }
                    else if (box == "B")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    Console.Write(box + " ");
                }
                System.Console.WriteLine();
            }
            Console.ResetColor();
            System.Console.WriteLine("-----");
        }
    }
}
