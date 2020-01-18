using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("hello world");// Console is a class of System namespace and writhe is one of its methods
            int i = Convert.ToInt16(Console.ReadKey());// Convert class is used for inter type conversions , whereever possible
            Console.Write(i);
            // if the below two methods were not used in VS , then the program would imideatly get terminated
            Console.Read();// Read() method would terminate reading when ENTER key is pressed i.e it terminates at '\n'
            Console.ReadKey(); // this method terminates at any single character
        }
    }
}
