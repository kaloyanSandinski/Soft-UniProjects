using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputText = Console.ReadLine().ToCharArray();
            Dictionary<char, int> allCharactersInText = new Dictionary<char, int>();
            foreach (var currCharacter in inputText)
            {
                if (allCharactersInText.ContainsKey(currCharacter))
                {
                    allCharactersInText[currCharacter]++;
                }
                else
                {
                    allCharactersInText.Add(currCharacter,1);
                }
            }

            allCharactersInText = allCharactersInText.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var currChar in allCharactersInText)
            {
                Console.WriteLine($"{currChar.Key}: {currChar.Value} time/s");
            }
        }    
    }
}