using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMax
{
    public class TicTacToe
    {
        int[,] board = new int[3, 3];
        Toe currToe = new Toe();

        public TicTacToe()
        {

        }

        public void playerMove(bool xTurn, int x, int y)
        {
            currToe.findMoves(xTurn);
            var temp = board;
            board[x, y] = 1; 

            foreach (Toe move in currToe.Moves)
            {
                if (move.Board == temp)
                {
                    currToe = move;
                }
            }
        }
        public void compMove()
        {
            Minimaxer minimaxer = new Minimaxer();
            minimaxer.Minimax(currToe, true);

            List<Toe> moves = new List<Toe>();
            moves = currToe.Moves;

        }

    }
}
