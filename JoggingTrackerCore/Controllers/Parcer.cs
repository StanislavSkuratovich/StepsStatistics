using JoggingTrackerCore.Models;
using JoggingTrackerCore.ViewModels;
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

        public List<DayResultJson> ParseJsonStringWithDayNumberToDayResults(string jsonString, int dayNumber)//todo del
        {

            var dayResults = ConvertJsonStringToClassCollection<DayResultJson>(jsonString);
            dayResults.Select(c => { c.Day = dayNumber; return c; }).ToList();//changes day value in a whole collection
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
            string utf8String = Encoding.UTF8.GetString(bytes);
            var result = JsonConvert.DeserializeObject<List<T>>(utf8String);
            return result;
        } 
    }
}
