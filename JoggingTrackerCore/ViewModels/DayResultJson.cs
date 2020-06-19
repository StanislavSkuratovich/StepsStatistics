using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

using System.Text;
using Newtonsoft.Json;

namespace JoggingTrackerCore.ViewModels
{
    [DataContract]    
    public class DayResultJson
    {
        [DataMember]
        public int Rank { get; set; }
        [DataMember]
        public string User { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int Steps { get; set; }
        public int Day { get; set; }

        public DayResultJson()
        {

        }
    }
}
