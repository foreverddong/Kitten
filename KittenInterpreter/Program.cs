using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitten;
using Antlr4.Runtime;
using System.IO;
namespace KittenInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var inpt = new Interpreter(".\\test.meow");
            inpt.Start();
            Console.ReadKey();
        }
    }
}
