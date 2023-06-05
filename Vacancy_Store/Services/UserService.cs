using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly AppDbContext _context;
        public UserService()
        {
            _context = new AppDbContext();
        }

        public async Task<bool> AddNewCompany(Company company)
        {   
            _context.Companies.Add(company);

            await _context.SaveChangesAsync();
            return true;
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
        public async Task<JobApplicant> GetEmployee(int id)
        {
            return await _context.JobApplicants.Include("Resumes").FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<Company> GetCompany(int id)
        {            
            return await _context.Companies.Include("Vacancies").FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<ObservableCollection<Vacancy>> GetAllVacancies()
        {
            var vacancies = new ObservableCollection<Vacancy>();
            await _context.Companies.Include("Vacancies").ForEachAsync(c=> c.Vacancys.ToList().ForEach( v=>vacancies.Add(v)));
            return vacancies; 
        }
        public async Task<ObservableCollection<Resume>> GetAllResumes()
        {
            var resumes = new ObservableCollection<Resume>();
            await _context.JobApplicants.Include("Resumes").ForEachAsync(e => e.Resumes.ToList().ForEach(r => resumes.Add(r)));
            return resumes;
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
