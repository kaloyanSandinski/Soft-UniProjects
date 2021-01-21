using System;
using System.Linq;

namespace TwoXTwoSquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeMatrix = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new char[sizeMatrix[0], sizeMatrix[1]];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var inputArr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = char.Parse(inputArr[cols]);
                }
            }

            int counterOfIdenticalSubMatrix = 0;
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {

                for (int cols = 0; cols < matrix.GetLength(1)-1; cols++)
                {
                    if (matrix[row, cols]==matrix[row, cols+1]&& matrix[row, cols+1]==matrix[row+1, cols]&& matrix[row+1,cols]==matrix[row+1, cols+1])
                    {
                        counterOfIdenticalSubMatrix++;
                    }
                }
            }

            Console.WriteLine(counterOfIdenticalSubMatrix);
        }
    }
}