using System;
using static System.Console;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            Key rng = new Key();
            HMAC hashGen = new HMAC();
            Rules winner = new Rules();
            Info info = new Info();

            if (args.Length < 3 || args.Length % 2 == 0)
            {
                WriteLine("Please specify a number of unique moves that is more than 3 and is an odd number");
            }
            else
            {
                byte[] key = Key.GenKey();
                int ChoiseComp = GenChoise(args);
                byte[] hmac = HMAC.ComputeHmacsha3(System.Text.Encoding.UTF8.GetBytes(args[ChoiseComp]), key);
                WriteLine($"HMAC: {Convert.ToBase64String(hmac)}");

                int plchoice = -99;
                while (plchoice == -99)
                {
                    PRNTMoves(args);
                    string move = ReadLine();
                    if (move == "?")
                    {
                        Info.inf(args.Length, args);
                    }
                    else if (char.IsDigit(move[0]) && Convert.ToInt32(move) >= 0 && Convert.ToInt32(move) <= args.Length)
                    {
                        plchoice = Convert.ToInt32(move);
                    }
                }
                if (plchoice == 0)
                {
                    Environment.Exit(0);
                }
                plchoice -= 1;
                WriteLine($"your move: {args[plchoice]}");
                WriteLine($"Computer move: {args[ChoiseComp]}");
                int res = Rules.Resulte(ChoiseComp, plchoice, args.Length);
                if (res == 0)
                    WriteLine("You Lose!");
                else if (res == 1)
                    WriteLine("You Win!");
                else
                    WriteLine("Draw!");
                WriteLine($"HMAC key: {Convert.ToBase64String(key)}");

            }
        }
        static int GenChoise(string[] args)
        {
            Random rnd = new Random();
            return rnd.Next(0, args.Length);

        }
        static void PRNTMoves(string[] args)
        {
            WriteLine("Available moves:");
            for (int i = 0; i < args.Length; i++)
            {
                WriteLine($"{i + 1} - {args[i]}");

            }
            WriteLine("0 - exit");
            WriteLine("? - help");
            WriteLine("Enter your move: ");
        }
    }
}
