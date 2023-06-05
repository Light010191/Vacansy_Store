using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy_Store.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string NameVacancy { get; set; }
        public string Salary { get; set; }
        public string RequiredWorkExperience { get;set; }
        public string AboutVacansy { get; set; }
    }
}
