using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> genericList = new GenericList<int>();
            genericList.Add(1);
            genericList.Add(2);
            genericList.Add(3);
            genericList.Add(4);
            Console.WriteLine(genericList);
            GenericList<string> genericString = new GenericList<string>();
            genericString.Add("John");
            genericString.Add("Phil");
            foreach (int item in genericList)
            {
                Console.WriteLine(genericList);
            }
            foreach (string item in genericString)
            {
                Console.WriteLine(genericString );
            }
            Console.ReadLine();
        }
    }
}
