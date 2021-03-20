using System;
using System.Xml;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            File file = new File("pesho", 50, 10);
            Console.WriteLine(file.BytesSent);
            Console.WriteLine(file.Length);
        }
    }
}
