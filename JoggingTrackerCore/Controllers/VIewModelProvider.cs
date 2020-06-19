using JoggingTrackerCore.Models;
using JoggingTrackerCore.Persistance;
using JoggingTrackerCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JoggingTrackerCore.Controllers
{
    public class ViewModelProvider
    {
        private JoggingTrackerCore.Persistance.JoggingTrackerContext _dbContext;

        public ViewModelProvider(JoggingTrackerContext dbContext)
        {
            _dbContext = dbContext;
        }

        //6) Выделить в таблице другим цветом тех пользователей, чьи лучшие или худшие резуль-таты отличаются 
        //    от среднего количества шагов за весь период(по этому пользователю) более чем на 20%.

        public List<CustomerViewTable> SetColorPropertyForCustomerTable(List<CustomerViewTable> tables, CustomerViewTable table)
        {
            foreach (var item in tables)
            {
                item.IsNeedBeMarked = (AreValuesDifferMoreThanOneFifth(table.AvgResult, item.BestResult)
                    | (AreValuesDifferMoreThanOneFifth(table.AvgResult, item.WorstResult)));
            }
            return tables;
        }


        //3) Обработка сохраненной статистики и ее графическое отображение может быть пред-ставлено в следующем виде
        //    (можно использовать график или диаграмму):
        public List<CustomerViewTable> CreateViewTablesForListCustomers(List<Customer> customers)
        {
            var tables = new List<CustomerViewTable>();
            foreach (var item in customers)
            {
                tables.Add(CreateCustomerViewTable(item));
            }
            return tables;
        }

        // 	Информация о пользователе(Фамилия и имя);
        //	Среднее количество пройденных шагов за весь период;
        //	Лучший результат за весь период;
        //	Худший результат за весь период.        

        private bool AreValuesDifferMoreThanOneFifth(int avg, int minOrMax)
        {
            var max = Math.Max(avg, minOrMax);
            var result = ((max - Math.Min(avg, minOrMax)) * 5) >= max;
            return result;
        }


        private CustomerViewTable CreateCustomerViewTable(Customer _customer)
        {
            var table = new CustomerViewTable { Customer = _customer };
            table = AddStepsPropertiesToCustomerTable(table);
            return table;
        }

        private CustomerViewTable AddStepsPropertiesToCustomerTable(CustomerViewTable table)
        {
            int[] steps = table.Results.Select(i => i.Steps).ToArray();
            int sumSteps = 0, maxsteps = 0, minSteps = 0;
            for (int i = 0; i <= steps.Count(); i++)
            {
                var currentQuantity = steps[i];
                sumSteps += currentQuantity;
                maxsteps = Math.Max(maxsteps, currentQuantity);
                minSteps = Math.Min(maxsteps, currentQuantity);
            }
            table.AvgResult = sumSteps / steps.Count();
            table.WorstResult = maxsteps;
            table.BestResult = maxsteps;
            return table;
        }     
    }

}
