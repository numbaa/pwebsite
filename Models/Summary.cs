using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pwebsite.Models
{
    public class Summary
    {

        public int ID { get; set; }

        public string TitleURL { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime ModifyDate { get; set; }


    }
}
