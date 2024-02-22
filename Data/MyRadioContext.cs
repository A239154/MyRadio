using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyRadio.Models;

namespace MyRadio.Data
{
    public class MyRadioContext : DbContext
    {
        public MyRadioContext (DbContextOptions<MyRadioContext> options)
            : base(options)
        {
        }

        public DbSet<MyRadio.Models.Radio> Radio { get; set; } = default!;
    }
}
