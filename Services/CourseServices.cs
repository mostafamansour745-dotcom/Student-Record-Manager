using System;
using System.Collections.Generic;
using System.Text;
using UNV_System.Models;

namespace UNV_System.Services
{
  class CourseServices
  {
      private List<Course> _courses = new List<Course>();
      public void AddCourse(Course course)
      {
            _courses.Add(course);
      }
      public List<Course> GetAll()
        {
            return _courses;
        }
        public Course FindById(int id)
        {
            foreach (Course c in _courses)
            {
                if(c.CourseId == id)
                {
                    return c;
                }

            }
            return null;

        }
        public void DisplayAll()
        {
            foreach (Course c in _courses)
            {
                c.Print();
            }
        }
  }
}
