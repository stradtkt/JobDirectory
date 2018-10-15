using JobDirectory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks; 

namespace JobDirectory.Controllers
{
    public class JobDataAccessLayerController : Controller
    {
        private JobContext _context;
        public JobDataAccessLayerController(JobContext context)
        {
            _context = context;
        }

        public JobDataAccessLayerController()
        {
        }

        public IEnumerable<Jobs> GetAllJobs()
        {
            try
            {
                return _context.jobs.ToList();
            }
            catch
            {
                throw;
            }
        }
        public int AddJob(Jobs job)
        {
            try
            {
                _context.jobs.Add(job);
                _context.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        public int UpdateJob(Jobs job)
        {
            try
            {
                _context.Entry(job).State = EntityState.Modified;
                _context.SaveChanges();
                return 1;
            }
            catch 
            {
                throw;
            }
        }

        public Jobs GetJobData(int id)
        {
            try
            {
                Jobs job = _context.jobs.Find(id);
                return job;
            }
            catch
            {
                throw;
            }
        }

        public int DeleteJob(int id)
        {
            try
            {
                Jobs job = _context.jobs.Find(id);
                _context.jobs.Remove(job);
                _context.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users = (from userList in _context.users select userList).ToList();
            return users;
        }
    }
}