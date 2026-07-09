using System;
using System.Collections.Generic;
using System.Text;
using UNV_System.Enums;
using UNV_System.Models;
namespace UNV_System.Services
{
    class MenuServices
    {
        private Student _student ;
        private CourseServices _courseServices;
        public MenuServices(Student student, CourseServices courseServices)
        {
            _student = student;
            _courseServices = courseServices;
        }
        public void Run()
        {
            bool running = true;
            while (running)
            {
                MainScreen();
                try
                {
                    int Choice = int.Parse(Console.ReadLine());
                    if (Choice == 1)
                    {
                        _courseServices.DisplayAll();
                    }
                    else if (Choice == 2)
                    {
                        RegisterCourse();
                    }
                    else if (Choice == 3)
                    {
                        ViewMyCourses();
                    }
                    else if (Choice == 4)
                    {
                        running = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choise");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error , Please Enter Number\n");
                }
                finally
                {
                    Console.WriteLine("________");
                }
            }
        }
        public void RegisterCourse()
        {
            Console.WriteLine("Enter ID : \n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Course course = _courseServices.FindById(id);
                if (course == null)
                {
                    throw new Exception("Course Not Found");
                }
                _student.RegisterCourse(course);
                Console.WriteLine("Register Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }
            finally
            {
                Console.WriteLine("Operatoin Finished");
            }
        

        }
        public void ViewMyCourses()
        {
            foreach(Course c in _student.RegisteredCourses)
            {
                c.Print();
            }
        }
        public void MainScreen()
        {
            Console.Clear();

           
            string space = new string(' ', 40);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(space + "         STUDENT RECORD MANAGER");
            Console.WriteLine(space + "                Main Menu");
            Console.WriteLine(space + "∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙");
            Console.WriteLine();

            Console.WriteLine(space + "[1] View Available Courses");
            Console.WriteLine(space + "[2] Register for a Course");
            Console.WriteLine(space + "[3] View My Courses");
            Console.WriteLine(space + "[4] Exit");
            Console.WriteLine();

            Console.WriteLine(space + "∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙∙");
            Console.WriteLine();

            Console.Write(space + "Choose an option > ");
        }
        
    }
}
