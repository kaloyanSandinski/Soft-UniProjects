using System;

namespace ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person person = new Person(string.Empty, "", 150);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
