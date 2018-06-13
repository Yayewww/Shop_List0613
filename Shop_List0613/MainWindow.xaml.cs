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

namespace Shop_List0613
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        //給予總和初值。
        public int Total_Cost = 0;
        public int item_Cost = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        //按下關閉視窗
        private void CloseBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        //按住拖曳視窗
        private void BaseGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        //按下新增項目
        private void Add_Btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Shop_item _Item = new Shop_item();
            _Item.item_Content = "New";
            _Item.DeleteItem += new EventHandler(DeleteItem);
            _Item.PlusAll += new EventHandler(PlusAll);

            //放入清單中
            TaskPanel.Children.Add(_Item);

            //加總費用
            int item_Cost = int.Parse(_Item.item_value);
            Total_Cost += item_Cost;
            Cost_Number.Text = Total_Cost.ToString();
        }

        //輸入錢
        private void PlusAll(object sender, EventArgs e)
        {
            CaoMoney();
        }


        // 刪除事件
        private void DeleteItem(object sender, EventArgs e)
        {
            //移除項目
            TaskPanel.Children.Remove((Shop_item)sender);
            //算錢
            CaoMoney();
        }

        //關閉視窗
        private void Window_Closed(object sender, EventArgs e)
        {
            //將項目文字存成文字檔
            string datas = "";
            foreach(Shop_item _Item in TaskPanel.Children)
            {
                datas += _Item.item_Date + "|" + _Item.item_Content+ ","+_Item.item_value + "\r\n";
            }

            System.IO.File.WriteAllText(@"C:\Buy_temp\data.txt", datas);
        }

        //開啟視窗後讀取事件
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            //開檔
            string[] lines = System.IO.File.ReadAllLines(@"C:\Buy_temp\data.txt");         
            //讀取每一行
            foreach (string line in lines)
            {
                //用" | " 符號拆開
                string[] parts = line.Split('|',',');//將"|"前後分成[0]跟[1]","分[2]

                //建立Shop_item
                Shop_item _Item = new Shop_item();
                _Item.item_Date = parts[0];
                _Item.item_Content = parts[1];
                _Item.item_value = parts[2];
                _Item.DeleteItem += new EventHandler(DeleteItem);
                _Item.PlusAll += new EventHandler(PlusAll);
                //放到清單中
                TaskPanel.Children.Add(_Item);

                //將費用文字轉換成數值
                int item_Cost = int.Parse(_Item.item_value);
                Total_Cost += item_Cost;
                Cost_Number.Text = Total_Cost.ToString();
            }
            
        }

        void CaoMoney()
        {
            //將項目文字存成文字檔
            string datas = "";
            foreach (Shop_item _Item in TaskPanel.Children)
            {
                datas += _Item.item_Date + "|" + _Item.item_Content + "," + _Item.item_value + "\r\n";
            }

            System.IO.File.WriteAllText(@"C:\Buy_temp\data.txt", datas);

            //開檔
            string[] lines = System.IO.File.ReadAllLines(@"C:\Buy_temp\data.txt");
            //讀取每一行
            foreach (string line in lines)
            {
                //用" | " 符號拆開
                string[] parts = line.Split('|', ',');//將"|"前後分成[0]跟[1]","分[2]

                //建立Shop_item
                Shop_item _Item = new Shop_item();
                _Item.item_Date = parts[0];
                _Item.item_Content = parts[1];
                _Item.item_value = parts[2];
                _Item.DeleteItem += new EventHandler(DeleteItem);
                _Item.PlusAll += new EventHandler(PlusAll);

                //將每一行的value 轉成int*****BUGBOYS
                 Total_Cost += int.Parse(_Item.item_value);
                
                
            }
            
            Cost_Number.Text = Total_Cost.ToString();
        }

    }
}
