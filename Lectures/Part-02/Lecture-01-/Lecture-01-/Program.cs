using System;

namespace Lecture_01_
{
    class Program
    {
        static void Main(string[] args)
        {
            //ILogger logger = new ConsoleLogger();
            ILogger logger = new FileLogger();
            var eventLogger=new EventLogger(logger);
            eventLogger.Print("Sameeh Abutaima");
            Console.ReadKey();
        }
    }
}
