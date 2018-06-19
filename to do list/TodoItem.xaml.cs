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
        int A = 0;
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

        public string date1
        {
            get
            {
                return Date1.Text;
            }
        }

        public string date2
        {
            get
            {
                return Date2.Text;
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

       
        public int Price2 = 0;

        public string Price1
        {
            get
            {
                return Price.Text;
            }
            set
            {
                Price.Text = value;
            }

        }

        public bool IsPlus
        {
            get
            {
                if (A==0)
                    return false;
                else
                    return true;
            }

        }

        private void Plus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            A = 0;
        }

        private void Minus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            A = 1;
        }
    }
    }

