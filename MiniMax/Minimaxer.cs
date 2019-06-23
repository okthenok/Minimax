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

        public int Minimax(IGameState state, bool maxTurn)
        {
            if (state.IsTerminal) 
            {
                return state.Value;
            }

            if (maxTurn)
            {
                int value = int.MinValue;
                foreach (IGameState move in state.Moves)
                {
                    value = Math.Max(value, Minimax(move, false));
                }
                return value;
            }
            else
            {
                int value = int.MaxValue;
                foreach (IGameState move in state.Moves)
                {
                    value = Math.Min(value, Minimax(move, true));
                }
                return value;
            }
        }
    }
}
