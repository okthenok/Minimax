using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMax
{
    public class TicTacToe
    {
        int[,] board = new int[3, 3];
        public Toe currToe;
        Random rand = new Random();

        public TicTacToe(bool playerStarts)
        {
            currToe = new Toe(board);
            currToe.findMoves(playerStarts);

            Minimaxer minimaxer = new Minimaxer();
            minimaxer.Minimax(currToe, !playerStarts);

        } 

        public void playerMove(int x, int y)
        {
            var temp = board;
            temp[x, y] = 1;
            foreach (Toe toe in currToe.Moves)
            {
                if (temp == toe.Board)
                {
                    board = temp;
                    currToe = toe;
                    return;
                }
            }
        }

        public void compMove(bool goesFirst)
        {
            List<Toe> goodMoves = new List<Toe>();
            foreach (Toe toe in currToe.Moves)
            {
                if (toe.Value == 1)
                {
                    goodMoves.Add(toe);
                }
            }
            currToe = goodMoves[rand.Next(goodMoves.Count)];
        }

    }
}
