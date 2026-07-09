using System;
using System.Collections.Generic;
using System.Text;

namespace UNV_System.Models
{   
    public abstract class Person
    {
        public int ID {  get; protected set; }
        public string Name { get; protected set; }
        public Person(int id ,string name)
        {
            ID = id;
            Name = name;
        }
        public void UpdateName(string newName)
        {
            if(string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Name cannot be empty or consist only of white spaces", nameof(newName));

            }
            this.Name = newName;
        }
        public abstract void DisplayInfo();
    }

}
