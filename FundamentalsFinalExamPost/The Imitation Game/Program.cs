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
                    StringBuilder lettersToMove = new StringBuilder();
                    for (int i = 0; i < numberOfLetters; i++)
                    {
                        lettersToMove.Append(inputMessage[i]);
                    }

                    inputMessage = inputMessage.Substring(0, numberOfLetters - 1);
                    inputMessage.Concat(lettersToMove.ToString());
                }
                else if (command =="Insert")
                {
                    int index = int.Parse(currComands[1]);
                    int value = int.Parse(currComands[2]);
                }
                else if (command=="ChangeAll")
                {
                    string substring = currComands[1];
                    string replacement = currComands[2];
                }

                inputData = Console.ReadLine();
            }

            Console.WriteLine(inputMessage);
        }
    }
}