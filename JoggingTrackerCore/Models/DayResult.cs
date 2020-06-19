using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JoggingTrackerCore.Models
{
    public class DayResult
    {
        [Key, DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Rank { get; set; }
        public bool IsFinished { get; set; }
        public int Steps { get; set; }
        public int CustomerId { get; set; }
        public int DayNumber { get; set; }

        public DayResult()
        {

        }
    }
}
