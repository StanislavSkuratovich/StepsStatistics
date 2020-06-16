using JoggingTrackerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoggingTrackerCore.ViewModels
{
    public class CustomerViewTable
    {
        public Customer Customer { get; set; }
        public List<DayResult> Results { get; set; }
        public int BestResult { get; set; }
        public int WorstResult { get; set; }
        public int AvgResult { get; set; }
        public bool IsNeedBeMarked { get; set; }
    }
}
