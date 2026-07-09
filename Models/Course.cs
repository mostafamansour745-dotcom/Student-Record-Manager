using System;
using System.Collections.Generic;
using System.Text;
using UNV_System.Enums;
using UNV_System.Interfaces;

namespace UNV_System.Models
{
    public class Course : IPrintable
    {
        public static int TotalCourses = 0;
        public int CourseId { get; private set; }
        public string Name { get; private set; }
        public int CreditHours { get; private set; }
        public CourseType CourseType { get; private set; }
        public Course(int courseId, string name, int creditHours, CourseType courseType)
        {
            CourseId = courseId;
            Name = name;
            CreditHours = creditHours;
            CourseType = courseType;
            TotalCourses++;
        }
        public void Print ()
        {
            Console.WriteLine($"ID: {CourseId} | Name:{Name} | CreditHours:{CreditHours} | Type:{CourseType}");

        }
    }
}
