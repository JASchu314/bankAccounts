using System;
using System.ComponentModel.DataAnnotations;

namespace bankAccounts.Models{
    public class UserViewModel : BaseEntity{
        [Required(ErrorMessage = "Please enter your first name")]
        [RegularExpression("^[a-zA-Z]+$")]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters!")]
        [Display(Name = "First Name:")]
        public string firstName {get; set;}

        [Required(ErrorMessage ="Please enter your last name")]
        [RegularExpression("^[a-zA-Z]+$")]
        [MinLength(2, ErrorMessage="Last name must be at least 2 characters!")]
        [Display(Name = "Last Name:")]
        public string lastName{get; set;}
        
        [Required(ErrorMessage = "Please enter an E-mail")]
        [EmailAddress(ErrorMessage="Please enter a valid E-mail address")]
        [Display(Name = "E-mail:")]
        public string email {get; set;}

        [Required(ErrorMessage = "Please enter a password")]
        [Compare("passwordCheck", ErrorMessage = "Passwords must match!")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string password {get; set;}
          
        [Required(ErrorMessage = "Please confirm password")]
        [Compare("password", ErrorMessage = "Passwords must match!")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string passwordCheck {get; set;}
    }
}