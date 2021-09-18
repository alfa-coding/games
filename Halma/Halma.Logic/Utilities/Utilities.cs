using System.Collections.Generic;

namespace Halma.Logic
{
    public class Utilities
    {
        private static bool IsCloseNeighborg(Pair initialPosition, Pair destination, int[] dirX, int[] dirY, int boardSize)
        {
            for (int i = 0; i < dirX.Length; i++)
            {
                var newRowPosition = initialPosition.Row + dirY[i];
                var newColPosition = initialPosition.Col + dirX[i];

                if (InRange(newRowPosition, newColPosition, boardSize) && newColPosition == destination.Col && newRowPosition == destination.Row)
                {
                    return true;
                }

            }
            return false;
        }

        internal static void FillBoard(List<Player> players, Board board)
        {
            CleanBoard(board);
            string[] idenfiers = { "A", "B" };
            for (int i = 0; i < players.Count; i++)
            {
                foreach (var piece in players[i].Pieces)
                {
                    board[piece.Row, piece.Col] = idenfiers[i];
                }
            }
        }

        private static void CleanBoard(Board board)
        {
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    board[i, j] = null;
                }
            }
        }

        private static bool InRange(int newRowPosition, int newColPosition, int boardSize)
        {
            return (newColPosition >= 0 && newColPosition < boardSize)
                    && (newRowPosition >= 0 && newRowPosition < boardSize);
        }

        public static bool BFS(Pair initialPosition, Pair destination, Board board)
        {
            int[,] steps = new int[board.Size, board.Size];
            steps[initialPosition.Row, initialPosition.Col] = 1;

            //directions=  w,  nw, n, ne, w, se, s, sw
            int[] dirX = { -1, -1, 0, 1, 1, 1, 0, -1 };
            int[] dirY = { 0, -1, -1, -1, 0, 1, 1, 1 };

            Queue<Pair> queue = new Queue<Pair>();
            queue.Enqueue(destination);
            while (queue.Count != 0)
            {

                var current = queue.Dequeue();

                if (GotThere(current, destination))
                {
                    return true;
                }
                //quizas el destino es mi vecino cercano.
                if (IsCloseNeighborg(current, destination, dirX, dirY, board.Size))
                {
                    return true;
                }
                //quizas pueda llegar al destino, a traves de algun vecino lejano
                else
                {
                    for (int i = 0; i < dirX.Length; i++)
                    {
                        //posiciones del vecino cercano.
                        var newRowPosition = current.Row + dirY[i];
                        var newColPosition = current.Col + dirX[i];

                        if (InRange(newRowPosition, newColPosition, board.Size) && IsFarNeighborg(newColPosition, newRowPosition, board, dirY[i], dirX[i]))
                        {
                            int farColPosition = newColPosition + dirX[i];
                            int farRowPosition = newRowPosition + dirY[i];

                            if (steps[farRowPosition, farColPosition] >= 1)
                            {
                                //I already passed over this position.
                                continue;
                            }
                            else
                            {
                                //I mark the amount of steps to get there so I dont walk again.
                                steps[farRowPosition, farColPosition] = steps[current.Row, current.Col] + 1;
                                //meter en la cola, a la casilla del vecino lejano, que este en la misma direccion del vecino cercano
                                queue.Enqueue(new Pair(farRowPosition, farColPosition));
                            }
                        }
                    }
                }
            }
            return false;
        }

        private static bool IsFarNeighborg(int newColPosition, int newRowPosition, Board board, int dirY, int dirX)
        {
            //si la casilla vecina esta vacia, no es vecino lejano
            if (board[newRowPosition, newColPosition] == null)
            {
                return false;
            }
            //si a pesar de que la casilla vecina no este vacia, y, la lejana esta ocupada
            if (board[newRowPosition + dirY, newColPosition + dirX] != null)
            {
                return false;
            }

            return true;
        }

        private static bool GotThere(Pair current, Pair destination)
        {
            return current.Row == destination.Row && current.Col == destination.Col;
        }


        //Player A, starts at the bottom rigth
        //Player B, starts at the upLeftCorner
        public static void InitializePosition(List<Player> players, int sizeBoard)
        {
            for (int i = 0; i < sizeBoard - 3; i++)
            {
                for (int j = 0; j < sizeBoard - 3 - i; j++)
                {
                    //player B
                    players[0].Pieces.Add(new Pair(i, j));
                    //Player A
                    players[1].Pieces.Add(new Pair(sizeBoard - i - 1, sizeBoard - j - 1));

                }
            }
        }


    }
}
