using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string tokens = Console.ReadLine();
            HashSet<string> vipPartyGuest = new HashSet<string>();
            HashSet<string> partyGuest = new HashSet<string>();
            bool isGoing = false;
            while (tokens!="END")
            {
                if (tokens=="PARTY")
                {
                    isGoing = true;
                }

                if (isGoing)
                {
                    if (tokens[0]>='0'&&tokens[0]<='9')
                    {
                        vipPartyGuest.Remove(tokens);
                    }
                    else
                    {
                        partyGuest.Remove(tokens);
                    }
                }
                else
                {
                    if (tokens[0]>='0'&&tokens[0]<='9')
                    {
                        vipPartyGuest.Add(tokens);S
                    }
                    else
                    {
                        partyGuest.Add(tokens);
                    }
                }

                tokens = Console.ReadLine();
            }
            Console.WriteLine(vipPartyGuest.Count+partyGuest.Count);
                foreach (var currGuest in vipPartyGuest)
                {
                    Console.WriteLine(currGuest);
                }

                foreach (var currGuest in partyGuest)
                {
                    Console.WriteLine(currGuest);
                }
        }
    }
}