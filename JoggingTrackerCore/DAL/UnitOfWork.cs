using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JoggingTrackerCore.Models.DAL.Interfaces;
using JoggingTrackerCore.Models.DAL.Repositories;
using JoggingTrackerCore.Persistance;

namespace JoggingTrackerCore.Models.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JoggingTrackerContext _context;
        public IDayResultReposiry DayResults { get; private set; }
        public ICustomerRepository Customers { get; private set; }

        public UnitOfWork(JoggingTrackerCore.Persistance.JoggingTrackerContext context)
        {
            _context = context;
            Customers = new CustomerRepository(this._context);
            DayResults = new DayResultRepository(this._context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
