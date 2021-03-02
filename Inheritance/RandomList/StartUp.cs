using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("az sam Pesho");
            list.Add("az sam Gogi");
            list.Add("az ne znam koi sam");
            string randomItem = list.RandomString();
            Console.WriteLine(randomItem);
        }
    }
}