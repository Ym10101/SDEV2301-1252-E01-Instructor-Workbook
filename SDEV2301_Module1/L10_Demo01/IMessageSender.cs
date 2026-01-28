using System;
using System.Collections.Generic;
using System.Text;

namespace L10_Demo01
{
    //public interface Shape
    // {
    //     double CalculateArea();
    //     double CalculatePerimeter();
    // }
    // public class Circle : Shape
    // {
    //     public double Radius { get; set; }
    //     public double CalculateArea()
    //     {
    //         return Math.PI * Radius * Radius;
    //     }
    //     public double CalculatePerimeter()
    //     {
    //         return 2 * Math.PI * Radius;
    //     }
    // }
    // public class Rectangle : Shape
    // {
    //     public double Width { get; set; }
    //     public double Height { get; set; }
    //     public double CalculateArea()
    //     {
    //         return Width * Height;
    //     }
    //     public double CalculatePerimeter()
    //     {
    //         return 2 * (Width + Height);
    //     }
    // }

    public interface IMessageSender
    {
        void Send(string message);
    }

    public class EmailSender : IMessageSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Email: {message}");
        }
    }

    public class SmsSender : IMessageSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }
}
