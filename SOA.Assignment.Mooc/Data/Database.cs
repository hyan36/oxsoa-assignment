using SOA.Assignment.Mooc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOA.Assignment.Mooc.Data
{
    public class Database
    {
        public List<Course> Courses { get; set; }

        public List<Subject> Subjects { get; set; }     

        private static Database _instance = new Database();

        private Database()
        {
            Subjects = new List<Subject>() {
                new Subject() { ID = Guid.NewGuid(), Description = "Test 1", Name = "Test 1" },
                new Subject() { ID = Guid.NewGuid(), Description = "Test 2", Name = "Test 2" },
                new Subject() { ID = Guid.NewGuid(), Description = "Test 3", Name = "Test 3" },
            };
            Courses = new List<Course>()
            {
                new Course() {ID = Guid.NewGuid(), Description = "Course 1", Name = "Course 1", Start = new DateTime(), End = new DateTime(), Subjects = new List<Subject>() { Subjects[0], Subjects[1] } },
                new Course() {ID = Guid.NewGuid(), Description = "Course 2", Name = "Course 2", Start = new DateTime(), End = new DateTime(), Subjects = new List<Subject>() { Subjects[2] } },
            };
        }

        public static Database Instance => _instance;
    }
}
