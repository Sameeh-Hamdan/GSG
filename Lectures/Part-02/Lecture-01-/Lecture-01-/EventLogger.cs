using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_01_
{
    public class EventLogger
    {
        private ConsoleLogger _logger = new ConsoleLogger();
        public void Print(string msg)
        {
            _logger.PrintToConsole(msg);
        }
    }
}
