using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basics
{
    internal class Program
    {
        public class matrix{
            public double[][] data;
            public int row, col;

            public matrix(int row_,int col_)
            {
                row = row_;
                col = col_;
                data = new double[row][];
                for(int i = 0; i < row; i++)
                {
                    data[i] = new double[col];
                }
            }
            public double GetValue(int row_,int col_)
            {
                if (row_ < row && col_ < col)
                {
                    return data[row_][col_];
                }
                return 0;
            }
            public void SetValue(int row_, int col_,double value)
            {
                if (row_ < row && col_ < col)
                {
                    data[row_][col_] = value;
                }
            }
            public void PrintMatrix()
            {
                for(int i = 0; i < row; i++)
                {
                    for(int j=0; j < col; j++)
                    {                        
                        Console.Write(GetValue(i,j)+" ");
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            string name = "Ben";
            int age = 22;
            Console.WriteLine("hello " + name + " i've heard you are " + age + " years old");
            int[] numbers = { 1, 2, 3, 4, 5 };
            for(int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            /*string input;
            Console.Write("state a number you want a factiorial of:");
            input=Console.ReadLine();
            int number=int.Parse(input);
            int value=1;
            for(int i = 1; i <=number ; i++)
            {
                value *= i;
            }
            Console.Write(value);*/

            matrix matrix1=new matrix(3,2);
            matrix1.SetValue(0, 0, 3);
            matrix1.SetValue(0, 1, 4);
            matrix1.SetValue(1, 0, 2);
            matrix1.SetValue(1, 1, 6);
            matrix1.SetValue(2, 0, 8);
            matrix1.SetValue(2, 1, 7);
            matrix1.PrintMatrix();


            Console.ReadLine();
        }
    }
}
