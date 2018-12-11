using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursivitate
{
    class Program
    {
        // suma cifrelor unui numar

        static int SumaCifre(int n)
        {
            int c;
            int suma = 0;
            while (n > 0)
            {
                c = n % 10;
                suma += c;

                n = n / 10;
            }
            return suma;
        }

        static int SumaCifreR(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else
                return n % 10 + SumaCifreR(n / 10);
        }


        static int MaxC(int n)
        {
            int max = 0;

            int c;

            while (n > 0)
            {
                c = n % 10;

                if (c > max)
                {
                    max = c;
                }
                n = n / 10;
            }
            return max;
        }

        static int MaxCR(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else
                return Math.Max(n % 10, MaxCR(n / 10));
        }
        static void Main(string[] args)
        {
            //Console.WriteLine($"{SumaCifre(536)}"); ;
            //Console.WriteLine("Suma cifre {0} = {1}", 536, SumaCifreR(536));

            //Console.WriteLine("Cifra maxima: {0}", MaxC(536));
            //Console.WriteLine("Cifra maxima: {0}", MaxCR(536));

            int[] v1 = {5, 1, 4, 6 };
            int[] v2 = { 3, 2, 4, 0 };

            Array.Sort(v1);
            Array.Sort(v2);

            int[] v3;

            v3 = interclasare(v1, v2);

            Show(v3);


            // evaluarea unei expresii aritmetice.

            string exp = "1 + sin(45) + 2 * (3 - 6 / 2)";

        }

        private static int[] interclasare(int[] v1, int[] v2)
        {
            int[] r;

            r = new int[v1.Length + v2.Length];
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < v1.Length && j < v2.Length)
            {
                if (v1[i] < v2[j])
                {
                    r[k] = v1[i];
                    k++; i++;
                }
                else
                {
                    r[k] = v2[j];
                    k++; j++;
                }
            }

            while (i < v1.Length)
            {
                r[k] = v1[i];
                k++; i++;
            }

            while (j < v2.Length)
            {
                r[k] = v2[j];
                k++; j++;
            }
            return r;
        }

        private static void Show(int[] v3)
        {
            foreach (var item in v3)
            {
                Console.WriteLine(item);
            }
        }
    }
}
