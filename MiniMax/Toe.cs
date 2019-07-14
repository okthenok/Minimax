using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMax
{
    public class Toe : IGameState
    {
        public int[,] Board = new int[3, 3];
        public Toe()
        {

        }
        public Toe(int[,] board)
        {
            Board = board;
        }

        public void findMoves(bool xTurn)
        {
            List<Toe> moves = new List<Toe>();
            var temp = Board;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (temp[i, j] == 0)
                    {
                        if (xTurn) { temp[i, j] = 1; }
                        else { temp[i, j] = 2; }
                        moves.Add(new Toe(temp));
                    }
                }
            }
            Moves = moves;
        }
    }
}
