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
            foreach(Student student in students)
                Console.WriteLine(student.Name);
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
                teacherSchool = SchoolDAL.GetById(teacher.IdSchool).Name;   //Just testing the "foreign key"
                Console.WriteLine("Name: " + teacher.Name + "\t\tEscola: " + teacherSchool);
            }
        }

        public static void TestStudents()
        {
            /* Tests with 'students' */
            Console.WriteLine("---------- Student Tests ----------");
            // Create some Student objects and fills their atributes
            Student student01 = new Student();
            student01.Id = 0;
            student01.Name = "Paulo";
            student01.BirthDate = "10/06/1986";
            student01.EnrollDate = "21/03/2016";
            student01.Country = "México";
            student01.Email = "paulo@email.com";
            student01.Phone = "+351 1238222";

            Student student02 = new Student();
            student02.Id = 1;
            student02.Name = "Maria";
            student02.BirthDate = "22/02/1990";
            student02.EnrollDate = "25/09/2017";
            student02.Country = "Portugal";
            student02.Email = "maria@email.pt";
            student02.Phone = "1231231";

            // Insert both students to table 'students'
            student01.Create();
            student02.Create();

            // Get a student by your ID
            Console.WriteLine("\nGetById: " + student01.Id);
            Console.WriteLine(student01.GetById().Name);

            // Get all the students from table 'student'
            Console.WriteLine("\nGetAll");
            ListStudents(student01.GetAll());

            // Delete a student by your ID
            Console.WriteLine("\nDelete: " + student01.Name);
            student01.Delete();

            Console.WriteLine("\nGetAll");
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
            Console.WriteLine("---------- School Tests ----------");
            // Create some School objects and fills their atributes
            School school01 = new School();
            school01.Id = 0;
            school01.Name = "Escola Superior de Tecnologia e Gestão de Bragança";
            school01.PostalCode = "5300-252";
            school01.Phone = "+351 273303000";

            School school02 = new School();
            school02.Id = 3;
            school02.Name = "Escola Superior Agrária de Bragança";
            school02.PostalCode = "5300-253";
            school02.Phone = "+351 273303200";

            // Insert both students to table 'students'
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

            Console.WriteLine("\nGetAll");
            ListSchools(school01.GetAll());

            // Some changes in a school data
            school01.Name = "ESTIG";
            school01.Phone = "+351 123123123";
            // Update a student by your ID
            school01.Update();

            // Get all the students again, now updated
            Console.WriteLine("\nGetAll Updated");
            ListSchools(school01.GetAll());

            // Just for teacher tests
            school02.Create();
        }

        public static void TestTeachers()
        {
            /* Tests with 'Teachers' */
            Console.WriteLine("---------- Teacher Tests ----------");
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

            // Insert both students to table 'students'
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

            Console.WriteLine("\nGetAll");
            ListTeachers(teacher01.GetAll());

            // Some changes in a teacher data
            teacher01.Name = "Marcelo de Souza";
            teacher01.IdSchool = 3;
            // Update a student by your ID
            teacher01.Update();

            // Get all the students again, now updated
            Console.WriteLine("\nGetAll Updated");
            ListTeachers(teacher01.GetAll());
        }

        public static void Main(String[] args)
        {

            /* Create all the tables */
            StudentDAL.CreateTable();
            SchoolDAL.CreateTable();
            TeacherDAL.CreateTable();

            /* Run some test methods */
            TestStudents();
            TestSchools();
            TestTeachers();
        }
    }
}
