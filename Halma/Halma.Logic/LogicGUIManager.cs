using Halma.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halma.Logic
{
    public enum GameColorBoxInfo
    {
        Black,
        Red,
        Blue
    }
    public class LogicGUIManager
    {
        public Pair StartingPosition { get; set; }
        public LogicGUIManager(GameLogic game)
        {
            Game = game;
        }

        public GameLogic Game { get; }

        public string GetPlayerName(int index)
        {
            return Game.Players[index].Name;
        }

        public int GetBoardSize()
        {
            return Game.Board.Size;
        }

        public ValueBoxInfo ContentBox(int i, int j)
        {
            if (Game.Board[i,j] == null)
            {
                return new ValueBoxInfo() {
                    BrushInfo = GameColorBoxInfo.Black,
                    Content = "0"
                };
            }
            else
            {
                if (Game.Board[i, j] == "A")
                {
                    return new ValueBoxInfo()
                    {
                        BrushInfo = GameColorBoxInfo.Red,
                        Content = "A"
                    };
                }
                else
                {
                    return new ValueBoxInfo()
                    {
                        BrushInfo = GameColorBoxInfo.Blue,
                        Content = "B"
                    };
                }
            }
        }

        
        public DecisionBasedOnSelection ProcessClick(int col, int row)
        {
            //es un click de origen
            if (StartingPosition == null)
            {
                var pieceToMove = new Pair(row, col);
                //Saber si esta pieza PERTENECE al JUGADOR en TURNO.
                bool belongs = Game.BelongToPlayerInTurn(pieceToMove);
                if (!belongs)
                {
                    return new DecisionBasedOnSelection() { 
                        HasError = true, 
                        ErrorMessage = "The piece doesn´t belong to the Player in turn"
                    };
                }
                else
                {
                    StartingPosition = pieceToMove;
                    return new DecisionBasedOnSelection()
                    {
                        HasError = false
                    };
                }
            }
            //es un click de destino
            else
            {
                var newPosition = new Pair(row,col);
                bool wasPosible = Game.TryMove(StartingPosition, newPosition);
                if (!wasPosible)
                {
                    return new DecisionBasedOnSelection()
                    {
                        HasError = true,
                        ErrorMessage = "This movement can not be performed"
                    };
                    
                }
                else
                {
                    StartingPosition = null;
                    return new DecisionBasedOnSelection()
                    {
                        HasError = false
                    };
                }
            }
            
        }
    }
}
