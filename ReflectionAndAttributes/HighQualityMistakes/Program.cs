using System;
using System.Xml;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string classToInspect = Console.ReadLine();
            string result = spy.AnalyzeAccessModifiers($"Stealer.{classToInspect}");
            Console.WriteLine(result);
        }
    }
}
