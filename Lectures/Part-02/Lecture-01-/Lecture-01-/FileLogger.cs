using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_01_
{
    public class FileLogger:ILogger
    {
        public void Print(string msg)
        {
            System.IO.File.WriteAllText("D:\\file.txt", msg);
        }
    }
}
