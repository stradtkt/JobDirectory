using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobDirectory.Models
{
    public class JobCategory 
    {
        [Key]
        public int category_id {get;set;}
        public string category_name {get;set;}
        public string category_image {get;set;}
        public List<JobsCategories> JobsCategories {get;set;}
        public JobCategory()
        {
            JobsCategories = new List<JobsCategories>();
        }
    }
}