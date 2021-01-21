using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            var matrix = new int[sizeMatrix, sizeMatrix];
            int primrarySum = 0;
            int secondarySum = 0;
            int counter = 1;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var inputArr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = inputArr[cols];
                    if (rows == cols)
                    {
                        primrarySum += matrix[rows, cols];
                    }

                    if (cols == matrix.GetLength(1) - counter)
                    {
                        secondarySum += matrix[rows, cols];
                    }
                }

                counter++;
            }

            Console.WriteLine(Math.Abs(primrarySum-secondarySum));
        }
    }
}