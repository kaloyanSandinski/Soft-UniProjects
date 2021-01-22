using System;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeMatrix = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var snake = Console.ReadLine();
            var matrix = new char[sizeMatrix[0], sizeMatrix[1]];
            int counter = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                if (rows % 2 == 0)
                {
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        if (counter >= snake.Length)
                        {
                            counter = 0;
                        }

                        matrix[rows, cols] = snake[counter];
                        counter++;
                    }
                }
                else
                {
                    for (int cols = matrix.GetLength(1) - 1; cols >= 0; cols--)
                    {
                        if (counter >= snake.Length)
                        {
                            counter = 0;
                        }

                        matrix[rows, cols] = snake[counter];
                        counter++;
                    }
                }
            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols]);
                }

                Console.WriteLine();
            }
        }
    }
}