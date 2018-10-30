using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FestiFind.Models
{
    public class Friends
    {
       [Key]

        public int Friends_Id { get; set; }

        [ForeignKey("Follower")]
        public int FollowerId { get; set; }
        public User Follower { get; set; }



        [ForeignKey("UserFollowed")]
        public int UserFollowedId { get; set; }
        public User UserFollowed { get; set; }
    }
}