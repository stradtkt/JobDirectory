using Microsoft.EntityFrameworkCore;
 
namespace JobDirectory.Models
{
    public class JobContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public JobContext(DbContextOptions<JobContext> options) : base(options) { }

        public DbSet<User> users {get;set;}
        public DbSet<JobCategory> job_categories {get;set;}
        public DbSet<Jobs> jobs {get;set;}
        public DbSet<JobsCategories> jobs_categories {get;set;}
    }
}