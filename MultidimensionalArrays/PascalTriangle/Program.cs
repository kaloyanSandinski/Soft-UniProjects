using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int currLength = 1;
            var triangle = new long[rows][];
            for (int i = 0; i < triangle.Length; i++)
            {
                triangle[i] = new long[currLength];
                triangle[i][0] = 1;
                triangle[i][currLength - 1] = 1;
                if (currLength>2)
                {
                    for (int j = 1; j < currLength-1; j++)
                    {
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                    }
                }
                
                currLength++;
            }

            foreach (var row in triangle)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}