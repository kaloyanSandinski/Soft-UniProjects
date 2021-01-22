using System;
using System.Dynamic;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            var matrix = new char[sizeMatrix, sizeMatrix];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var inputArr = Console.ReadLine().ToCharArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = inputArr[cols];
                }
            }

            int counter = 0;
            while (true)
            {
                int maxAttack = 0;
                int maxRowIndex = 0;
                int maxColIndex = 0;
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    int currMaxAttack = 0;
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        char ch = matrix[rows, cols];
                        if (ch == 'K')
                        {
                            currMaxAttack = GetMaxAttacking(matrix, rows, cols);
                            if (currMaxAttack>maxAttack)
                            {
                                maxAttack = currMaxAttack;
                                maxRowIndex = rows;
                                maxColIndex = cols;
                            }
                        }
                    }
                }

                if (maxAttack==0)
                {
                    break;
                }
                else
                {
                    matrix[maxRowIndex, maxColIndex] = 'O';
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }

        private static int GetMaxAttacking(char[,] matrix, int rows, int cols)
        {
            int matrixColsLenght = matrix.GetLength(1);
            int matrixRowsLenght = matrix.GetLength(0);
            int counter = 0;
            //up

            if (rows - 2 >= 0 && cols - 1 >= 0 && matrix[rows - 2, cols - 1] == 'K')
            {
                counter++;
            }

            if (rows - 2 >= 0 && cols + 1 < matrixColsLenght && matrix[rows - 2, cols + 1] == 'K')
            {
                counter++;
            }

            if (rows - 1 >= 0 && cols - 2 >= 0 && matrix[rows - 1, cols - 2] == 'K')
            {
                counter++;
            }

            if (rows - 1 >= 0 && cols + 2 < matrixColsLenght && matrix[rows - 1, cols + 2] == 'K')
            {
                counter++;
            }
            //down

            if (rows + 2 < matrixRowsLenght && cols - 1 >= 0 && matrix[rows + 2, cols - 1] == 'K')
            {
                counter++;
            }

            if (rows + 2 < matrixRowsLenght && cols + 1 < matrixColsLenght && matrix[rows + 2, cols + 1] == 'K')
            {
                counter++;
            }

            if (rows + 1 < matrixRowsLenght && cols - 2 >= 0 && matrix[rows + 1, cols - 2]=='K')
            {
                counter++;
            }

            if (rows+1<matrixRowsLenght&&cols+2<matrixColsLenght&&matrix[rows+1, cols+2]=='K')
            {
                counter++;
            }

            return counter;
        }
    }
}