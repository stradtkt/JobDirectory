using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobDirectory.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobDirectory.Controllers
{
    public class JobController : Controller 
    {
        private JobContext _context;
        public JobController(JobContext context)
        {
            _context = context;
        }
        JobDataAccessLayerController objectJob = new JobDataAccessLayerController();

        [HttpGet]
        [Route("api/Job/Index")]
        public IEnumerable<Jobs> Index()
        {
            return objectJob.GetAllJobs();
        }
        [HttpPost]
        [Route("api/Job/Create")]
        public int Create([FromBody] Jobs job)
        {
            return objectJob.AddJob(job);
        }

        [HttpGet]
        [Route("api/Job/Details/{id}")]
        public Jobs Details(int id)
        {
            return objectJob.GetJobData(id);
        }

        [HttpPut]
        [Route("api/Job/Edit")]
        public int Edit([FromBody]Jobs job)
        {
            return objectJob.UpdateJob(job);
        }

        [HttpDelete]
        [Route("api/Job/Delete/{id}")]
        public int Delete(int id)
        {
            return objectJob.DeleteJob(id);
        }

        [HttpGet]
        [Route("api/Job/GetUserList")]
        public IEnumerable<User> Details()
        {
            return objectJob.GetUsers();
        }
    }
}