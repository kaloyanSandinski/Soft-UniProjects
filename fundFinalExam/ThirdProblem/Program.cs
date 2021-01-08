using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirdProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLines = Console.ReadLine();
            Dictionary<string, int> followers = new Dictionary<string, int>();
            char[] separator = new[] {' ', ':'};
            while (inputLines!="Log out")
            {
                string[] inputCommands = inputLines
                    .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (inputCommands[0]=="New")
                {
                    string username = inputCommands[2];
                    if (!followers.ContainsKey(username))
                    {
                        followers.Add(username, 0);
                    }
                }
                else if (inputCommands[0]=="Like")
                {
                    string username = inputCommands[1];
                    int likesCount = int.Parse(inputCommands[2]);
                    if (followers.ContainsKey(username))
                    {
                        followers[username] += likesCount;
                    }
                    else
                    {
                        followers.Add(username, likesCount);
                    }
                }
                else if (inputCommands[0]=="Comment")
                {
                    string username = inputCommands[1];
                    if (followers.ContainsKey(username))
                    {
                        followers[username] += 1;
                    }
                    else
                    {
                        followers.Add(username, 1);
                    }
                }
                else if (inputCommands[0]=="Blocked")
                {
                    string username = inputCommands[1];
                    if (followers.ContainsKey(username))
                    {
                        followers.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }

                inputLines = Console.ReadLine();
            }

            followers = followers
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(a => a.Key, a => a.Value);
            Console.WriteLine($"{followers.Count} followers");
            foreach (var follower in followers)
            {
                Console.WriteLine($"{follower.Key}: {follower.Value}");
            }
        }
    }
}