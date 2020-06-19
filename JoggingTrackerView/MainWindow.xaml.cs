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
using JoggingTrackerCore.Persistance;
using System.Windows.Controls.DataVisualization;

namespace JoggingTrackerView
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    ///https://stackoverflow.com/questions/46056350/wpf-toolkit-how-to-properly-add-series 

    public partial class MainWindow : Window
    {
        private DataProvider _dataProvider;
        private ViewModelProvider _modelProvider;
        private Parcer _parcer; //todo adda interface instead of a class
        private JoggingTrackerContext _dbContext;
        public MainWindow()
        {
            _dbContext = new JoggingTrackerContext();
            //InitializeComponent();
            _parcer = new Parcer();
            _dataProvider = new DataProvider(_dbContext);
            _modelProvider = new ViewModelProvider(_dbContext);
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
            
            foreach (var item in jsonStrings)//todo move it to controller
            {            
                if (_dbContext.Days.Any(i => i.Number == item.Item2) == false)               
                {
                    var dayResultsJson = _parcer.ParseJsonStringWithDayNumberToDayResults(item.Item1, item.Item2);
                    _dataProvider.AddDayResults(dayResultsJson);

                }
                else
                {
                    throw new NotImplementedException();
                }

            }
            MessageBox.Show("Data is loaded");
        }

        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            _dataProvider.ClearData();
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

        private void ClearData_Click_1(object sender, RoutedEventArgs e)
        {
            _dataProvider.ClearData();
            MessageBox.Show("Data is cleaned");
        }
    }
}
