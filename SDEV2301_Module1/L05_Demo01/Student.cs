using System;
using System.Collections.Generic;
using System.Text;

namespace L05_Demo01
{
    public class Student
    {
        public string Name;
        public int Age;

        public void PrintInfo()
        {
            Console.WriteLine($"{Name} is {Age} years old.");
        }
    }
}
