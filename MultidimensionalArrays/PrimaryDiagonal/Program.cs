using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeMatrix = int.Parse(Console.ReadLine());
            var matrix = new int[sizeMatrix, sizeMatrix];
            var sumDiagonal = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var inputArr = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = inputArr[cols];
                    if (rows == cols)
                    {
                        sumDiagonal += matrix[rows, cols];
                    }
                }
            }

            Console.WriteLine(sumDiagonal);
        }
    }
}