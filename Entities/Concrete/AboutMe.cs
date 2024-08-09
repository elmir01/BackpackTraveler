using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AboutMe:BaseEntity
    {
        public string Title {  get; set; }  
        public string Description { get; set; }
        public string Url { get; set; }

    }
}
