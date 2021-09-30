using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace WPF_CarFilter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Car> cars = new List<Car>();
        public MainWindow()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("RandCar1.csv").Skip(1);

            foreach (var item in lines)
            {
                cars.Add(new Car(item));
            }

            PopulateListBox(cars);
            PopulateComboYear();
            PopulateComboMake();
            PopulateComboColor();

            comboBoxYear.SelectedIndex = 0;
            comboBoxMake.SelectedIndex = 0;
            comboBoxColor.SelectedIndex = 0;
        }

        private void PopulateListBox(List<Car> cars)
        {
            ListBoxCar.Items.Clear();
            foreach (var item in cars)
            {
                ListBoxCar.Items.Add(item);
            }
        }

        private void PopulateComboYear()
        {
            comboBoxYear.Items.Add("All");
            comboBoxYear.SelectedItem = 0;
            foreach (var item in cars)
            {
                if (!comboBoxYear.Items.Contains(item.Year))
                {
                    comboBoxYear.Items.Add(item.Year);
                }
            }
        }

        private void PopulateComboMake()
        {
            comboBoxMake.Items.Add("All");
            comboBoxMake.SelectedItem = 0;
            foreach (var item in cars)
            {
                if (!comboBoxMake.Items.Contains(item.Make))
                {
                    comboBoxMake.Items.Add(item.Make);
                }
            }
        }

        private void PopulateComboColor()
        {
            comboBoxColor.Items.Add("All");
            comboBoxColor.SelectedItem = 0;
            foreach (var item in cars)
            {
                if (!comboBoxColor.Items.Contains(item.Color))
                {
                    comboBoxColor.Items.Add(item.Color);
                }
            }
        }

        private void comboBoxYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpatedFilter();
        }


        private void comboBoxMake_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpatedFilter();
        }

        private void comboBoxColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpatedFilter();
        }

        private void UpatedFilter()
        {
            if (comboBoxYear.SelectedValue is null || comboBoxMake.SelectedValue is null || comboBoxColor.SelectedValue is null)
            {
                return;
            }

            List<Car> filteredCars = cars;
            filteredCars = filteredYear(filteredCars);
            filteredCars = filteredMake(filteredCars);
            filteredCars = filteredColor(filteredCars);
            PopulateListBox(filteredCars);
        }

        private List<Car> filteredYear(List<Car> cars)
        {
            string year = comboBoxYear.SelectedValue.ToString();
            List<Car> filteredCars = new List<Car>();
            foreach (var item in cars)
            {
                if (year.ToLower() == "all")
                {
                    filteredCars.Add(item);
                }
                else if (Convert.ToString(item.Year).Contains(year))
                {
                    filteredCars.Add(item);
                }
            }
            return filteredCars;
        }

        private List<Car> filteredMake(List<Car> cars)
        {
            string make = comboBoxMake.SelectedValue.ToString();
            List<Car> filteredCar = new List<Car>();
            foreach (var item in cars)
            {
                if (make.ToLower() == "all")
                {
                    filteredCar.Add(item);
                }
                else if (item.Make.Contains(make))
                {
                    filteredCar.Add(item);
                }
            }
            return filteredCar;
        }

        private List<Car> filteredColor(List<Car> cars)
        {
            string color = comboBoxColor.SelectedValue.ToString();
            List<Car> filteredCar = new List<Car>();
            foreach (var item in cars)
            {
                if (color.ToLower() == "all")
                {
                    filteredCar.Add(item);
                }
                else if (item.Color.Contains(color))
                {
                    filteredCar.Add(item);
                }
            }
            return filteredCar;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            comboBoxColor.SelectedIndex = 0;
            comboBoxMake.SelectedIndex = 0;
            comboBoxYear.SelectedIndex = 0;
        }
    }
}
