using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_01_
{
    public class EventLogger
    {
        private ILogger _logger { get; set; }
        public EventLogger(ILogger logger)
        {
            _logger = logger;
        }
    
        public void Print(string msg)
        {
            _logger.Print(msg);
        }
    }
}
