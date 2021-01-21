using System;
using System.Linq;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixDimentions = int.Parse(Console.ReadLine());
            var matrix = new char[matrixDimentions, matrixDimentions];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var inputArr = Console.ReadLine()
                    .ToString()
                    .ToCharArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] += inputArr[cols];
                }
            }

            var symbol = char.Parse(Console.ReadLine());
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] == symbol)
                    {
                        Console.WriteLine($"({rows}, {cols})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix ");
        }
    }
}