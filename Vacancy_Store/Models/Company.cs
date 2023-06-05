using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy_Store.Helpers;

namespace Vacancy_Store.Models
{
    public class Company : IUser
    {
        public int Id { get; set; }
        public string NameCompany { get; set; }
        public string AboutCompany { get; set; }
        public string Img { get;set; }
        public ICollection<Vacancy> Vacancys { get;set;}
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
