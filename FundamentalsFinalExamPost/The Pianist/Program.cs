using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;

namespace The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> inputData = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("|")
                    .ToArray();
                inputData.Add(input[0], new List<string>());
                inputData[input[0]].Add(input[1]);
                inputData[input[0]].Add(input[2]);
            }

            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] inputCommands = command.Split("|")
                    .ToArray();
                string currComand = inputCommands[0];
                string piece = inputCommands[1];
                if (currComand == "Add")
                {
                    if (inputData.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        string composer = inputCommands[2];
                        string key = inputCommands[3];
                        inputData.Add(piece, new List<string>());
                        inputData[piece].Add(composer);
                        inputData[piece].Add(key);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (currComand == "Remove")
                {
                    if (inputData.ContainsKey(piece))
                    {
                        inputData.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (currComand == "ChangeKey")
                {
                    string newKey = inputCommands[2];
                    if (inputData.ContainsKey(piece))
                    {
                        inputData[piece][1] = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                command = Console.ReadLine();
            }

            inputData = inputData
                .OrderBy(x => x.Key)
                .ThenBy(x => x.Value[0])
                .ToDictionary(a => a.Key, a => a.Value);
            foreach (var currpiece in inputData)
            {
                Console.WriteLine($"{currpiece.Key} -> Composer: {currpiece.Value[0]}, Key: {currpiece.Value[1]}");
            }
        }
    }
}