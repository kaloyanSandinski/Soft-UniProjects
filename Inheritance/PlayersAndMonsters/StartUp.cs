using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Elf elf = new Elf("PeshoElfa", 23);
            Console.WriteLine(elf);
        }
    }
}