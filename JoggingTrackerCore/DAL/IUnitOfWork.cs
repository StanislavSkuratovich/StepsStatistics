using JoggingTrackerCore.Models.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoggingTrackerCore.Models.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IDayResultReposiry DayResults { get; }
        ICustomerRepository Customers { get; }
        int Complete();
    }
}
