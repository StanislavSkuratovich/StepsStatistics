using JoggingTrackerCore.Models;
using JoggingTrackerCore.Models.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JoggingTrackerCore.Controllers
{
    public class Parcer
    {
        private readonly string AllNumbersFromString = @"(\d+)(?!.*\d)";        
        public Parcer()
        {
        }

        public List<DayResult> ParseJsonStringWithDayNumberToDayResults(string jsonString, int dayNumber)
        {

            var dayResults = ConvertJsonStringToClassCollection<DayResult>(jsonString);
            dayResults.Select(c => { c.Day = dayNumber; return c; }).ToList();
            return dayResults;
        }

        public int RetrieveNumberFromString(string toParce)
        {
            var temp = Regex.Match(toParce, AllNumbersFromString).Value;
            var numbers = Convert.ToInt32(temp);
            return numbers;
        }

        private List<T> ConvertJsonStringToClassCollection<T>(string jsonString) where T : class //todo async, 
        {
            
            byte[] bytes = Encoding.Default.GetBytes(jsonString);
            string utf8_String = Encoding.UTF8.GetString(bytes);
            var result = JsonConvert.DeserializeObject<List<T>>(utf8_String);
            return result;
        } 
    }
}
