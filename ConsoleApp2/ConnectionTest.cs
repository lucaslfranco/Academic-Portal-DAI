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
                Console.WriteLine("\nNome: " + teacher.Name + "\nEscola: " + teacherSchool);
            }
        }

        public static void ListCourses(List<Course> courses)
        {
            String courseSchool = "";

            foreach (Course course in courses)
            {
                courseSchool = SchoolDAL.GetById(course.IdSchool).Name;  // Just testing the "foreign key" to get the school name
                Console.WriteLine("\nNome: " + course.Name + "\nEscola: " + courseSchool);
            }
        }

        public static void ListDisciplines(List<Discipline> disciplines)
        {
            String disciplineTeacher = "";

            foreach (Discipline discipline in disciplines)
            {
                disciplineTeacher = TeacherDAL.GetById(discipline.IdTeacher).Name;  // Just testing the "foreign key" to get the school name
                Console.WriteLine("\nNome: " + discipline.Name + "\nProfessor: " + disciplineTeacher);
            }
        }

        public static void ListEnrollments(List<Enrollment> enrollments)
        {
            foreach (Enrollment enrollment in enrollments)
            {
                Console.WriteLine("\nNumero de Faltas: " + enrollment.MissedClasses);
            }
        }

        public static void ListGrades(List<Grades> gradesList)
        {
            foreach (Grades grades in gradesList)
            {
               Console.WriteLine("\nNota 01: " + grades.Grade1 + "\tNota 02: " + grades.Grade2);
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

            // Just for enrollment tests
            student02.Create();
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
            teacher02.Name = "Maria da Silva Souza ";
            teacher02.IdSchool = 0;
            // Update a teacher by your ID
            teacher02.Update();

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

            // Insert both courses to table 'courses'
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
            
            // Update a course by your ID
            course02.Update();

            // Get all the courses again, now updated
            Console.WriteLine("\nGetAll Updated");
            ListCourses(course01.GetAll());

            // Just for teacher tests
            course02.Create();
        }

        public static void TestDisciplines()
        {
            /* Tests with 'Disciplines' */
            Console.WriteLine("\n--------------- Discipline Tests ---------------");
            // Create some Discipline objects and fills their atributes
            Discipline discipline01 = new Discipline();
            discipline01.Id = 0;
            discipline01.Name = "Desenvolvimento de Aplicações Informáticas";
            discipline01.Credits = 6;
            discipline01.Year = 2017;
            discipline01.Semester = 1;
            discipline01.StartTime = new DateTime(2017, 11, 7, 14, 0, 0);
            discipline01.EndTime = new DateTime(2017, 11, 7, 16, 0, 0);
            discipline01.ClassesHeld = 10;
            discipline01.IdTeacher = 3;
            discipline01.IdCourse = 0;

            Discipline discipline02 = new Discipline();
            discipline02.Id = 1;
            discipline02.Name = "Sistemas Distribuídos";
            discipline02.Credits = 6;
            discipline02.Year = 2017;
            discipline02.Semester = 1;
            discipline02.StartTime = new DateTime(2017, 11, 7, 11, 0, 0);
            discipline02.EndTime = new DateTime(2017, 11, 7, 13, 0, 0);
            discipline02.ClassesHeld = 8;
            discipline02.IdTeacher = 3;
            discipline02.IdCourse = 0;

            // Insert both disciplines to table 'disciplines'
            discipline01.Create();
            discipline02.Create();

            // Get a discipline by its ID
            Console.WriteLine("\nGetById: " + discipline01.Id);
            Console.WriteLine(discipline01.GetById().Name);

            // Get all the disciplines from table 'discipline'
            Console.WriteLine("\nGetAll");
            ListDisciplines(discipline01.GetAll());

            // Delete a discipline by its ID
            Console.WriteLine("\nDelete: " + discipline02.Name);
            discipline02.Delete();
            ListDisciplines(discipline01.GetAll());

            // Some change in a discipline data
            discipline02.Name = "Sistemas Distribuídos I";

            // Update a discipline by your ID
            discipline02.Update();

            // Get all the disciplines again, now updated
            Console.WriteLine("\nGetAll Updated");
            ListDisciplines(discipline02.GetAll());

            // Just for another tests
            discipline02.Create();
        }

        public static void TestGrades()
        {
            /* Tests with 'Grades' */
            Console.WriteLine("\n--------------- Grade Tests ---------------");
            // Create some Grade objects and fills their atributes
            Grades grades01 = new Grades();
            grades01.Id = 0;
            grades01.Grade1 = 8;
            grades01.Grade2 = 6;
            grades01.Grade3= 5;
            grades01.Grade4 = 2;

            Grades grades02 = new Grades();
            grades02.Id = 1;
            grades02.Grade1 = 4;
            grades02.Grade2 = 2;
            grades02.Grade3 = 2;
            grades02.Grade4 = 1;

            // Insert both grades to table 'grades'
            grades01.Create();
            grades02.Create();

            // Get a grade by its IDs
            Console.WriteLine("\nGetByIds: " + grades01.Id);
            Console.WriteLine("Nota 01: " + grades01.GetById().Grade1);

            // Get all the grades from table 'grade'
            Console.WriteLine("\nGetAll");
            ListGrades(grades01.GetAll());

            // Delete a grade by its ID
            Console.WriteLine("\nDelete");
            grades02.Delete();
            ListGrades(grades01.GetAll());

            // Some change in a grade data
            grades01.Grade1 = 2;

            // Update a grade by your ID
            grades01.Update();

            // Get all the grades again, now updated
            Console.WriteLine("\nGetAll Updated");
            ListGrades(grades01.GetAll());

            // Just for another tests
            grades02.Create();
        }

        public static void TestEnrollments()
        {
            /* Tests with 'Enrollments' */
            Console.WriteLine("\n--------------- Enrollment Tests ---------------");
            // Create some Enrollment objects and fills their atributes
            Enrollment enrollment01 = new Enrollment();
            enrollment01.IdDiscipline = 0;
            enrollment01.IdStudent = 0;
            enrollment01.MissedClasses = 6;
            enrollment01.IdGrades = 0;

            Enrollment enrollment02 = new Enrollment();
            enrollment02.IdDiscipline = 0;
            enrollment02.IdStudent = 1;
            enrollment02.MissedClasses = 3;
            enrollment02.IdGrades = 1;
            
            // Insert both enrollments to table 'enrollments'
            enrollment01.Create();
            enrollment02.Create();

            // Get a enrollment by its IDs
            Console.WriteLine("\nGetByIds: " + enrollment01.IdDiscipline + " e " + enrollment01.IdStudent);
            Console.WriteLine("Numero de faltas: " + enrollment01.GetById().MissedClasses);

            // Get all the enrollments from table 'enrollment'
            Console.WriteLine("\nGetAll");
            ListEnrollments(enrollment01.GetAll());

            // Delete a enrollment by its ID
            Console.WriteLine("\nDelete");
            enrollment02.Delete();
            ListEnrollments(enrollment01.GetAll());

            // Some change in a enrollment data
            enrollment02.MissedClasses = 2;

            // Update a enrollment by your ID
            enrollment02.Update();

            // Get all the enrollments again, now updated
            Console.WriteLine("\nGetAll Updated");
            ListEnrollments(enrollment02.GetAll());

            // Just for another tests
            enrollment02.Create();
        }

        public static void Main(String[] args)
        {
            /* Create all the tables */
            StudentDAL.CreateTable();
            SchoolDAL.CreateTable();
            TeacherDAL.CreateTable();
            CourseDAL.CreateTable();
            DisciplineDAL.CreateTable();
            MessageDAL.CreateTable();
            GradesDAL.CreateTable();
            EnrollmentDAL.CreateTable();

            /* Run some test methods */
            TestStudents();
            TestSchools();
            TestTeachers();
            TestCourses();
            TestDisciplines();
            TestGrades();
            TestEnrollments();
        }
    }
}
