using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Travel: BaseEntity
    {
        public string CountryName { get; set; } 
        public string Title { get; set; }   
        public string Description { get; set; } 
        public string ThingsToSee { get; set; }
        public string TypicalCost { get; set; } 
        public string BudgetTips { get; set; }  
        public string RelatedGuides { get; set; }
        public string RelatedArticles { get; set; }
        public string Comment { get; set; }
        public string Url { get; set; }    
    }

}
