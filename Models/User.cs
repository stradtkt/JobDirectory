using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobDirectory.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int user_id {get;set;}
        public string name {get;set;}
        public string email {get;set;}
        public string password {get;set;}
        public string username {get;set;}
        public List<Jobs> Jobs {get;set;}
        public User()
        {
            Jobs = new List<Jobs>();
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
    }   
}