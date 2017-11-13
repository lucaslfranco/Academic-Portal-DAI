using Library.BL;
using Library.DAL;
using System;
using System.Collections.Generic;

namespace ConnectionTest
{
    class ConnectionTest
    {
        /* Only for testing in console application */

        // Run the List of students and print their names on the screen
        public static void ListStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine("Nome: " + student.Name);
                Console.WriteLine("Data de Nascimento: " + student.BirthDate.ToString("d"));
                Console.WriteLine("Email: " + student.Email);
            }
        }

        // Run the List of schools and print their names on the screen
        public static void ListSchools(List<School> schools)
        {
            foreach (School school in schools)
                Console.WriteLine(school.Name);
        }

        // Run the List of schools and print their names and associated school on the screen
        public static void ListTeachers(List<Teacher> teachers)
        {
            String teacherSchool = "";

            foreach (Teacher teacher in teachers)
            {
                teacherSchool = SchoolDAL.GetById(teacher.IdSchool).Name;   // Just testing the "foreign key" to get the school name
                Console.WriteLine("Name: " + teacher.Name + "\t\tEscola: " + teacherSchool);
            }
        }

        public static void ListCourses(List<Course> courses)
        {
            String courseSchool = "";

            foreach (Course course in courses)
            {
                courseSchool = SchoolDAL.GetById(course.IdSchool).Name;  // Just testing the "foreign key" to get the school name
                Console.WriteLine("Name: " + course.Name + "\t\t\tEscola: " + courseSchool);
            }
        }

        /* "Test Routines" */
        public static void TestStudents()
        {
            /* Tests with 'students' */
            Console.WriteLine("\n--------------- Student Tests ---------------");
            // Create some Student objects and fills their atributes
            Student student01 = new Student();
            student01.Id = 0;
            student01.Name = "Paulo";
            student01.BirthDate = new DateTime(1986, 06, 10);
            student01.EnrollDate = new DateTime(2016, 03, 21);
            student01.Country = "México";
            student01.Email = "paulo@email.com";
            student01.Phone = "+351 1238222";

            Student student02 = new Student();
            student02.Id = 1;
            student02.Name = "Maria";
            student02.BirthDate = new DateTime(1990, 02, 22);
            student02.EnrollDate = new DateTime(2017, 09, 25);
            student02.Country = "Portugal";
            student02.Email = "maria@email.pt";
            student02.Phone = "1231231";

            // Insert both students to table 'students'
            student01.Create();
            student02.Create();

            // Get a student by your ID
            Student studentTest = student01.GetById();

            Console.WriteLine("\nGetById: " + studentTest.Id);
            Console.WriteLine("Nome: " + studentTest.Name);
            Console.WriteLine("Data de Nascimento: " + studentTest.BirthDate.ToString("d"));
            Console.WriteLine("Data Matricula: " + studentTest.EnrollDate.ToString("d"));
            Console.WriteLine("País: " + studentTest.Country);
            Console.WriteLine("Email: " + studentTest.Email);
            Console.WriteLine("Número de Telemóvel: " + studentTest.Phone);

            // Get all the students from table 'student'
            Console.WriteLine("\nGetAll");
            ListStudents(student01.GetAll());

            // Delete a student by your ID
            Console.WriteLine("\nDelete: " + student01.Name);
            student01.Delete();
            ListStudents(student01.GetAll());

            // Some changes in a student data
            student02.Name = "Mariana";
            student02.Email = "mariana@email.pt";
            // Update a student by your ID
            student02.Update();

            // Get all the students again, now updated
            Console.WriteLine("\nGetAll Updated");
            ListStudents(student02.GetAll());
        }

        public static void TestSchools()
        {
            /* Tests with 'Schools' */
            Console.WriteLine("\n--------------- School Tests ---------------");
            // Create some School objects and fills their atributes
            School school01 = new School();
            school01.Id = 0;
            school01.Name = "Escola Superior de Tecnologia e Gestão de Bragança";
            school01.PostalCode = "5300-252";
            school01.Phone = "+351 273303000";

            School school02 = new School();
            school02.Id = 3;
            school02.Name = "Escola Superior de Educação de Bragança";
            school02.PostalCode = "5300-252";
            school02.Phone = "+351 273330600";

            // Insert both schools to table 'school'
            school01.Create();
            school02.Create();

            // Get a school by its ID
            Console.WriteLine("\nGetById: " + school01.Id);
            Console.WriteLine(school01.GetById().Name);

            // Get all the schools from table 'school'
            Console.WriteLine("\nGetAll");
            ListSchools(school01.GetAll());

            // Delete a school by its ID
            Console.WriteLine("\nDelete: " + school02.Name);
            school02.Delete();
            ListSchools(school01.GetAll());

            // Some changes in a school data
            school01.Name = "ESTIG";
            school01.Phone = "+351 123123123";
            // Update a school by your ID
            school01.Update();

            // Get all the schools again, now updated
            Console.WriteLine("\nGetAll Updated");
            ListSchools(school01.GetAll());

            // Just for teacher tests
            school02.Create();
        }

        public static void TestTeachers()
        {
            /* Tests with 'Teachers' */
            Console.WriteLine("\n--------------- Teacher Tests ---------------");
            // Create some Teacher objects and fills their atributes
            Teacher teacher01 = new Teacher();
            teacher01.Id = 0;
            teacher01.Name = "Marcelo da Silva";
            teacher01.Condition = "Dedicação Total";
            teacher01.Email = "marcelosilva@ipb.pt";
            teacher01.IdSchool = 0;

            Teacher teacher02 = new Teacher();
            teacher02.Id = 3;
            teacher02.Name = "Maria Oliveira";
            teacher02.Condition = "Contratação Temporária";
            teacher02.Email = "mariaoliveira@ipb.pt";
            teacher02.IdSchool = 3;

            // Insert both teachers to table 'teachers'
            teacher01.Create();
            teacher02.Create();

            // Get a teacher by your ID
            Console.WriteLine("\nGetById: " + teacher01.Id);
            Console.WriteLine(teacher01.GetById().Name);

            // Get all the teachers from table 'teacher'
            Console.WriteLine("\nGetAll");
            ListTeachers(teacher01.GetAll());

            // Delete a teacher by your ID
            Console.WriteLine("\nDelete: " + teacher01.Name);
            teacher01.Delete();
            ListTeachers(teacher01.GetAll());

            // Some changes in a teacher data
            teacher01.Name = "Marcelo de Souza";
            teacher01.IdSchool = 3;
            // Update a teacher by your ID
            teacher01.Update();

            // Get all the teachers again, now updated
            Console.WriteLine("\nGetAll Updated");
            ListTeachers(teacher01.GetAll());
        }

        public static void TestCourses()
        {
            /* Tests with 'Courses' */
            Console.WriteLine("\n--------------- Course Tests ---------------");
            // Create some Course objects and fills their atributes
            Course course01 = new Course();
            course01.Id = 0;
            course01.Name = "Engenharia Informática";
            course01.Degree = "Bacharelado";
            course01.DurationYears = 3;
            course01.IdSchool = 0;

            Course course02 = new Course();
            course02.Id = 1;
            course02.Name = "Desenvolvimento de Produtos Multimédia";
            course02.Degree = "Técnico Superior";
            course02.DurationYears = 2;
            course02.IdSchool = 3;

            // Insert both students to table 'students'
            course01.Create();
            course02.Create();

            // Get a course by its ID
            Console.WriteLine("\nGetById: " + course01.Id);
            Console.WriteLine(course01.GetById().Name);

            // Get all the courses from table 'course'
            Console.WriteLine("\nGetAll");
            ListCourses(course01.GetAll());

            // Delete a course by its ID
            Console.WriteLine("\nDelete: " + course02.Name);
            course02.Delete();
            ListCourses(course01.GetAll());

            // Some change in a course data
            course02.Name = "Desenvolv. de Prod. Mult.";
            
            // Update a student by your ID
            course02.Update();

            // Get all the students again, now updated
            Console.WriteLine("\nGetAll Updated");
            ListCourses(course01.GetAll());

            // Just for teacher tests
            course02.Create();
        }

        public static void Main(String[] args)
        {
            /* Create all the tables */
            StudentDAL.CreateTable();
            SchoolDAL.CreateTable();
            TeacherDAL.CreateTable();
            CourseDAL.CreateTable();

            /* Run some test methods */
            TestStudents();
            // TestSchools();
            // TestTeachers();
            // TestCourses();
            
        }
    }
}
