using System;
using System.Collections.Generic;
using System.Linq;
using MVCExample.Models;

namespace MVCExampleUnitTest.App_Data
{
    public class TestData
    {
        public static IQueryable<Student> Students
        {
            get
            {
                var students = new List<Student>();
                for (var i = 0; i < 10; i++)
                {
                    var student = new Student
                    {
                        EnrollmentDate = new DateTime(),
                        Enrollments = new List<Enrollment>(),
                        FirstMidName = "Luis",
                        Id = i,
                        LastName = "Acosta"
                    };
                    students.Add(student);
                }
                
                return students.AsQueryable();
            }
        }
    }
}