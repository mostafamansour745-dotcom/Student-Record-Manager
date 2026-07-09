using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UNV_System.Interfaces;
using UNV_System.Enums;

namespace UNV_System.Models
{
   public class Student : Person, IPrintable
    {
        private string v;

        public string StudentId { get; set; }
        public List<Course> RegisteredCourses { get; private set; }
        public DateTime DateOfBirth {  get; private set; }
        public double GPA { get;private set; }
        public string PhotoPath { get; private set; }
        public Department StudentDepartment { get; private set; }
        public Student(int id, string name, string studentId , DateTime dateOfbirth , Department department) : base(id, name)
        {
            
            ValidateDateOfBirth(dateOfbirth);

            StudentId = studentId;
            DateOfBirth = dateOfbirth;
            StudentDepartment = department;

            GPA = 0.0;
            PhotoPath = null;
            RegisteredCourses = new List<Course>();
        }

        public Student(int id, string name, string v) : base(id, name)
        {
            this.v = v;
        }

        private void ValidateDateOfBirth(DateTime dob)
        {
            
            if (dob > DateTime.Now)
            {
                throw new ArgumentException("Date of birth cannot be in the future.", nameof(dob));
            }

            int age = DateTime.Now.Year - dob.Year;
            if (DateTime.Now.Date < dob.Date.AddYears(age))
            {
                age--;
            }

           
            if (age < 16)
            {
                throw new ArgumentException("Student must be at least 16 years old based on exact date.", nameof(dob));
            }
        }
        public void UpdateGPA(double newGpa)
        {
            if (newGpa < 0.0 || newGpa > 4.0)
            {
                throw new ArgumentException("GPA must be between 0.0 and 4.0.", nameof(newGpa));
            }
            this.GPA = newGpa;
        }
        public void UpdateDateOfBirth(DateTime dob)
        {
           ValidateDateOfBirth((DateTime)dob);
            this.DateOfBirth = dob;
        }
        public void ChangeDepartment(Department newDept)
        {
            this.StudentDepartment = newDept;
        }

        public void UpdatePhotoPath(string path)
        {
            this.PhotoPath = path;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID} | Name: {Name} | StudentID: {StudentId}");
        }
        public void Print()
        {
            DisplayInfo();
        }
        public int GetTotalCreditHours()
        {
            int total = 0;
            foreach (Course c in RegisteredCourses)
                total += c.CreditHours;
            return total;
        }
        public void RegisterCourse(Course course)
        {
            RegisteredCourses.Add(course);
        }
        public Course this[int index]
        {
            get
            {
                return RegisteredCourses[index];
            }

        }
        public static bool operator <(Student s1 ,Student s2 )
        {
            return s1.GetTotalCreditHours() < s2.GetTotalCreditHours();
        }
        public static bool operator >(Student s1 ,Student s2 )
        {
            return s1.GetTotalCreditHours() > s2.GetTotalCreditHours();
        }
    }
}
