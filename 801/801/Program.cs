using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _801
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prefix 1. 
            // Se dau doua numere a si b. 
            // Se cere sa se determine prefixul lor comun
            // Ex. a = 12345 si b  este 12356. Prefix 123;
            // Ex. a = 123 si b = 234. Prefix 0.
            int a = 12345;
            int b = 12356;

            Console.WriteLine("Prefix comun pentru {0} si {1} este: {2}", a, b, PrefixComun(a, b));
            Console.WriteLine("Prefix comun pentru {0} si {1} este: {2}", a, b, PrefixComun(123, 234));

            //Console.WriteLine("Prefix comun pentru {0} si {1} este: {2}", a, b, PrefixComun2(a, b));

            // Se da o matrice de numere naturale cu m linii si m coloane.
            // Se cere sa se determine o lista cu cifrele de control 
            // ale elementelor matricii. 
            // Cifra de control: 182 => 1+8+2 == 11 => 1+1 = 2;

            int linii, coloane;

            string line;

            linii = int.Parse(Console.ReadLine());
            coloane = int.Parse(Console.ReadLine());

            int[,] mat;

            mat = ReadMatrix(linii, coloane);

            PrintMatrix(mat);

            int[] cc = new int[10];

            ComputeCC(mat, cc);

            Console.WriteLine("Cifrele de control ale elementelor matricii:");
            for (int i = 0; i < cc.Length; i++)
            {
                if (cc[i] != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static void ComputeCC(int[,] mat, int[] cc)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    cc[CifraControl(mat[i, j])] = 1;
                }
            }
        }

        private static int CifraControl(int v)
        {

            while (v > 9)
            {
                v = SumaCifre(v);
            }
            return v;
        }

        private static int SumaCifre(int v)
        {
            int suma = 0;
            while (v > 0)
            {
                suma += v % 10;
                v = v / 10;
            }
            return suma;
        }

        private static void PrintMatrix(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write("{0} ", mat[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static int[,] ReadMatrix(int linii, int coloane)
        {
            int[,] matrix = new int[linii, coloane];

            string line;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                line = Console.ReadLine();
                string[] elems = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(elems[j]);    

                }
            }



            return matrix;
        }

        /// <summary>
        ///  ??????
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static object PrefixComun2(int a, int b)
        {
            int result = 0;

            while(FirstDigit(a) == FirstDigit(b))
            {
                result = result * 10 + FirstDigit(a);
                a = RemoveFirstDigit(a);
                b = RemoveFirstDigit(b);
            }


            return result;
        }

        private static int RemoveFirstDigit(int a)
        {
            throw new NotImplementedException();
        }

        private static int FirstDigit(int a)
        {
            while (a > 9)
            {
                a = a / 10;
            }
            return a;
        }

        private static int PrefixComun(int a, int b)
        {
            string sa, sb;

            sa = a.ToString();
            sb = b.ToString();

            int i = 0;
            // 12345 , 12356;
            while (i < sa.Length && i < sb.Length && sa[i] == sb[i])
            {
                i++;
            }
            string result = sa.Substring(0, i);
            if (result == "")
            {
                return 0;
            }
            return Convert.ToInt32(result);
        }
    }
}
