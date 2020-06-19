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
        public virtual DbSet<DayResult> DayResults { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Day> Days { get; set; }

        public JoggingTrackerContext()
            : base("name = DefaultConnection")
        {

        }
    }
}
