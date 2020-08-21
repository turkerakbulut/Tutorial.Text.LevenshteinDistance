using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Text.LevenshteinDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            string text1 = Console.ReadLine();
            string text2 = Console.ReadLine();

            int stepCount = LevenshteinDistance(text1, text2);

            Console.WriteLine("Steps Count:" + stepCount);

            Console.WriteLine("Similarity: %" +100 * (1.0 - (stepCount / (double)Math.Max(text1.Length, text2.Length))));

            Console.Read();
        }

        private static int LevenshteinDistance(string text1, string text2)
        {
            int t1 = text1.Length;
            int t2 = text2.Length;

            int[,] table = new int[t1 + 1, t2 + 1];
           
            for (int i = 0; i <= t1; table[i, 0] = i++) ;
           
            for (int j = 0; j <= t2; table[0, j] = j++) ;

            for (int i = 1; i <= t1; i++)
            {
                for (int j = 1; j <= t2; j++)
                {
                    int step;

                    if (text2[j - 1] == text1[i - 1])
                        step = 0;
                    else
                        step = 1;

                    table[i, j] = Math.Min(Math.Min(table[i - 1, j] + 1, table[i, j - 1] + 1), table[i - 1, j - 1] + step);
                }
            }

            return table[t1,t2];
        }
    }
}
