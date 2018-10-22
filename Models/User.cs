using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FestiFind.Models
{
    public class User
    {

        [Key]
        public int User_Id { get; set; }

        
        
   

        public string FirstName{ get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }
       
       public string Tribe{ get ; set ;}

       
       
        
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
       
       
        public DateTime created_at { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
       
        public DateTime updated_at { get; set; }





    }
}
