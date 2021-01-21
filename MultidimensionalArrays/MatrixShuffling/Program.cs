using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeMatrix = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new string[sizeMatrix[0], sizeMatrix[1]];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var inputArr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = inputArr[cols];
                }
            }

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while (command[0] != "END")
            {
                if (command.Length == 5)
                {
                    int row1 = int.Parse(command[1]);
                    int col1 = int.Parse(command[2]);
                    int row2 = int.Parse(command[3]);
                    int col2 = int.Parse(command[4]);

                    if (row1 >= 0 && col1 >= 0 && row2 >= 0 && col2 >= 0 && row1 <= matrix.GetLength(0) &&
                        row2 <= matrix.GetLength(0) && col1 <= matrix.GetLength(1) && col2 <= matrix.GetLength(1))
                    {
                        string firstElement = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = firstElement;
                        for (int rows = 0; rows < matrix.GetLength(0); rows++)
                        {
                            for (int cols = 0; cols < matrix.GetLength(1); cols++)
                            {
                                Console.Write($"{matrix[rows, cols]} ");
                            }

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }
        }
    }
}