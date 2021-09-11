using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLhw
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"XmlWorker.xml";
            string ns = @"www.dataworker.com";
            ConsoleMenu menu = new ConsoleMenu(path, ns);
            menu.Start();
        }
    }
}
