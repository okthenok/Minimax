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
            currToe = new Toe(board);
            currToe.playerTurn = playerStarts;

            Minimaxer minimaxer = new Minimaxer();
            minimaxer.Minimax(currToe, !playerStarts);

        } 

        public void playerMove(int x, int y)
        {
            var temp = (int[,])board.Clone();
            temp[x, y] = 1;
            foreach (Toe toe in currToe.Moves)
            {
                if (temp.Rank == toe.Board.Rank &&
                    Enumerable.Range(0, temp.Rank).All(dimension => temp.GetLength(dimension) == toe.Board.GetLength(dimension)) &&
                    temp.Cast<int>().SequenceEqual(toe.Board.Cast<int>()))
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
                if (toe.Value == (goesFirst? 1 : -1))
                {
                    goodMoves.Add(toe);
                }
            }
            currToe = goodMoves[rand.Next(goodMoves.Count)];
        }

    }
}
