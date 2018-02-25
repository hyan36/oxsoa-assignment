using Microsoft.AspNetCore.Mvc;
using SOA.Assignment.Mooc.Data;
using SOA.Assignment.Mooc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOA.Assignment.Mooc.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        protected Database db;

        public CourseController()
        {
            db = Database.Instance;
        }

        // GET api/course
        /// <summary>
        /// get courses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return db.Courses;
        }

        /// <summary>
        /// get a specific course
        /// </summary>
        /// <param name="id">course id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Course Get(string id)
        {
            var result = db.Courses.Where(o => o.ID == new Guid(id)).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// delete a specific course
        /// </summary>
        /// <param name="id">course id</param>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var course = db.Courses.Where(o => o.ID == new Guid(id)).FirstOrDefault();
            db.Courses.Remove(course);
        }

        /// <summary>
        /// create a new course
        /// </summary>
        /// <param name="value">course</param>
        /// <returns></returns>
        [HttpPost]
        public Course Post([FromBody]Course value)
        {
            var isNew = true;
            for (int i = 0; i < db.Courses.Count; i++)
            {
                if (db.Courses[i].ID == value.ID)
                {
                    db.Courses[i] = value;
                    isNew = false;
                }
            }
            if (isNew)
            {
                value.ID = new Guid();
                db.Courses.Add(value);
            }
            return value;
        }

        /// <summary>
        /// update a given course
        /// </summary>
        /// <param name="id">course id</param>
        /// <param name="value">course object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Course Put(string id, [FromBody]Course value)
        {
            for (int i = 0; i < db.Subjects.Count; i++)
            {
                if (db.Courses[i].ID == new Guid(id))
                {
                    db.Courses[i].Name = value.Name;
                    db.Courses[i].Description = value.Description;
                    db.Courses[i].Start = value.Start;
                    db.Courses[i].End = value.End;
                }
            }
            return value;
        }

        /// <summary>
        /// add a subject to a course
        /// </summary>
        /// <param name="id">course id</param>
        /// <param name="subjectId">subject id</param>
        /// <returns></returns>
        [HttpPut("{id}/{subjectId}")]
        public Course Put(string id, string subjectId)
        {
            Course result = null;
            for (int i = 0; i < db.Subjects.Count; i++)
            {
                if (db.Courses[i].ID == new Guid(id))
                {
                    result = db.Courses[i];
                    var subject = db.Subjects.Where(o => o.ID == new Guid(subjectId)).FirstOrDefault();
                    result.Subjects.Add(subject);
                }
            }
            return result;
        }

        /// <summary>
        /// remove a subject from a course
        /// </summary>
        /// <param name="id">course id</param>
        /// <param name="subjectId">subject id</param>
        [HttpDelete("{id}/{subjectId}")]
        public void Delete(string id, string subjectId)
        {
            Course result = null;
            for (int i = 0; i < db.Subjects.Count; i++)
            {
                if (db.Courses[i].ID == new Guid(id))
                {
                    result = db.Courses[i];
                    var subject = db.Subjects.Where(o => o.ID == new Guid(subjectId)).FirstOrDefault();
                    result.Subjects.Remove(subject);
                }
            }
        }


    }
}
