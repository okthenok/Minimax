using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MiniMax
{
    public class TicTacToe
    {
        int[,] board = new int[3, 3];
        public Toe currToe;
        Random rand = new Random();

        public TicTacToe(bool playerStarts)
        {
            currToe = new Toe(board, playerStarts);

            Minimaxer minimaxer = new Minimaxer();
            minimaxer.Minimax(currToe, playerStarts);
        } 

        public void playerMove(int x, int y)
        {
            var temp = (int[,])board.Clone();
            temp[x, y] = 1;
            foreach (Toe toe in currToe.Moves)
            {
                if (toe.Board[x, y] == 1)
                {
                    board = (int[,])temp.Clone();
                    currToe = toe;
                    return;
                }
            }
        }

        public void compMove(bool playerFirst)
        {
            List<Toe> goodMoves = new List<Toe>();

            int temp = playerFirst ? 1 : -1;
            foreach (Toe toe in currToe.Moves)
            {
                if (playerFirst)
                {
                    if (toe.Value < temp)
                    {
                        temp = toe.Value;
                    }
                }
                else
                {
                    if (toe.Value > temp)
                    {
                        temp = toe.Value;
                    }
                }
            }
            foreach (Toe toe in currToe.Moves)
            {
                if (toe.Value == temp)
                {
                    goodMoves.Add(toe);
                }
            }
            currToe = goodMoves[rand.Next(goodMoves.Count)];
            board = (int[,])currToe.Board.Clone();
        }


    }
}
