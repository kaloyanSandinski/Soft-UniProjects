using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixDimentions = int.Parse(Console.ReadLine());
            var matrix = new int[matrixDimentions, matrixDimentions];
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

            var inputComands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while (inputComands[0] != "END")
            {
                int row = int.Parse(inputComands[1]);
                int col = int.Parse(inputComands[2]);
                int value = int.Parse(inputComands[3]);
                if (row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1))
                {
                    if (inputComands[0] == "Add")
                    {
                        matrix[row, col] += value;
                    }
                    else
                    {
                        matrix[row, col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                inputComands = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
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