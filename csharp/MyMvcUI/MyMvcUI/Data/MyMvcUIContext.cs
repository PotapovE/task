using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMvcUI.Models;

namespace MyMvcUI.Data
{
    public class MyMvcUIContext : DbContext
    {
        public MyMvcUIContext (DbContextOptions<MyMvcUIContext> options)
            : base(options)
        {
        }

        public DbSet<MyMvcUI.Models.TestModel>? TestModel { get; set; }
    }
}
