using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Vacancy_Store.ViewModels
{
    public class ResumeVM
    {
        private static ResumeVM _context;
        public static ResumeVM Context => _context ?? (_context = new ResumeVM());

        public ResumeVM() 
        {
            resumes = new List<Models.Resume>()
            {
                new Models.Resume() {Id = 1, VacancyName="Программист", AboutMe=" Рассказ о программисте", LastPlaceOfWork="Слесарь", DesiredSalary="300000", Img="test1"},
                new Models.Resume() {Id = 2, VacancyName="Слесарь", AboutMe=" Рассказ о Слесаря", LastPlaceOfWork="Слесарь", DesiredSalary="50000", Img="test2"},
                new Models.Resume() {Id = 3, VacancyName="Фермер", AboutMe=" Рассказ о Фермере", LastPlaceOfWork="Слесарь", DesiredSalary="40000", Img="test3"}
            };
            ResumesContext = new List<Models.Resume>().ToList();

        }

        private List<Models.Resume> resumes;
        public List<Models.Resume> ResumesContext { get; set; }
    }
}
