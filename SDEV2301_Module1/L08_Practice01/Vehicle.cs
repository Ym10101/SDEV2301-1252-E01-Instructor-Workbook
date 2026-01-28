using System;
using System.Collections.Generic;
using System.Text;

namespace L08_Practice01
{
    public class Vehicle
    {
        public int Speed { get; private set; }
      
        public void Move()
        {
            Console.WriteLine($"The vehicle is moving at {Speed} mph.");
        }
    }

    public class Car : Vehicle
    {
       public void Honk()
       {
           Console.WriteLine("Car is honking: Beep Beep!");
        }
    }

    public class Bike : Vehicle
    {
        public void RingBell()
        {
            Console.WriteLine("Bike is ringing bell: Ding Ding!");
        }
    }
}
