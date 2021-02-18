using System;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int rowSnake = 0;
            int colSnake = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = input[cols];
                    if (matrix[rows, cols] == 'S')
                    {
                        rowSnake = rows;
                        colSnake = cols;
                    }
                }
            }

            int foodCounter = 0;
            string command = String.Empty;
            while (foodCounter < 10)
            {
                command = Console.ReadLine();
                matrix[rowSnake, colSnake] = '.';
                if (command == "up")
                {
                    if (rowSnake - 1 >= 0)
                    {
                        rowSnake -= 1;
                        if (matrix[rowSnake, colSnake] == 'B')
                        {
                            matrix[rowSnake, colSnake] = '.';
                            List<int> position = Teleport(matrix, rowSnake, colSnake);
                            rowSnake = position[0];
                            colSnake = position[1];
                        }
                        else if (matrix[rowSnake, colSnake] == '*')
                        {
                            foodCounter++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Game over!");
                        break;
                    }
                }
                else if (command == "down")
                {
                    if (rowSnake + 1 < matrix.GetLength(0))
                    {
                        rowSnake += 1;
                        if (matrix[rowSnake, colSnake] == 'B')
                        {
                            matrix[rowSnake, colSnake] = '.';
                            List<int> position = Teleport(matrix, rowSnake, colSnake);
                            rowSnake = position[0];
                            colSnake = position[1];
                        }
                        else if (matrix[rowSnake, colSnake] == '*')
                        {
                            foodCounter++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Game over!");
                        break;
                    }
                }
                else if (command == "left")
                {
                    if (colSnake - 1 >= 0)
                    {
                        colSnake -= 1;
                        if (matrix[rowSnake, colSnake] == 'B')
                        {
                            matrix[rowSnake, colSnake] = '.';
                            List<int> position = Teleport(matrix, rowSnake, colSnake);
                            rowSnake = position[0];
                            colSnake = position[1];
                        }
                        else if (matrix[rowSnake, colSnake] == '*')
                        {
                            foodCounter++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Game over!");
                        break;
                    }
                }
                else
                {
                    if (colSnake + 1 < matrix.GetLength(1))
                    {
                        colSnake += 1;
                        if (matrix[rowSnake, colSnake] == 'B')
                        {
                            matrix[rowSnake, colSnake] = '.';
                            List<int> position = Teleport(matrix, rowSnake, colSnake);
                            rowSnake = position[0];
                            colSnake = position[1];
                        }
                        else if (matrix[rowSnake, colSnake] == '*')
                        {
                            foodCounter++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Game over!");
                        break;
                    }
                }

                matrix[rowSnake, colSnake] = 'S';
            }

            if (foodCounter == 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodCounter}");
            PrintMatrix(matrix);
        }

        public static List<int> Teleport(char[,] matrix, int rowPosition, int colPosition)
        {
            List<int> outputDimentions = new List<int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        outputDimentions.Add(row);
                        outputDimentions.Add(col);
                    }
                }
            }

            return outputDimentions;
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}