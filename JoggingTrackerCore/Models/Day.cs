using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoggingTrackerCore.Models
{
   public class Day
    {
        [Key, DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Number { get; set; }
        public virtual List <DayResult> Results { get; set; }

        public Day()
        {
            Results = new List<DayResult>();
        }
    }
}
