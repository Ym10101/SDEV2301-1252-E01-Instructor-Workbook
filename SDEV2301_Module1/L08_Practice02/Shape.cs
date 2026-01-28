using System;
using System.Collections.Generic;
using System.Text;

namespace L08_Practice02
{
    public class Shape
    {
        public virtual void Draw() // virtual allows derived classes to override this method
        {
            Console.WriteLine("Drawing a shape.");
        }
    }

    public class Circle : Shape   // inherits Draw() method
    {
        public override void Draw() // override provides a new implementation
        {
            Console.WriteLine("Drawing a circle.");
        }
    }

    public class Rectangle : Shape   // inherits Draw() method
    {
        public override void Draw() // override provides a new implementation
        {
            Console.WriteLine("Drawing a rectangle.");
        }
    }
}
    