using System.ComponentModel.DataAnnotations;

namespace JobDirectory.Models
{
    public class JobsCategories 
    {
        [Key]
        public int job_category_id {get;set;}
        public int job_id {get;set;}
        public int category_id {get;set;}
        public JobCategory JobCategory {get;set;}
        public Jobs Jobs {get;set;}
    }
}