using System;
using System.Text;

namespace MiniMax
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game;
            bool playerStarts;

            Console.WriteLine("Do you want to play first? Y/N");
            if (Console.ReadLine().ToLower() == "y")
            {
                playerStarts = true;
            }
            else
            {
                playerStarts = false;
            }
            game = new TicTacToe(playerStarts);

            StringBuilder sb = new StringBuilder();
            int[] location = new int[2];
            if (playerStarts)
            {
                for (int i = 0; i < game.currToe.Board.GetLength(0); i++)
                {
                    sb.Remove(0, sb.Length);
                    for (int j = 0; j < game.currToe.Board.GetLength(1); j++)
                    {
                        sb.Append(game.currToe.Board[i, j] + " ");
                    }
                    Console.WriteLine(sb.ToString());
                }
                Console.WriteLine("Which block would you like to select? (x, y)");
                location = Array.ConvertAll(Console.ReadLine().Split(", "), int.Parse);
                game.playerMove(location[0], location[1]);
            }
            while (!game.currToe.IsTerminal)
            {
                game.compMove(!playerStarts);

                for (int i = 0; i < game.currToe.Board.GetLength(0); i++)
                {
                    sb.Remove(0, sb.Length);
                    for (int j = 0; j < game.currToe.Board.GetLength(1); j++)
                    {
                        sb.Append(game.currToe.Board[i, j] + " ");
                    }
                    Console.WriteLine(sb.ToString());
                }
                Console.WriteLine("Which block would you like to select? (x, y)");
                location = Array.ConvertAll(Console.ReadLine().Split(", "), int.Parse);
                game.playerMove(location[0], location[1]);
            }
        }
    }
}
