using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMax
{
    public class Toe : IGameState
    {
        public int[,] Board = new int[3, 3];
        public Toe(int[,] board)
        {
            Board = board;
        }

        public void findMoves(bool playerTurn)
        {
            List<Toe> moves = new List<Toe>();
            var temp = (int[,])Board.Clone();

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
                        moves[moves.Count - 1].CheckGameOver();

                        for (int x = 0; i < Board.GetLength(0); i++)
                        {
                            for (int y = 0; j < Board.GetLength(1); j++)
                            {
                                temp[i, j] = Board[i, j];
                            }
                        }
                    }
                }
            }
            Moves = moves;


            // uh don't do this, do the additional going down the tree somewhere else, this will make stack overflow or (try) generate the whole tree
            bool nextMove = !playerTurn;
            foreach (Toe toe in moves)
            {
                if (!toe.IsTerminal)
                {
                    toe.findMoves(nextMove);
                }
            }
        }

        public void CheckGameOver()
        {
            int[] row = new int[3]; //maybe make this and column to be lists, and make the checks at the end instead with for loops
            int[] column = new int[3];
            int lrdiagonal = 0;
            int rldiagonal = 0;
            for (int x = 0; x < Board.GetLength(0); x++)
            {
                for (int y = 0; y < Board.GetLength(1); y++)
                {
                    column[x] += Board[x, y];
                }
                for (int z = 0; z < Board.GetLength(1); z++)
                {
                    row[x] += Board[z, x];
                }
            }

            for (int i = 0; i < row.GetLength(0); i++)
            {
                if (column[i] == 3 || row[i] == 3)
                {
                    this.IsTerminal = true;
                    this.Value = 1;
                }
                if (column[i] == -3 || row[i] == -3)
                {
                    this.IsTerminal = true;
                    this.Value = -1;
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
