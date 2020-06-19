using JoggingTrackerCore.Models;
using JoggingTrackerCore.Persistance;
using JoggingTrackerCore.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace JoggingTrackerCore.Controllers
{
    public class DataProvider
    {
        private JoggingTrackerCore.Persistance.JoggingTrackerContext _dbContext;

        public DataProvider(JoggingTrackerContext context)
        {
            _dbContext = context;
        }

        public void ClearData()
        {
            _dbContext.Customers.RemoveRange(_dbContext.Customers);
            _dbContext.Days.RemoveRange(_dbContext.Days);

            _dbContext.SaveChanges();
        }

        public void AddDayResults(List<DayResultJson> results)
        {
            var resul = results.First();
            var day = RetrieveOrCreateDay(resul);
            foreach (var item in results)
            {
                var customer = RetrieveOrCreateCustomer(item);
                var result = MapJsonToDayResult(item);
                result.CustomerId = customer.Id;
                result.DayNumber = day.Number;
                _dbContext.DayResults.Add(result);
                _dbContext.SaveChanges();
                var savedResult = _dbContext.DayResults.Where(i => i.DayNumber == day.Number).Where(j => j.CustomerId == customer.Id).Single();
                day.Results.Add(savedResult);
                customer.DayResults.Add(savedResult);
                _dbContext.SaveChanges();
                //var cavedCustomer = _dbContext.Customers.Find(customer.Id);
                //var save = _dbContext.Days.Find(day.Id).Results;
                //var savedDay = _dbContext.Days.Find(day.Id).Results.Count();
            }
        }

        private DayResult MapJsonToDayResult(DayResultJson json)
        {
            string finishedJsonTrigger = "Finished";
            var result = new DayResult { Rank = json.Rank, Steps = json.Steps };
            result.IsFinished = json.Status.Equals(finishedJsonTrigger);
            return result;
        }

        private Customer RetrieveOrCreateCustomer(DayResultJson dayResult)
        {
            var customer = new Customer();
            if (!_dbContext.Customers.Any(i => i.Name == (dayResult.User)))
            {
                _dbContext.Customers.Add(new Customer { Name = dayResult.User });
                _dbContext.SaveChanges();
                customer = _dbContext.Customers.Single(i => i.Name.Equals(dayResult.User));
                return customer;
            }
            customer = _dbContext.Customers.Single(i => i.Name == dayResult.User);
            return customer;
        }

        private Day RetrieveOrCreateDay(DayResultJson dayResult)
        {
            var day = new Day();
            var test = (!_dbContext.Days.Any(i => i.Number.Equals(dayResult.Day)));
            if (!_dbContext.Days.Any(i => i.Number.Equals(dayResult.Day)))
            {
                _dbContext.Days.Add(new Day { Number = dayResult.Day });
                _dbContext.SaveChanges();
                day = _dbContext.Days.Single(i => i.Number == (dayResult.Day));
                return day;
            }
            day = _dbContext.Days.Where(i => i.Number.Equals(dayResult.Day)).SingleOrDefault();
            return day;
        }
    }
}
