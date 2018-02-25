using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SOA.Assignment.Mooc.Models;
using SOA.Assignment.Mooc.Data;

namespace SOA.Assignment.Mooc.Controllers
{
    [Route("api/[controller]")]
    public class SubjectController : Controller
    {

        protected Database db;

        public SubjectController()
        {
            db = Database.Instance;
        }
        
        /// <summary>
        /// get all subjects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Subject> Get()
        {
            return db.Subjects;
        }

        /// <summary>
        /// get a specific subject
        /// </summary>
        /// <param name="id">subject id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Subject Get(string id)
        {
            var result =  db.Subjects.Where(o => o.ID == new Guid(id)).FirstOrDefault();           
            return result;
        }

        /// <summary>
        /// delete a specific subject
        /// </summary>
        /// <param name="id">subject id</param>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var subject = db.Subjects.Where(o => o.ID == new Guid(id)).FirstOrDefault();
            db.Subjects.Remove(subject);
        }

        /// <summary>
        /// create a new subject
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public Subject Post([FromBody]Subject value)
        {
            var isNew = true;
            for (int i = 0; i < db.Subjects.Count; i++)
            {
                if (db.Subjects[i].ID == value.ID)
                {
                    db.Subjects[i] = value;
                    isNew = false;
                }
            }
            if (isNew)
            {
                value.ID = new Guid();
                db.Subjects.Add(value);
            }
            return value;
        }

        /// <summary>
        /// update a subject
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Subject Put(string id, [FromBody]Subject value)
        {
            for (int i = 0; i< db.Subjects.Count; i ++)
            {
                if (db.Subjects[i].ID == new Guid(id))
                {
                    db.Subjects[i].Name = value.Name;
                    db.Subjects[i].Description = value.Description;
                }
            }
           
            return value;
        }
    }
}
