using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;


namespace JoggingTrackerCore.Models
{
    
    public class Customer
    {
        [Key, DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public string Name { get; set; }
        public virtual List<DayResult> DayResults { get; set; }

        public Customer()
        {
            DayResults = new List<DayResult>();
        }
    }


}
