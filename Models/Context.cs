using System;
using Microsoft.EntityFrameworkCore;

namespace FestiFind.Models{

    public class FContext : DbContext
    
    {

        public FContext(DbContextOptions<FContext> options) : base(options) { }
        public DbSet<User> user { get; set; }

        public DbSet<Friends> friends { get; set; }


    }

}