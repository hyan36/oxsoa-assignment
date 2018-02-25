using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOA.Assignment.Mooc.Models
{
    public class Course
    {
        public Guid ID { get; set; }
        
        public String Path => "/api/course/" + ID.ToString();

        public String Name { get; set; }

        public String Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}
