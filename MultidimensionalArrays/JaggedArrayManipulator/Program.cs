using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = int.Parse(Console.ReadLine());
            var matrix = new double[r][];
            for (int rows = 0; rows < matrix.Length; rows++)
            {
                var currArr = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                matrix[rows] = currArr;
            }

            for (int rows = 0; rows < matrix.Length - 1; rows++)
            {
                if (matrix[rows].Length == matrix[rows + 1].Length)
                {
                    matrix[rows] = matrix[rows].Select(x => x * 2).ToArray();
                    matrix[rows + 1] = matrix[rows + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[rows] = matrix[rows].Select(x => x / 2).ToArray();
                    matrix[rows + 1] = matrix[rows + 1].Select(x => x / 2).ToArray();
                }
            }

            var inputCmnd = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while (inputCmnd[0] != "End")
            {
                var currCmnd = inputCmnd[0];
                var currRow = int.Parse(inputCmnd[1]);
                var currCol = int.Parse(inputCmnd[2]);
                var value = int.Parse(inputCmnd[3]);

                if (currCmnd == "Add")
                {
                    if (matrix.Length > currRow && currRow >= 0 && matrix[currRow].Length > currCol && currCol >= 0)
                    {
                        matrix[currRow][currCol] += value;
                    }
                }
                else
                {
                    if (matrix.Length > currRow && currRow >= 0 && matrix[currRow].Length > currCol && currCol >= 0)
                    {
                        matrix[currRow][currCol] -= value;
                    }
                }

                inputCmnd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            foreach (var currArr in matrix)
            {
                Console.WriteLine(string.Join(" ", currArr));
            }
        }
    }
}