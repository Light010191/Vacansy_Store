using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy_Store.Helpers
{
    public interface IUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }      
    }
}
