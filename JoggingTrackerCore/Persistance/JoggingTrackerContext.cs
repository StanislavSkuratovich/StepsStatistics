using JoggingTrackerCore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoggingTrackerCore.Persistance
{
    public class JoggingTrackerContext : DbContext
    {
        public DbSet<DayResult> DayResults { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public JoggingTrackerContext()
            : base("name = DefaultConnection")
        {

        }
    }
}
