using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part01
{
    
    class Program
    {
        static void AddOne(ref int number)
        {
            number += 1;
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Devide(int a, int b, out int result1, out int result2)
        {
            result1 = a / b;
            result2 = a % b;
        }

        static void GooGooPrint()
        {
            for(int i = 1; i<=9; ++i)
            {
                for(int j= 1; j<=9; ++j)
                {
                    Console.WriteLine(string.Format("{0} x {1} = {2}", i, j, (i * j)));
                }
                Console.WriteLine("===================================================");
            }
        }

        static void StarPrint()
        {
            int count = 1;
            while(count <= 5)
            {
                for (int i = 0; i < count; ++i)
                {
                    Console.Write("*");
                }

                Console.WriteLine();

                ++count;
            }
        }

        static int Factorial(int n)
        {
            int result = 1;

            for(int i = 1; i<=n; ++i)
            {
                result *= i;
            }

            return result;
        }

        static int Factorial2(int n)
        {
            if (n <= 1)
                return 1;

            return n * Factorial2(n - 1);
        }

        static void Main(string[] args)
        {
            //GooGooPrint();

            //StarPrint();

            //int result = Factorial(5);
            int result = Factorial2(5);
            Console.WriteLine(result);
        }
    }
}
