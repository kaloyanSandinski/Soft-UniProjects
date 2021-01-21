using System;
using System.Linq;

namespace SquareWithMaximumSum
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
                var currArr = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = currArr[cols];
                }
            }

            var biggestSubMatrixSum = 0;
            var maxSubRow = 0;
            var maxSubCol = 0;
            for (int rows = 0; rows < matrix.GetLength(0)-1; rows++)
            {
                var currSubMatrixSum = 0;
                for (int cols = 0; cols < matrix.GetLength(1)-1; cols++)
                {
                    currSubMatrixSum += matrix[rows, cols];
                    currSubMatrixSum += matrix[rows + 1, cols];
                    currSubMatrixSum += matrix[rows, cols + 1];
                    currSubMatrixSum += matrix[rows + 1, cols + 1];
                    if (currSubMatrixSum>biggestSubMatrixSum)
                    {
                        biggestSubMatrixSum = currSubMatrixSum;
                        maxSubRow = rows;
                        maxSubCol = cols;
                    }

                    currSubMatrixSum = 0;
                }
            }

            Console.WriteLine($"{matrix[maxSubRow,maxSubCol]} {matrix[maxSubRow,maxSubCol+1]}");
            Console.WriteLine($"{matrix[maxSubRow+1,maxSubCol]} {matrix[maxSubRow+1, maxSubCol+1]}");
            Console.WriteLine(biggestSubMatrixSum);
        }
    }
}