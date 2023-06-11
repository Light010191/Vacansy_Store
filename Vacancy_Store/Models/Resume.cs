using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy_Store.Models
{
    public class Resume
    {       
        public int Id { get; set; }
        public string VacancyName { get; set; }
        public string AboutMe { get; set; }        
        public string LastPlaceOfWork { get; set; }
        public string DesiredSalary { get; set; }
        public string Img { get; set; }
    }
}
