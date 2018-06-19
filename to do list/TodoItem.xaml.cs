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
    /// TodoItem.xaml 的互動邏輯
    /// </summary>
    public partial class TodoItem : UserControl
    {
        public string ItemName
        {
            get
            {
                return ItemNameTb.Text;
            }
            set
            {
                ItemNameTb.Text = value;
            }
        }

        public string date
        {
            get
            {
                string D = "Date1.Text" +"/" + "Date2.Text";
                return D ;
            }
        }

        public TodoItem()
        {
            InitializeComponent();
        }
        public string GetTaskName()
        {
            return ItemNameTb.Text;
        }


        private void Date1_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Date1.Clear();
        }

        private void Date2_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Date2.Clear();
        }

        private void ItemNameTb_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ItemNameTb.Clear();
        }

        private void Price_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Price.Clear();
        }

        private void Plus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Minus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
    }

