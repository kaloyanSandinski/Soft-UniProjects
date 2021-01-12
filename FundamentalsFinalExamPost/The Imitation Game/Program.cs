using System;
using System.Linq;
using System.Text;

namespace The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputMessage = Console.ReadLine();
            string inputData = Console.ReadLine();
            while (inputData!= "Decode")
            {
                string[] currComands = inputData.Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = currComands[0];
                if (command == "Move")
                {
                    int numberOfLetters = int.Parse(currComands[1]);
                    string lettersToMove = inputMessage.Substring(0, numberOfLetters);
                    inputMessage = inputMessage.Remove(0, numberOfLetters);
                    inputMessage = inputMessage.Insert(inputMessage.Length, lettersToMove);
                }
                else if (command =="Insert")
                {
                    int index = int.Parse(currComands[1]);
                    string value = currComands[2];
                    inputMessage = inputMessage.Insert(index, value.ToString());
                }
                else if (command=="ChangeAll")
                {
                    string substring = currComands[1];
                    string replacement = currComands[2];
                    inputMessage = inputMessage.Replace(substring, replacement);
                }

                inputData = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {inputMessage}");
        }
    }
}