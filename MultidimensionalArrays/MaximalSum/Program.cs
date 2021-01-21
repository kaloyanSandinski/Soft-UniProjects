using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeMatrix = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new int[sizeMatrix[0], sizeMatrix[1]];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var inputArr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = inputArr[cols];
                }
            }

            int biggestSubMatrixSum = 0;
            int startRowSubMatrix = 0;
            int startColSubMatrix = 0;
            for (int rows = 0; rows < matrix.GetLength(0)-2; rows++)
            {
                int currSubMatrixSum = 0;
                for (int cols = 0; cols < matrix.GetLength(1)-2; cols++)
                {
                    for (int subRows = rows; subRows < rows+3; subRows++)
                    {
                        for (int subCols = cols; subCols < cols+3; subCols++)
                        {
                            currSubMatrixSum += matrix[subRows, subCols];
                            if (currSubMatrixSum>biggestSubMatrixSum)
                            {
                                biggestSubMatrixSum = currSubMatrixSum;
                                startRowSubMatrix = rows;
                                startColSubMatrix = cols;
                            }
                        }
                    }
                    
                    currSubMatrixSum = 0;
                }
            }

            Console.WriteLine($"Sum = {biggestSubMatrixSum}");
            Console.WriteLine($"{matrix[startRowSubMatrix, startColSubMatrix]} {matrix[startRowSubMatrix, startColSubMatrix+1]} {matrix[startRowSubMatrix, startColSubMatrix+2]}");
            Console.WriteLine($"{matrix[startRowSubMatrix+1, startColSubMatrix]} {matrix[startRowSubMatrix+1, startColSubMatrix+1]} {matrix[startRowSubMatrix+1, startColSubMatrix+2]}");
            Console.WriteLine($"{matrix[startRowSubMatrix+2, startColSubMatrix]} {matrix[startRowSubMatrix+2, startColSubMatrix+1]} {matrix[startRowSubMatrix+2, startColSubMatrix+2]}");
        }
    }
}