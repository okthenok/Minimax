using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMax
{
    public class Minimaxer
    {
        int alpha = -1000;
        int actual = 0;
        int beta = 1000;

        public Minimaxer()
        {

        }

        public int Minimax(IGameState state, bool isMax, int alpha = int.MinValue, int beta = int.MaxValue)
        {
            if (state.IsTerminal) 
            {
                return state.Value;
            }

            if (isMax)
            {
                int value = int.MinValue;
                foreach (IGameState move in state.Moves)
                {
                    value = Math.Max(value, Minimax(move, false));
                    move.Value = value;
                    alpha = Math.Max(alpha, value);
                    if (alpha >= beta)
                    {
                        break;
                    }
                }
                return value;
            }
            else
            {
                int value = int.MaxValue;
                foreach (IGameState move in state.Moves)
                {
                    value = Math.Min(value, Minimax(move, true));
                    move.Value = value;
                    beta = Math.Min(beta, value);
                    if (alpha >= beta)
                    {
                        break;
                    }
                }
                return value;
            }
        }
    }
}
