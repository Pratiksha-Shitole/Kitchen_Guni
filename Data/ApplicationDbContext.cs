using Kitchen_Guni.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen_Guni.Data
{
    public class ApplicationDbContext : IdentityDbContext<MyIdentityUser , MyIdentityRole ,Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
