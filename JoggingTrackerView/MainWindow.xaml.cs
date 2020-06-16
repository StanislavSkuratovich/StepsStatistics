using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JoggingTrackerCore;
using JoggingTrackerCore.Controllers;
using JoggingTrackerCore.Models;
using JoggingTrackerCore.Models.DAL;
using JoggingTrackerCore.Models.Persistance;

namespace JoggingTrackerView
{
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUnitOfWork _context;
        private DataProvider _provider;
        private JoggingTrackerCore.Controllers.Parcer _parcer; //todo adda interface instead of a class
        public MainWindow()
        {
            InitializeComponent();
            _context = new UnitOfWork(new JoggingTrackerCore.Persistance.JoggingTrackerContext());//add DI
            _parcer = new JoggingTrackerCore.Controllers.Parcer();
            _provider = new JoggingTrackerCore.Controllers.DataProvider();
        }

        private void LoadFiles_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog
            {
                Multiselect = true,
                DefaultExt = ".json",
                Filter = "JSON Files (*.json)|*.json|DOC Files (*.doc)|*.doc|DOCX Files (*.docx)|*.docx"
            };
            bool? fileLoaded = dialog.ShowDialog();
            var filenames = dialog.FileNames.ToList();
            var jsonStrings = LoadJsonStringsWithDay(filenames);
            foreach (var item in jsonStrings)
            {
                //if (_context.DayResults.GetAll().Where(result => result.Day.Equals(item.Item2)).Equals(null))//to do add class day
                {
                    List<DayResult> dayResults = _parcer.ParseJsonStringWithDayNumberToDayResults(item.Item1, item.Item2);
                    _provider.AddDayResults(dayResults);
                    //_context.DayResults.Add(dayResults);
                    //_context.Complete();
                    
                }
                //else
                //{
                //    throw new NotImplementedException();
                //}

            }
        }

        private List<(string, int)> LoadJsonStringsWithDay (List<string> patchToFile)
        {                       
            var result = new List<(string, int)>();
            if (patchToFile.Equals(null))
            {
                throw new NotImplementedException();
            }
            else
            {
                foreach (var item in patchToFile)
                {
                    using (StreamReader stream = new StreamReader(item, System.Text.Encoding.Default)) //todo async
                    {
                        int dayNumber = _parcer.RetrieveNumberFromString(item);
                        var jsonString = ((stream.ReadToEnd()));//todo trycatch
                        result.Add((jsonString, dayNumber));
                    }
                }                
            }
            return result;
        }
    }
}
