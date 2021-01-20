using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputDimentions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = inputDimentions[0];
            int cols = inputDimentions[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputArr = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputArr[col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            int sum = 0;
            foreach (var element in matrix)
            {
                sum += element;
            }

            Console.WriteLine(sum);
        }
    }
}