using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1501
{
    struct DataCalendaristica
    {
        public int zi;
        public int luna;
        public int an;
        public override string ToString()
        {
            return zi.ToString() + '-' + luna.ToString() + '-' + an.ToString();
        }
    }


    struct Student
    {
        public string nume;
        public DataCalendaristica dataNasterii;
        public Student(string nume, DataCalendaristica dn)
        {
            this.nume = nume;
            this.dataNasterii = dn;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            float g;
            // Tipuri de date:
            // byte, sbyte, short, ushort, int, uint, long, ulong;
            // float, double
            // decimal; 
            // char

            // Operatiile 
            // Aritmetici +, -, *, /, %; ++, --
            // Relationali <, >, <=, ==, != etc. 
            // Logici &&, ||, !

            // Instructiuni
            // if, for, while, do-while, switch, foreach


            // Functii

            // Tablouri: vectori, matrici

            int n1 = 97379;
            int n2 = 1010;

            //Console.WriteLine("cmmnr = {0}", cmmnr(n2));


            DateTime now = DateTime.Now;
            Console.WriteLine(now.Ticks);

            DateTime then = new DateTime(1918, 12, 1);


            TimeSpan diff = now.Subtract(then);

            Console.WriteLine(diff.Days);

            DataCalendaristica d1;

            d1.zi = 15;
            d1.luna = 1;
            d1.an = 2019;


            Console.WriteLine(d1);

            Student s1 = new Student("Eve", d1);

            Console.WriteLine(s1.dataNasterii.zi);

            // Cifrele unui numar;
            // Minime, maxime;
            // Cautare liniara, binara (binarySearch)
            // (vectori, matrici)
            // sortare: bubbleSort, Insertion Sort, Selection Sort, Merge Sort (interclasare)
            
            // recursivitate: 
            // Se da un sir de caractere care contine cifre separate prin spatii albe;
            // Se cere suma numerelor din sirul respectiv.
            // Ex. "113 45 678    234";

        }

        private static int cmmnr(int n1)
        {
            int nr = 0;

            int[] v = new int[10];
            
            // Generez vectorul de frecventa
            while (n1 > 0)
            {
                v[n1 % 10]++;
                n1 /= 10; // 
            }

            // Construiesc cel mai mic numar
            for (int i = 1; i < 10; i++)
            {
                for (int j = 0; j < v[i]; j++)
                {
                    nr = nr * 10 + i;
                    if(nr < 10)
                        for (int k = 0; k < v[0]; k++)
                        {
                            nr *= 10;
                        }
                }
            }

            return nr;
        }
    }
}
