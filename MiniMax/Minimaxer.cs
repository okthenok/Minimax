using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMax
{
    public class Minimaxer
    {
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
                    value = Math.Max(value, Minimax(move, false, alpha, beta));
                    
                    alpha = Math.Max(alpha, value);
                    if (alpha >= beta)
                    {
                        break;
                    }
                }
                state.Value = value;
                return value;
            }
            else
            {
                int value = int.MaxValue;
                foreach (IGameState move in state.Moves)
                {
                    value = Math.Min(value, Minimax(move, true, alpha, beta));
                    
                    beta = Math.Min(beta, value);
                    if (alpha >= beta)
                    {
                        break;
                    }
                }
                state.Value = value;
                return value;
            }
        }


    }
}
