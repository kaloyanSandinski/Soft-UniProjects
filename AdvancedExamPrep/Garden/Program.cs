using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixDimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var matrix = new int[matrixDimensions[0], matrixDimensions[1]];
            for (int rows = 0; rows < matrixDimensions[0]; rows++)
            {
                for (int cols = 0; cols < matrixDimensions[1]; cols++)
                {
                    matrix[rows, cols] = 0;
                }
            }

            string inputCommand = Console.ReadLine();
            while (inputCommand != "Bloom Bloom Plow")
            {
                var dimensions = inputCommand
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int row = dimensions[0];
                int col = dimensions[1];
                if (matrix.GetLength(0) > row && matrix.GetLength(1) > col && row >= 0 && col >= 0)
                {
                    if (matrix[row, col] == 0)
                    {
                        for (int rows = 0; rows < matrix.GetLength(0); rows++)
                        {
                            for (int cols = 0; cols < matrix.GetLength(1); cols++)
                            {
                                if (rows == row)
                                {
                                    matrix[rows, cols] += 1;
                                }
                                else
                                {
                                    if (cols == col)
                                    {
                                        matrix[rows, cols] += 1;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                inputCommand = Console.ReadLine();
            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write($"{matrix[rows, cols]} ");
                }

                Console.WriteLine();
            }
        }
    }
}