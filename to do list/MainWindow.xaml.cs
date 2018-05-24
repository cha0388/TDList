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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            TodoItem item = new TodoItem();

            TodoList.Children.Add(item);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            string data = "";

            foreach (TodoItem item in TodoList.Children)
            {
                if(item.IsChecked == true)
                {
                    data += "+";
                }
                else
                {
                    data += "-";
                }

                data += "|"+item.ItemName + "\r\n";
            }

            System.IO.File.WriteAllText(@"C:\temp\data.txt", data);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\temp\data.txt");

            foreach(string line in lines)
            {
                string[] parts = line.Split('|');

                TodoItem item = new TodoItem();
                item.ItemName = parts[1];

                if(parts[0] == "+")
                {
                    item.IsChecked = true;
                }
                else
                {
                    item.IsChecked = false;
                }
                TodoList.Children.Add(item);
            }
;        }
    }
}
