using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoWebApi.Models;

namespace TodoWebApi.Data
{
    public class WorkContext : IdentityDbContext<ApplicationUser>
    {
        public WorkContext(DbContextOptions<WorkContext> options) : base(options)
        {

        }
        public DbSet<Todo> TodoTable { get; set; }
    }
}
