using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1812
{
    class Program
    {
        static void Main(string[] args)
        {
            // Matrici

            int[,] matrix;


            matrix = ReadMatrix("input.txt");

            PrintMatrix(matrix);



            // Suma maximelor de pe fiecare linie (daca maximul se repeta pe o linie atunci se aduna o singura data);
            int suma;
            suma = SumaMaxime(matrix);
            Console.WriteLine("Suma maximelor de pe linie este {0}", suma);


            // Interschimbam liniile a.i. sumele de pe fiecare linie sa fie in ordine crescatoare
            SortByLineSum(matrix);
            PrintMatrix(matrix);

            // Afisati elementele matrcii parcurgand-o in spirala. 
            // TODO;


            // Matrici patratice (nr linii === nr coloane)
            Console.WriteLine();
            int[,] matrix2;


            matrix2 = ReadMatrix("input2.txt");
            PrintMatrix(matrix2);


            // Inmultirea a 2 matrici;
            int[,] matrix3;

            matrix3 = Product(matrix, matrix2);

            PrintMatrix(matrix3);

            // Suma elementelor de pe diagonala principala
            Console.WriteLine("Suma elementelor de pe diagonala principala: {0}", SumDiag(matrix2));

            // suma elementelor de pe diagonala secundara
            Console.WriteLine("Suma elementelor de pe diagonala secundara: {0}", SumDiag2(matrix2));


            // suma elementelor de deasupra diagonalei secundare

            //suma elementelor de sub diagonala secundara

            //suma elementelor de deasupra diagonalei principale;

            // suma elementeor de sub diagonala principala.

            //suma elementelor de pe o banda de dimensiune k a diagonalei principale.

            //suma elementelor din sectorul S, N, V,E
        }

        private static int SumDiag2(int[,] matrix2)
        {
            int sum = 0;



            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                sum += matrix2[i, matrix2.GetLength(0) - i - 1];
            }

            return sum;
        }

        private static int SumDiag(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }
            return sum;
        }

        private static int[,] Product(int[,] matrix1, int[,] matrix2)
        {
            int[,] result;
            result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    int suma = 0;
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        suma += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = suma;
                }
            }


            return result;
        }

        private static void SortByLineSum(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    if (LineSum(matrix, i) > LineSum(matrix, j))
                        SwapLines(matrix, i, j);
                }
            }
        }

        private static void SwapLines(int[,] matrix, int i, int j)
        {
            int aux;
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                aux = matrix[i, k];
                matrix[i, k] = matrix[j, k];
                matrix[j, k] = aux;
            }
        }

        private static int LineSum(int[,] matrix, int i)
        {
            int sum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[i, j];
            }
            return sum;
        }

        private static int SumaMaxime(int[,] matrix)
        {
            int suma = 0;
            int maxim;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                maxim = matrix[i, 0];
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxim)
                    {
                        maxim = matrix[i, j];
                    }
                }
                suma += maxim;
            }

            return suma;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static int[,] ReadMatrix(string fileName)
        {
            int linii, coloane;

            StreamReader sr = new StreamReader(fileName);

            string line;

            line = sr.ReadLine();
            char[] sep = {' ', '\t'};
            string[] tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            linii = int.Parse(tokens[0]);
            coloane = int.Parse(tokens[1]);

            int[,] matrix = new int[linii, coloane];


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                line = sr.ReadLine();
                tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(tokens[j]);
                }
            }
            return matrix;
        }
    }
}
