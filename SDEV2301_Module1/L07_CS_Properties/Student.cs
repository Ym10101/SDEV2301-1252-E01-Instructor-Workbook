using System;
using System.Collections.Generic;
using System.Text;

namespace L07_CS_Properties
{
    public class Student
    {
        // Auto-implemented property
        //public string Name { get; set; }

        // Auto-properties with private set
        // This public read, private write property
        // OUtside code can read the Name property but cannot modify it
        //public string Name { get; private set; }

        // Fully-implemented property with a backing field
        private int _age;
        public int Age
        {
            //get => _age;    // Expression-bodied get accessor
            get
            {
                return _age;
            }
            //set => _age = value; // Expression-bodied set accessor 

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be 0 or greater");
                }
                _age = value;
            }
        }

        // Backing field with private set
        // OUtside code cannot put the object into an invalid state
        // Changes happen through methods inside the class, not direct assignment
        private int _credits;
        public int Credits
        {
            get { return _credits; }
            private set { _credits = value; }
        }

        // Read-only property
        // You can still set in the constructor
        // Once the object is constructed, it cannot be changed
        public string Id { get; }

        // Derived (computed) property
        //public bool HasGraduated
        //{
        //    get
        //    {
        //        return Credits >= 120;
        //    }
        //}
        public bool HasGraduated => Credits >= 120; // Expression-bodied property

    }
}
