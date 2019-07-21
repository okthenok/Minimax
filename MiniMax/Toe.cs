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

        public void findMoves(bool playerTurn)
        {
            List<Toe> moves = new List<Toe>();
            var temp = Board;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (temp[i, j] == 0)
                    {
                        if (playerTurn)
                        {
                            temp[i, j] = 1;
                        }
                        else
                        {
                            temp[i, j] = -1;
                        }
                        moves.Add(new Toe(temp));
                    }
                }
            }
            Moves = moves;

            bool nextMove = !playerTurn;
            foreach (Toe toe in moves)
            {
                toe.findMoves(nextMove);
            }
        }

        public void CheckGameOver()
        {
            int row = 0; //maybe make this and column to be lists, and make the checks at the end instead with for loops
            int column = 0;
            int lrdiagonal = 0;
            int rldiagonal = 0;
            for (int x = 0; x < Board.GetLength(0); x++)
            {
                row = 0;
                column = 0;
                for (int y = 0; y < Board.GetLength(1); y++)
                {
                    row += Board[x, y];
                    if (row == 3 || column == 3)
                    {
                        this.IsTerminal = true;
                        this.Value = 1;
                        return;
                    }
                    if (row == -3 || column == -3)
                    {
                        this.IsTerminal = true;
                        this.Value = -1;
                        return;
                    }
                }
                for (int z = 0; z < Board.GetLength(1); z++)
                {
                    column += Board[z, x];
                    if (row == 3 || column == 3)
                    {
                        this.IsTerminal = true;
                        this.Value = 1;
                        return;
                    }
                    if (row == -3 || column == -3)
                    {
                        this.IsTerminal = true;
                        this.Value = -1;
                        return;
                    }
                }
            }

            lrdiagonal += Board[0, 0] + Board[1, 1] + Board[2, 2];
            rldiagonal += Board[2, 0] + Board[1, 1] + Board[0, 2];

            if (lrdiagonal == 3 || rldiagonal == 3)
            {
                this.IsTerminal = true;
                this.Value = 1;
            }
            if (lrdiagonal == -3 || rldiagonal == -3)
            {
                this.IsTerminal = true;
                this.Value = -1;
            }

            //tie check
            bool isFull = true;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] == 0)
                    {
                        isFull = false;
                    }
                }
            }
            if (isFull)
            {
                this.IsTerminal = true;
                this.Value = 0;
            }
        }
    }
}
