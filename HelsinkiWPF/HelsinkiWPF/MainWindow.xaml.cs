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

namespace HelsinkiWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Eredmenyek> list = new List<Eredmenyek>();
        public MainWindow()
        {
            InitializeComponent();

            StreamReader r = new StreamReader("helsinki.txt");
            while (!r.EndOfStream)
            {
                list.Add(new Eredmenyek(r.ReadLine()));
            }
            r.Close();
            Datagrid.ItemsSource = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                list.RemoveAt(Datagrid.SelectedIndex);
                Datagrid.Items.Refresh();
            }
            catch (Exception)
            {
            }
        }

        public static int Pont(int helyezes)
        {
            if (helyezes == 1)
            {
                return 7;
            }
            else if (helyezes > 1 && helyezes < 7)
            {
                return 7 - helyezes;
            }
            else
            {
                return 0;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                 StreamWriter w = new StreamWriter("helsinki2.txt");
                foreach (var item in list)
                {
                    w.WriteLine($"{item.helyezes} {item.embred_db} {item.sportag} {item.versenyszam} {Pont(item.helyezes)}");
                }
                w.Close();
                MessageBox.Show("A mentés sikeres!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
