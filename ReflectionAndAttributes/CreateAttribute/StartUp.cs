using System;

namespace AuthorProblem
{
    [Author("Vesko")]
    [Author("Misho")]
    public class StartUp
    {
        [Author("Pesho")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }

    }
}
