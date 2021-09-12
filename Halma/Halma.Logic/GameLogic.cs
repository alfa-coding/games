using System;
using System.Collections.Generic;

namespace Halma.Logic
{
    public class GameLogic
    {
        public int PlayerInTurn { get; set; }
        public List<IPlayer> Players { get; set; }

        public IBoard Board { get; set; }

        public GameLogic(bool modeSmart=false)
        {
            IPlayer playerA;
            IPlayer playerB;
            
            if (!modeSmart)
            {
                playerA= new StandardPlayer();
                playerB= new StandardPlayer();
            }
            else
            {
                playerA= new StandardPlayer();
                playerB= new SmartPlayer();
                
            }
            
            Players.Add(playerA);
            Players.Add(playerB);
        }

        public bool CanMove(int newR, int newC)
        {

            return true;
        }

        public bool Move(int newR, int newC, int oldR, int oldC)
        {
            if (!CanMove(newR,newC))
            {
                return false;
            }

            int indexPlayer= PlayerInTurn;

            var player = Players[indexPlayer];

            player.UpdateTrack(newR, newC, oldR, oldC);

            UpdateTurn();

            return true;
        }

        public bool CheckWin()
        {
            return true;
        }

        private void UpdateTurn()
        {
            PlayerInTurn = (++PlayerInTurn)%Players.Count;
        }

    }
}
