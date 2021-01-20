using System;
using System.ComponentModel;
using System.Linq;

namespace SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputDimentions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new int[inputDimentions[0], inputDimentions[1]];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var inputArr = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = inputArr[cols];
                }
            }

            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                int currColSum = 0;
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    currColSum += matrix[rows,cols];
                }

                Console.WriteLine(currColSum);
            }
        }
    }
}