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

        private void Addbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 新增項目
            TodoItem item = new TodoItem();

            // 將項目加入名單
            TodoList.Children.Add(item);

            //自動輸入日期
            item.date.Text = DateTime.Now.ToString("M / dd");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            // 新增清單datas
            List<string> datas = new List<string>();

            // 轉換每一個項目
            foreach (TodoItem item in TodoList.Children)
            {
                // 設空字串data
                string data = "";

                // 每一種資料以"|"區隔加入data字串
                data += item.date.Text + "|" + item.ItemNameTb.Text + "|" + item.Price.Text;

                // 將data放入清單datas
                datas.Add(data);
            }

            // 將datas的內容存到指定路徑
            System.IO.File.WriteAllLines(@"C:\temp\01\data.txt", datas);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(@"C:\temp\01\data.txt") == false)
            {
                // 預設在C槽有ㄧ個名為"temp"的資料夾
                string activeDir = @"C:\temp";

                // 設新檔案將會放入"temp"中的"01"
                string newPath = System.IO.Path.Combine(activeDir, "01");

                // 若上兩行的路徑不存在，則自動創建
                System.IO.Directory.CreateDirectory(newPath);

                // 預設檔名為data.txt
                string FileName = "data" + ".txt";

                // 新檔案路徑為C:\temp\01\data.txt
                string filePathOne = System.IO.Path.Combine(newPath, FileName);

                // 在C:\temp\01內創建新檔案data.txt
                System.IO.File.Create(filePathOne);
            }
            // 將檔案data.txt的內容轉為陣列
            string[] lines = System.IO.File.ReadAllLines(@"C:\temp\01\data.txt");
            int M = 0;

            // 分析檔案內容
            foreach (string line in lines)
             {

                // 以｜作為分隔拆開每一行
                string[] parts = line.Split('|');


                // 建立 TodoItem
                TodoItem item = new TodoItem();

                // 分別放入項目對應的位置，第一部分為日期
                item.date.Text = parts[0];

                // 第二部分為項目內容
                item.ItemNameTb.Text = parts[1];

                // 第三部分為價格
                item.Price.Text = parts[2];

                // 放到清單中
                TodoList.Children.Add(item);

                M += item.Pri;
            }

            Money.Text = M.ToString();
        }
    

        
        private void Window_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            // 設一個空變數
            int M = 0;

            // 取得每個項目的價錢
            foreach (TodoItem item in TodoList.Children)
            {
                // 將每個項目的價錢全部加起來
                M += item.Pri;
            }

            // 寫到總支出
            Money.Text = M.ToString();
        }

        private void close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }

}
