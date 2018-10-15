using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobDirectory.Models
{
    public abstract class BaseEntity 
    {
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
    }
    public class RegisterUser : BaseEntity
    {
        [Key]
        public int user_id {get;set;}

        [Required(ErrorMessage="First Name is required")]
        [Display(Name="Name")]
        public string name {get;set;}

        [Required(ErrorMessage="Email is required")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email")]
        public string email {get;set;}
        [Required]
        [Display(Name="Username")]
        public string username {get;set;}

        [Required(ErrorMessage="Password is required")]
        [MinLength(4, ErrorMessage="A minimum length of 4")]
        [MaxLength(20, ErrorMessage="A maximum length of 20")]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string password {get;set;}

        [Required(ErrorMessage="Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("password")]
        [Display(Name="Confirm Password")]
        public string confirm {get;set;}
    }

    public class LoginUser : BaseEntity
    {
        [Required(ErrorMessage="Email is required")]
        [EmailAddress(ErrorMessage="This is an email field")]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email")]
        public string email {get;set;}

        [Required(ErrorMessage="Password is required")]
        [MinLength(4, ErrorMessage="A minimum length of 4")]
        [MaxLength(20, ErrorMessage="A maximum length of 20")]
        [DataType(DataType.Password)]
        [Display(Name="Password")]

        public string password {get;set;}
    }
}