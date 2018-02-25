using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOA.Assignment.Mooc.Models
{
    public class Subject
    {
        public Guid ID { get; set; }
        
        public String Path => "/api/subject/" + ID.ToString();

        public String Name { get; set; }

        public String Description { get; set; }
       
    }
}
