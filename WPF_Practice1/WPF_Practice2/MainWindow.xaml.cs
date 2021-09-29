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

namespace WPF_Practice2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ClassPopulation> cp = new List<ClassPopulation>();
        public MainWindow()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("RandData1.csv");

            foreach (var item in lines)
            {
                cp.Add(new ClassPopulation(item));
            }

            PopulateListBox();
            PopulateComboBox(cp);
        }

        private void PopulateListBox()
        {
            listBoxOwner.Items.Clear();
            for (int i = 1; i < cp.Count; i++)
            {
                listBoxOwner.Items.Add(cp[i]);
            }
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            List<ClassPopulation> filteredCP = new List<ClassPopulation>();
            if (comboBox.SelectedValue is null)
            {
                return;
            }
            filteredCP = FilteredList(cp);
            PopulateComboBox(filteredCP);
        }

        private List<ClassPopulation> FilteredList(List<ClassPopulation> cp)
        {
            string country = comboBox.SelectedValue.ToString();
            List<ClassPopulation> fCP = new List<ClassPopulation>();
            foreach (var item in cp)
            {
                if (country.ToLower() == "all")
                {
                    fCP.Add(item);
                }
                else if (item.Country.Contains(country))
                {
                    fCP.Add(item);
                }
            }
            return fCP;
        }

        private void PopulateComboBox(List<ClassPopulation> cp)
        {
            comboBox.Items.Add("All");
            comboBox.SelectedItem = 0;

            for (int i = 1; i < cp.Count; i++)
            {
                if (!comboBox.Items.Contains(cp[i].Country))
                {
                    comboBox.Items.Add(cp[i].Country);
                }
            }
        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            comboBox.SelectedItem = 0;
        }

        private void listBoxOwner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
