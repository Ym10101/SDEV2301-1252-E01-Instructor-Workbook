using System;
using System.Collections.Generic;
using System.Text;

namespace L08_Demo01
{
    public class Animal
    {
        public string Name { get; set; }

        public void Eat()
        {
            Console.WriteLine("Animal is eating.");
        }

        public virtual void Speek() // virtual allows derived classes to override this method
        {
            Console.WriteLine("Animal makes a sound.");
        }
        override public string ToString()
        {
            return $"Animal Name: {Name}";
        }
    }

    public class Cat : Animal   // inherits Name and Eat() method
    {
        public void Meow()
        {
            Console.WriteLine("Cat is meowing.");
        }
        public override void Speek() // override provides a new implementation
        {
            Console.WriteLine("Cat says: Meow Meow!");
        }
        override public string ToString()
        {
            return $"Cat Name: {Name}";
        }
    }
    public class Dog : Animal   // inherits Name and Eat() method
    {
        public void Bark()
        {
            Console.WriteLine("Dog is barking.");
        }

        public override void Speek() // override provides a new implementation
        {
            Console.WriteLine("Dog says: Woof Woof!");
        }

        override public string ToString()
        {
            return $"Dog Name: {Name}";
        }
    }
}
