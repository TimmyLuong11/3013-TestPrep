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

namespace WPF_Practice1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<PopulateClass> pc = new List<PopulateClass>();
            var lines = File.ReadAllLines("RandData.csv");

            foreach (var item in lines)
            {
                pc.Add(new PopulateClass(item));
            }

            for (int i = 1; i < pc.Count; i++)
            {
                listBoxOwner.Items.Add(pc[i]);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopulateClass popClass = (PopulateClass)listBoxOwner.SelectedItem;
            txtBoxFirstName.Text = popClass.FirstName;
            txtBoxLastName.Text = popClass.LastName;
            txtBoxEmail.Text = popClass.Email;
            txtBoxPhone.Text = popClass.Phone;
            imgBox.Source = new BitmapImage(new Uri(popClass.Photo));
        }
    }
}
