using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vacancy_Store.Data;
using Vacancy_Store.Helpers;
using Vacancy_Store.Models;

namespace Vacancy_Store.Services
{
    public class UserService
    {
        private readonly AppDbContext _context ;
        public UserService()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=LIGHT010191\SQLEXPRESS;Initial Catalog=Vacancy_Store;Integrated Security=true;TrustServerCertificate=True;");
            _context = new AppDbContext(optionsBuilder.Options);
        }

        public async Task<Company> AddNewCompany(Company company)
        {   
            _context.Companies.Add(company);

            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<bool> AddNewEmployee(JobApplicant employee)
        {
            _context.JobApplicants.Add(employee);

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AddNewVacancy(Vacancy vacancy, int id)
        {
            var res = await _context.Companies.Include("Vacancies").FirstOrDefaultAsync(c=>c.Id==id);
            res?.Vacancys.Add(vacancy);

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AddNewResume(Resume resume, int id)
        {
            var res = await _context.JobApplicants.Include("Resumes").FirstOrDefaultAsync(e => e.Id == id);
            res?.Resumes.Add(resume);

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<JobApplicant> GetEmployee(string login,string password)
        {
            return await _context.JobApplicants.Include("Resumes").FirstOrDefaultAsync(e => e.Login == login && e.Password ==password);
        }
        public async Task<Company> GetCompany(string login, string password)
        {            
            return await _context.Companies.Include("Vacancies").FirstOrDefaultAsync(c => c.Login == login && c.Password == password);
        }
        public async Task<ObservableCollection<Vacancy>> GetAllVacancies()
        {
            ObservableCollection<Vacancy> vac = new ObservableCollection<Vacancy>();
            var vacancies = new List<Vacancy>();           

            var com = await _context.Companies.ToListAsync();
            if(com.Count > 0) 
            {
                com.ForEach(c => {
                    if(c.Vacancys!=null) 
                    {
                        foreach (var item in c.Vacancys)
                        { vacancies.Add(item); }
                    }                   
                });
                vacancies.ForEach(v => vac.Add(v));
            }            
            return vac; 
        }
        public async Task<ObservableCollection<Resume>> GetAllResumes()
        {
            ObservableCollection<Resume> res = new ObservableCollection<Resume>();
            var resumes = new List<Resume>();

            var emp = await _context.JobApplicants.ToListAsync();
            if (emp.Count > 0)
            {
                emp.ForEach(r => {
                    if (r.Resumes != null)
                    {
                        foreach (var item in r.Resumes)
                        { resumes.Add(item); }
                    }
                });
                resumes.ForEach(r => res.Add(r));
            }
            return res;
        }
        public async Task<ObservableCollection<Resume>> GetMyResumes(int id)
        {
            var myResumes = new ObservableCollection<Resume>();
            var employee = await _context.JobApplicants.Include("Resumes").FirstOrDefaultAsync(e => e.Id == id);
            employee?.Resumes.ToList().ForEach(r=>myResumes.Add(r));
            return myResumes;
        }
        public async Task<ObservableCollection<Vacancy>> GetMyVacancies(int id)
        {
            var myVacancies = new ObservableCollection<Vacancy>();
            var company = await _context.Companies.Include("Vacancies").FirstOrDefaultAsync(c => c.Id == id);
            company?.Vacancys.ToList().ForEach(v => myVacancies.Add(v));
            return myVacancies;
        }
    }
}
