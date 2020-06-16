using JoggingTrackerCore.Models.DAL.Interfaces;
using JoggingTrackerCore.Models.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace JoggingTrackerCore.Models.DAL.Repositories
{
    class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(JoggingTrackerCore.Persistance.JoggingTrackerContext context) : base(context)
        {

        }
    }
}
