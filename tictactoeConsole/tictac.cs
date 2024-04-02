using System;


namespace tictactoe
{
    public class TicTacToe
    {
        public static bool Cheker(string[,] board)
        {
            bool ret = false;
            int counterOdiagonal = 0;
            int counterXdiagonal = 0;
            int horizontalChekerO = 0;
            int horizontalChekerX = 0;
            int counterXvertical = 0;
            int counterOvertical = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (board[k, i] == "X")
                    {
                        counterXvertical++;
                        if (counterXvertical == 3)
                        {
                            ret = true;
                        }
                    }

                    if (board[k, i] == "O")
                    {
                        counterOvertical++;
                        if (counterOvertical == 3)
                        {
                            ret = true;
                        }
                    }

                }
                horizontalChekerO = 0;
                horizontalChekerX = 0;
                counterXvertical = 0;
                counterOvertical = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (i == j && board[i, j] == "X")
                    {
                        counterXdiagonal++;
                        if (counterXdiagonal == 3)
                        {
                            ret = true;
                        }
                    }
                    if (i == j && board[i, j] == "O")
                    {
                        counterOdiagonal++;
                        if (counterOdiagonal == 3) { ret = true; }
                    }
                    if (board[i, j] == "X")
                    {
                        horizontalChekerX++;
                        if (horizontalChekerX == 3)
                        {
                            ret = true;
                        }

                    }
                    if (board[i, j] == "O")
                    {
                        horizontalChekerO++;
                        if (horizontalChekerO == 3)
                        {
                            ret = true;
                        }

                    }

                }
            }
            return ret;
        }
        public static void display(string[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    Console.Write("|");
                    Console.Write(" " + board[i, k] + " ");
                    Console.Write("|");

                }
                Console.WriteLine();
                Console.WriteLine("------------------");
            }
        }
        public static void game()
        {
            string[,] board = {
            {"1","2","3" },
            {"4","5","6" },
            { "7","8","9"} };
            TicTacToe.display(board);

            while (!(TicTacToe.Cheker(board)))
            {
                Console.Clear();
                TicTacToe.display(board);
                Console.WriteLine("1 player choosing a field:  ");

                string field = input(board);


                chooseX(board, field);
                if (TicTacToe.Cheker(board))
                {
                    Console.WriteLine("1 payer WIN!!!!!!!!");

                    break;
                }
                Console.Clear();
                TicTacToe.display(board);
                Console.WriteLine("2 player choosing a field: ");
                field = input(board);
                TicTacToe.chooseO(board, field);
                if (TicTacToe.Cheker(board))
                {
                    Console.WriteLine("2 payer WIN!!!!!!!!");
                    break;
                }

            }
            display(board);

        }
        public static void chooseX(string[,] board, string x)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (board[i, k] == x)
                    {
                        board[i, k] = "X";
                        break;
                    }
                }
            }

        }
        public static void chooseO(string[,] board, string x)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (board[i, k] == x)
                    {
                        board[i, k] = "O";
                        break;
                    }
                }
            }

        }
        public static string input(string[,] board)
        {
            int liczba;
            bool loop = false;
            string s = "";
            while (true)
            {

                bool i = int.TryParse(Console.ReadLine(), out liczba);
                foreach (string elem in board)
                {
                    if (elem == liczba.ToString())
                    {
                        loop = true;

                    }

                }

                if ((liczba > 9 || liczba < 1) || !loop)
                { Console.WriteLine("bad field input, try again"); }

                else
                {
                    s = liczba.ToString();
                    return s;
                    break;
                }
            }
            return s;

        }
    }
}
