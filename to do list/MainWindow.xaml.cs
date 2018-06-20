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

namespace to_do_list
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        int M;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Count()
        {
            foreach (TodoItem item in TodoList.Children)
            {
                int M =int.Parse(item.Price.Text);
            }
            M += M;

            Money.Text = M.ToString();
        }

        private void Addbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TodoItem item = new TodoItem();

            TodoList.Children.Add(item);

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            List<string> datas = new List<string>();

            string line = "";

            foreach (TodoItem item in TodoList.Children)
            {

                line += item.D1 +"|" + item.D2 + "|" + item.ItemName +"|" + item.Pri + "\r\n";
            }

            System.IO.File.WriteAllLines(@"C:\temp\data.txt", datas);
        }

     

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string FileName = "data.txt";

            if (System.IO.File.Exists(FileName))
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\temp\data.txt");

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');

                    TodoItem item = new TodoItem();
                    item.ItemName = parts[1];

                    parts[0] = item.D1;
                    parts[1] = item.D2;
                    parts[2] = item.ItemName;
                    parts[3] = item.Pri;

                    TodoList.Children.Add(item);
                }
            }
;        }
    }
}
