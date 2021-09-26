using System.Collections.Generic;

namespace Halma.Logic
{
    public class Utilities
    {
        private static bool IsCloseNeighborg(Pair initialPosition, Pair destination, int[] dirX, int[] dirY, Board board)
        {
            for (int i = 0; i < dirX.Length; i++)
            {
                var newRowPosition = initialPosition.Row + dirY[i];
                var newColPosition = initialPosition.Col + dirX[i];

                if (InRange(newRowPosition, newColPosition, board.Size))
                {
                    bool wasEmpty = IsEmpty(newRowPosition, newColPosition, board);
                    bool arrived = GotThere(new Pair(newRowPosition, newColPosition), destination);
                    if (wasEmpty && arrived)
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        private static bool IsEmpty(int newRowPosition, int newColPosition, Board board)
        {
            return board[newRowPosition, newColPosition] == null;
        }


        private static bool InRange(int newRowPosition, int newColPosition, int boardSize)
        {
            return (newColPosition >= 0 && newColPosition < boardSize)
                    && (newRowPosition >= 0 && newRowPosition < boardSize);
        }

        public static bool BFS(Pair initialPosition, Pair destination, Board board, int[] dirX, int[] dirY)
        {
            int[,] steps = new int[board.Size, board.Size];
            steps[initialPosition.Row, initialPosition.Col] = 1;



            Queue<Pair> queue = new Queue<Pair>();
            queue.Enqueue(initialPosition);
            while (queue.Count != 0)
            {

                var current = queue.Dequeue();

                if (GotThere(current, destination))
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

                        bool wasInRange = InRange(newRowPosition, newColPosition, board.Size);
                        if (wasInRange)
                        {
                            bool wasFarNeighborg = IsFarNeighborg(newColPosition, newRowPosition, board, dirY[i], dirX[i]);
                            if (wasFarNeighborg)
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
            }
            return false;
        }

        public static bool CanMove(Pair pieceToMove, Pair newPosition, Board board)
        {
            //directions=  w,  nw, n, ne, w, se, s, sw
            int[] dirX = { -1, -1, 0, 1, 1, 1, 0, -1 };
            int[] dirY = { 0, -1, -1, -1, 0, 1, 1, 1 };

            //quizas el destino es mi vecino cercano.
            if (Utilities.IsCloseNeighborg(pieceToMove, newPosition, dirX, dirY, board))
            {
                return true;
            }
            return Utilities.BFS(pieceToMove, newPosition, board, dirX, dirY);
        }

        private static bool IsFarNeighborg(int newColPosition, int newRowPosition, Board board, int dirY, int dirX)
        {
            //si la casilla vecina esta vacia, no es vecino lejano
            if (IsEmpty(newRowPosition, newColPosition, board))
            {
                return false;
            }
            bool isFurtherReacheable = InRange(newRowPosition + dirY, newColPosition + dirX, board.Size);
            //si a pesar de que la casilla vecina no este vacia, y, la lejana esta ocupada
            if (isFurtherReacheable)
            {
                bool wasEmpty = IsEmpty(newRowPosition + dirY, newColPosition + dirX, board);
                if (wasEmpty)
                {

                    return true;
                }
            }

            return false;
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
        internal static void FillBoard(List<Player> players, Board board)
        {
            CleanBoard(board);
            string[] idenfiers = { "B", "A" };
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


    }
}
