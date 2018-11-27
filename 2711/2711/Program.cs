using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2711
{
    // Bin packing
    class Program
    {
        static void Main(string[] args)
        {
            int[] w = {3, 6, 2, 1, 5, 7, 2, 4, 1, 9};
            int C = 10;
            int k;
            k = NF(w, C);
            Console.WriteLine("NF = {0}", k);

            k = FF(w, C);
            Console.WriteLine("FF = {0}", k);

            k = BF(w, C);
            Console.WriteLine("BF = {0}", k);

            k = WF(w, C);
            Console.WriteLine("WF = {0}", k);

            IComparer<int> descComp = new DescComparer<int>();

            Array.Sort(w, descComp);

            k = NF(w, C);
            Console.WriteLine("NFD = {0}", k);

            k = FF(w, C);
            Console.WriteLine("FFD = {0}", k);

            k = BF(w, C);
            Console.WriteLine("BFD = {0}", k);

            k = WF(w, C);
            Console.WriteLine("WFD = {0}", k);

        }

        

        private static int WF(int[] w, int c)
        {
            if (w.Length == 0)
            {
                return 0;
            }

            int k = 1;
            int[] bins;
            int j;
            bins = new int[w.Length];
            int min = 0;
            int index = 0;
            for (int i = 0; i < w.Length; i++)
            {
                min = int.MaxValue; index = -1;
                for (j = 0; j < k; j++)
                {
                    if (bins[j] + w[i] <= c)
                    {
                        if (bins[j] + w[i] < min)
                        {
                            index = j;
                            min = bins[j] + w[i];
                        }
                    }
                }
                if (index == -1)
                {
                    bins[k] = w[i];
                    k++;
                }
                else
                {
                    bins[index] += w[i];
                }
            }
            
            return k;
        }

        private static int BF(int[] w, int c)
        {
            if (w.Length == 0)
            {
                return 0;
            }

            int k = 1;
            int[] bins;
            int j;
            bins = new int[w.Length];
            int max = 0;
            int index = 0;
            for (int i = 0; i < w.Length; i++)
            {
                max = 0; index = -1;
                for (j = 0; j < k; j++)
                {
                    if (bins[j] + w[i] <= c)
                    {
                        if (bins[j] + w[i] > max)
                        {
                            index = j;
                            max = bins[j] + w[i];
                        }
                    }
                }
                if(index == -1)
                {
                    bins[k] = w[i];
                    k++;
                }
                else
                {
                    bins[index] += w[i];
                }
            }
            
            return k;
        }

        private static int FF(int[] w, int c)
        {
            if (w.Length == 0)
            {
                return 0;
            }

            int k = 1;
            int[] bins;
            int j;
            bins = new int[w.Length];
            for (int i = 0; i < w.Length; i++)
            {
                for (j = 0; j < k; j++)
                {
                    if (bins[j] + w[i] <= c)
                    {
                        bins[j] += w[i];
                        break;
                    }
                }
                if (j == k)
                {
                    bins[k] = w[i];
                    k++;
                }
            }
            return k;
        }

        private static int NF(int[] w, int c)
        {
            int k = 1;
            int current = 0;


            if (w.Length == 0)
            {
                return 0;
            }
            for (int i = 0; i < w.Length; i++)
            {
                if (w[i] + current <= c)
                {
                    current += w[i];
                }
                else
                {
                    k++;
                    current = w[i];
                }
            }
            return k;
        }
    }
}
