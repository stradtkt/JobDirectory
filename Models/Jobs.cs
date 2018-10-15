using System;
using System.Collections.Generic;

namespace JobDirectory.Models
{
    public class Jobs : BaseEntity
    {
        public int job_id {get;set;}
        public string job_title {get;set;}
        public string job_desc {get;set;}
        public string extra {get;set;}
        public int time_length {get;set;}
        public int user_id {get;set;}
        public User User {get;set;}
        public List<JobsCategories> JobsCategories {get;set;}
        public Jobs()
        {
            JobsCategories = new List<JobsCategories>();
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
    }
}