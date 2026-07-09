using UNV_System.Enums;
using UNV_System.Models;
using UNV_System.Services;

Student student = new Student(1, "Mostafa", "SW001");

CourseServices courseServices = new CourseServices();
courseServices.AddCourse(new Course(1, "Math", 3, CourseType.Mathematics));
courseServices.AddCourse(new Course(2, "CS101", 3, CourseType.Programming));
courseServices.AddCourse(new Course(3, "Networks", 3, CourseType.Networking));

MenuServices Menu = new MenuServices(student, courseServices);
Menu.Run();
