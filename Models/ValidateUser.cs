using System;
using System.ComponentModel.DataAnnotations;

namespace FestiFind.Models
{

    public class ValidateUser
    {


        [Required(ErrorMessage = "Must Provide First Name")]
        [MinLength(3, ErrorMessage = "First Name Must Be Atleast 3 Characters")]
        [RegularExpression("^[a-zA-Z]*$")]
        public string FirstName{ get; set; }

        [Required(ErrorMessage = "Must Provide Last Name")]
        [MinLength(3, ErrorMessage = "First Name Must Be Atleast 3 Characters")]
        [RegularExpression("^[a-zA-Z]*$")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Must Provide Email")]
       
        [DataType(DataType.EmailAddress)]
        
        public string Email { get; set; }

        [MinLength(8)]
        [Required(ErrorMessage = "Please provide password")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*)(?=.*[$@$!%#?&])[A-Za-z$@$!%#?&].*$", ErrorMessage = "Password must have at least one letter, number and special character")]
        public string Password { get; set; }



        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string confirmpassword { get; set; }

  

    }

}