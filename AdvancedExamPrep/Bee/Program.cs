using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int rowStartPosition = 0;
            int colStartPosition = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'B')
                    {
                        rowStartPosition = row;
                        colStartPosition = col;
                    }
                }
            }
            string command = Console.ReadLine();
            int pollinateFlowers = 0;
            while (command != "End")
            {
                if (command == "down" && rowStartPosition + 1 < matrix.GetLength(0))
                {
                    matrix[rowStartPosition, colStartPosition] = '.';
                    rowStartPosition++;
                    if (matrix[rowStartPosition, colStartPosition] == 'O')
                    {
                        matrix[rowStartPosition, colStartPosition] = '.';
                        rowStartPosition++;
                        if (matrix[rowStartPosition, colStartPosition] == 'f')
                        {
                            pollinateFlowers++;
                        }
                    }
                    else if (matrix[rowStartPosition, colStartPosition] == 'f')
                    {
                        matrix[rowStartPosition, colStartPosition] = 'B';
                        pollinateFlowers++;
                    }

                    matrix[rowStartPosition, colStartPosition] = 'B';
                }
                else if (command == "up" && rowStartPosition - 1 >= 0)
                {
                    matrix[rowStartPosition, colStartPosition] = '.';
                    rowStartPosition--;
                    if (matrix[rowStartPosition, colStartPosition] == 'O')
                    {
                        matrix[rowStartPosition, colStartPosition] = '.';
                        rowStartPosition--;
                        if (matrix[rowStartPosition, colStartPosition] == 'f')
                        {
                            matrix[rowStartPosition, colStartPosition] = 'B';
                            pollinateFlowers++;
                        }
                    }
                    else if (matrix[rowStartPosition, colStartPosition] == 'f')
                    {
                        matrix[rowStartPosition, colStartPosition] = 'B';
                        pollinateFlowers++;
                    }

                    matrix[rowStartPosition, colStartPosition] = 'B';
                }
                else if (command == "right" && colStartPosition + 1 < matrix.GetLength(1))
                {
                    matrix[rowStartPosition, colStartPosition] = '.';
                    colStartPosition++;
                    if (matrix[rowStartPosition, colStartPosition] == 'O')
                    {
                        matrix[rowStartPosition, colStartPosition] = '.';
                        colStartPosition++;
                        if (matrix[rowStartPosition, colStartPosition] == 'f')
                        {
                            pollinateFlowers++;
                        }
                    }
                    else if (matrix[rowStartPosition, colStartPosition] == 'f')
                    {
                        matrix[rowStartPosition, colStartPosition] = 'B';
                        pollinateFlowers++;
                    }

                    matrix[rowStartPosition, colStartPosition] = 'B';
                }
                else if (command == "left" && colStartPosition - 1 >= 0)
                {
                    matrix[rowStartPosition, colStartPosition] = '.';
                    colStartPosition--;
                    if (matrix[rowStartPosition, colStartPosition] == 'O')
                    {
                        matrix[rowStartPosition, colStartPosition] = '.';
                        colStartPosition--;
                        if (matrix[rowStartPosition, colStartPosition] == 'f')
                        {
                            pollinateFlowers++;
                        }
                    }
                    else if (matrix[rowStartPosition, colStartPosition] == 'f')
                    {
                        matrix[rowStartPosition, colStartPosition] = 'B';
                        pollinateFlowers++;
                    }

                    matrix[rowStartPosition, colStartPosition] = 'B';
                }
                else
                {
                    matrix[rowStartPosition, colStartPosition] = '.';
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                command = Console.ReadLine();
            }

            if (pollinateFlowers<5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-pollinateFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinateFlowers} flowers!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }
        }
    }
}