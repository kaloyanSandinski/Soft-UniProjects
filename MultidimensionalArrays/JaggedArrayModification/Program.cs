using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixDimentions = int.Parse(Console.ReadLine());
            var matrix = new int[matrixDimentions][];
            for (int rows = 0; rows < matrix.Length; rows++)
            {
                var inputArr = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                matrix[rows] = inputArr;
            }

            var inputComands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while (inputComands[0] != "END")
            {
                int row = int.Parse(inputComands[1]);
                int col = int.Parse(inputComands[2]);
                int value = int.Parse(inputComands[3]);
                if (row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length)
                {
                    if (inputComands[0] == "Add")
                    {
                        matrix[row][col] += value;
                    }
                    else
                    {
                        matrix[row][col] -= value;
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

            foreach (var currArr in matrix)
            {
                Console.WriteLine(String.Join(" ", currArr));
            }
        }
    }
}