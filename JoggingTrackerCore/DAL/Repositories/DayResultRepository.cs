using JoggingTrackerCore.Models.DAL.Interfaces;
using JoggingTrackerCore.Models.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JoggingTrackerCore.Models.DAL.Repositories
{
    public class DayResultRepository : Repository<DayResult>, IDayResultReposiry
    {
        public DayResultRepository(JoggingTrackerCore.Persistance.JoggingTrackerContext context) : base(context)
        {
        }
        //public void Add(List<>)
    }
}
