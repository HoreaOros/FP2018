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

            Console.WriteLine("Matricea este: ");
            PrintMatrix(matrix);

            // Suma maximelor de pe fiecare linie (daca maximul se repeta pe o linie atunci se aduna o singura data);
            int suma;
            suma = SumaMaxime(matrix);
            Console.WriteLine("Suma maximelor de pe linie este {0}", suma);

            // Interschimbam liniile a.i. sumele de pe fiecare linie sa fie in ordine crescatoare
            Console.WriteLine("Interschimbam liniile a.i. sumele de pe fiecare linie sa fie in ordine crescatoare: ");
            SortByLineSum(matrix);
            PrintMatrix(matrix);

            // Afisati elementele matrcii parcurgand-o in spirala. 
            // TODO;
            Console.Write("Parcurgerea in spirala: ");
            PrintSpiral(matrix);

            // Matrici patratice (nr linii === nr coloane)
            Console.WriteLine();
            int[,] matrix2;

            matrix2 = ReadMatrix("input2.txt");

            Console.WriteLine("Matricea patratica este: ");
            PrintMatrix(matrix2);

            // Inmultirea a 2 matrici;
            int[,] matrix3;

            if (matrix.GetLength(1) == matrix2.GetLength(0))
            {
                matrix3 = Product(matrix, matrix2);
                Console.WriteLine("Inmultirea celor 2 matrici: ");
                PrintMatrix(matrix3);
            }
            else
            {
                Console.WriteLine("Cele doua matrice nu se pot inmulti deoarece numarul de coloane a primei matrice este diferit de numarul de linii a celei de-a doua matrice");
            }

            // Suma elementelor de pe diagonala principala
            Console.WriteLine("Suma elementelor de pe diagonala principala: {0}", SumDiag(matrix2));

            // Suma elementelor de pe diagonala secundara
            Console.WriteLine("Suma elementelor de pe diagonala secundara: {0}", SumDiag2(matrix2));

            // Suma elementelor de deasupra diagonalei secundare
            Console.WriteLine("Suma elementelor de deasupra diagonalei secundare: {0}", SumAboveSecondaryDiag(matrix2));

            // Suma elementelor de sub diagonala secundara
            Console.WriteLine("Suma elementelor de sub diagonala secundara: {0}", SumBelowSecondaryDiag(matrix2));

            // Suma elementelor de deasupra diagonalei principale;
            Console.WriteLine("Suma elementelor de deasupra diagonalei principale: {0}", SumAboveMainDiag(matrix2));

            // Suma elementeor de sub diagonala principala.
            Console.WriteLine("Suma elementelor de sub diagonala principala: {0}", SumBelowMainDiag(matrix2));

            // Suma elementelor de pe o banda de dimensiune k a diagonalei principale.
            int k = -1;

            do
            {
                Console.Write("Suma elementelor de pe o banda de dimensiune k a diagonalei principale. Dati k (k >= 0 && k <= {0}) ", matrix2.GetLength(0) - 1);
                k = int.Parse(Console.ReadLine());
            } while (k < 0 || k >= matrix2.GetLength(0));
            
            Console.WriteLine("Suma elementelor de pe banda de dimensiunea {0}: {1}", k, SumaBanda(matrix2, k));

            // Suma elementelor din sectorul S, N, V, E
            SumZone(matrix2);
        }

        private static void SumZone(int[,] matrix2)
        {
            int length = matrix2.GetLength(0);
            int sumN = 0;
            int sumE = 0;
            int sumS = 0;
            int sumW = 0;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i < j && i < length - 1 - j) // North zone
                        sumN += matrix2[i, j];
                    else if (i < j && i > length - 1 - j) // East zone
                        sumE += matrix2[i, j];
                    else if (i > j && i > length - 1 - j) // South zone
                        sumS += matrix2[i, j];
                    else if (i > j && i < length - 1 - j) // West zone
                        sumW += matrix2[i, j];
                }
            }

            Console.WriteLine("Suma din zona nordica este: {0}", sumN);
            Console.WriteLine("Suma din zona estica este: {0}", sumE);
            Console.WriteLine("Suma din zona sudica este: {0}", sumS);
            Console.WriteLine("Suma din zona vestica este: {0}", sumW);
        }

        private static int SumaBanda(int[,] matrix2, int k)
        {
            int length = matrix2.GetLength(0);
            int sum = 0;
            int p = 0;
            int i, j;

            while (p < k + 1)
            {
                i = p;
                if (i == 0)
                    for (j = 0; j < length; j++)
                        sum += matrix2[j, j];
                else
                {
                    j = 0;
                    while (i < length)
                    {
                        sum += matrix2[i, j] + matrix2[j, i];
                        i++;
                        j++;
                    }
                }

                p++;
            }

            return sum;
        }

        private static int SumBelowMainDiag(int[,] matrix2)
        {
            int length = matrix2.GetLength(0);
            int sum = 0;

            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    if (i > j)
                        sum += matrix2[i, j];

            return sum;
        }

        private static int SumAboveMainDiag(int[,] matrix2)
        {
            int length = matrix2.GetLength(0);
            int sum = 0;

            for (int i = 0; i < matrix2.GetLength(0); i++)
                for (int j = 0; j < matrix2.GetLength(0); j++)
                    if (i < j)
                        sum += matrix2[i, j];

            return sum;
        }

        private static int SumBelowSecondaryDiag(int[,] matrix2)
        {
            int length = matrix2.GetLength(0);
            int sum = 0;

            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    if (i + j >= length)
                        sum += matrix2[i, j];

            return sum;
        }

        private static int SumAboveSecondaryDiag(int[,] matrix2)
        {
            int length = matrix2.GetLength(0);
            int sum = 0;

            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    if (i + j < length - 1)
                        sum += matrix2[i, j];

            return sum;
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

        private static void PrintSpiral(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int i, j = 0, k = 0;

            while (j < rows && k < cols)
            {
                for (i = k; i < cols; i++)
                    Console.Write(matrix[j, i] + " ");
                j++;

                for (i = j; i < rows; i++)
                    Console.Write(matrix[i, cols - 1] + " ");
                cols--;

                if (j < rows)
                {
                    for (i = cols - 1; i >= k; i--)
                        Console.Write(matrix[rows - 1, i] + " ");
                    rows--;
                }

                if (k < cols)
                {
                    for (i = rows - 1; i >= j; i--)
                        Console.Write(matrix[i, k] + " ");
                    k++;
                }
            }

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
