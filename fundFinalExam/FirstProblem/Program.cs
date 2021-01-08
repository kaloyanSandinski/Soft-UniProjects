using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstProblem
{
    class FirstProgram
    {
        static void Main(string[] args)
        {
            string wantedEmail = Console.ReadLine();
            string inputCommands = Console.ReadLine();
            while (inputCommands != "Complete")
            {
                string[] inputData = inputCommands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string currCommand = inputData[0];
                if (currCommand == "Make")
                {
                    string secondCommand = inputData[1];
                    if (secondCommand == "Upper")
                    {
                        wantedEmail = wantedEmail.ToUpper();
                    }
                    else
                    {
                        wantedEmail = wantedEmail.ToLower();
                    }

                    Console.WriteLine(wantedEmail);
                }
                else if (currCommand == "GetDomain")
                {
                    int count = int.Parse(inputData[1]);
                    string lastCharacters = string.Empty;
                    for (int i = wantedEmail.Length - count; i < wantedEmail.Length; i++)
                    {
                        lastCharacters += wantedEmail[i];
                    }

                    Console.WriteLine(lastCharacters);
                }
                else if (currCommand == "GetUsername")
                {
                    string output = string.Empty;
                    if (wantedEmail.Contains('@'))
                    {
                        int endIndex = wantedEmail.IndexOf("@");
                        int count = endIndex;
                        output = wantedEmail.Substring(0, count);
                        Console.WriteLine(output);
                    }
                    else
                    {
                        Console.WriteLine($"The email {wantedEmail} doesn't contain the @ symbol.");
                    }
                }
                else if (currCommand == "Replace")
                {
                    char inputCh = Char.Parse(inputData[1]);
                    wantedEmail = wantedEmail.Replace(inputCh, '-');
                    Console.WriteLine(wantedEmail);
                }
                else if (currCommand == "Encrypt")
                {
                    List<int> outputData = new List<int>();
                    foreach (var character in wantedEmail)
                    {
                        outputData.Add((int) character);
                    }

                    Console.WriteLine(string.Join(" ", outputData));
                }

                inputCommands = Console.ReadLine();
            }
        }
    }
}