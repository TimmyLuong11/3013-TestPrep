using System;
using System.Collections.Generic;
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

namespace WPF_Car
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int mileage, year;

            if (string.IsNullOrEmpty(txtBoxMake.Text))
            {
                MessageBox.Show("You did not enter in a valid make");
            }

            if (string.IsNullOrEmpty(txtBoxColor.Text))
            {
                MessageBox.Show("You did not enter in a valid color");
            }
            
            if (int.TryParse(txtBoxMileage.Text, out mileage) == false)
            {
                MessageBox.Show("You did not enter in a valid mileage");
            }

            if (int.TryParse(txtBoxYear.Text, out year) == false)
            {
                MessageBox.Show("You did not enter in a valid year");
            }
            ListBoxCar.Items.Add($"{txtBoxMake.Text} {txtBoxColor.Text} {year} {mileage}");
        }
    }
}
