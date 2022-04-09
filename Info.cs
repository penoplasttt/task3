using static System.Console;

namespace game
{
    class Info
    {
        public static void inf(int count, string[] args)
        {
            
            WriteLine("\tW\t║\tL\t");
            
            for (int i = 0; i < count; i++)
            {
                
                WriteLine();
                Write($"{args[i],12}    ║");
                
                for (int j = 0; j < count; j++)
                {
                    if (Rules.Resulte(j, i, count) == 1)
                    {
                        Write($"{ args[j],11}    ");
                    }

                }

            }
            WriteLine();
        }
    }
}
