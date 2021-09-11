using System;

namespace Halma.Logic
{
    public class GameLogic
    {
        public int PlayerInTurn { get; set; }
        public List<IPlayer> Players { get; set; }

        public IBoard Board { get; set; }

        public GameLogic()
        {
            
        }

        public bool CanMove(int newR, int newC)
        {

        }

        public bool Move(int newR, int newC)
        {

        }

        public bool CheckWin()
        {

        }

        public void UpdateTurn()
        {
            PlayerInTurn = (++PlayerInTurn)%Players.Count;
        }

    }
}
