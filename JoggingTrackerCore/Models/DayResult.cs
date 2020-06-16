using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

using System.Text;
using Newtonsoft.Json;

namespace JoggingTrackerCore.Models
{
    [DataContract]

    
    public class DayResult
    {
        [Key, DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataMember]
        public int Rank { get; set; }
        [DataMember]
        public string User { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int Steps { get; set; }
        public Customer Customer { get; set; }//toto data annotation
        
        public int Day { get; set; }//todo



    }
}
