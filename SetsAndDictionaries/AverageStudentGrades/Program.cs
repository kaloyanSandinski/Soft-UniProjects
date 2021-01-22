using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsAmount = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentRecord = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < studentsAmount; i++)
            {
                var currStudent = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (studentRecord.ContainsKey(currStudent[0]))
                {
                    studentRecord[currStudent[0]].Add(decimal.Parse(currStudent[1]));
                }
                else
                {
                    studentRecord.Add(currStudent[0], new List<decimal>(){decimal.Parse(currStudent[1])});
                }
            }

            foreach (var currStudent in studentRecord)
            {
                Console.WriteLine($"{currStudent.Key} -> {string.Join(" ", currStudent.Value.Select(x=>x.ToString("F2")))} (avg: {currStudent.Value.Average():f2})");
            }
        }
    }
}