using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_01_
{
    public class ConsoleLogger:ILogger
    {
        public void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
