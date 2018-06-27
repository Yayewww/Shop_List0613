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
using System.IO; //直接抓IO 省code
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
        

        public MainWindow()
        {
            InitializeComponent();
        }

        #region 視窗小操作
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
        #endregion

        //創建格子List
        List<Shop_item> items = new List<Shop_item>();

        //按下新增
        private void Add_Btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DateTime dt = DateTime.Now;

            //產生物件到Panel ， 並加上當前日期
            Shop_item _Item = new Shop_item();
            _Item.windows = this; //將此個體指向windows類別中
            _Item.Date_Box.Text = dt.Month + "/" + dt.Day;
            TaskPanel.Children.Add(_Item);
                   
            items.Add(_Item);
        }

        public void UpdateC()
        {
            //更新加總
            float Total = 0;
            foreach(Shop_item i in items)
            {
                int each_cost = 0;
                Int32.TryParse(i.Cost_Box.Text, out each_cost);
                Total += each_cost;
            }
            Cost_Number.Text = Total.ToString();
        }

        public void Destroy_item(Shop_item _Item)
        {
            //砍掉當前個體
            items.Remove(_Item);
            TaskPanel.Children.Remove(_Item);
            UpdateC();
        }

        #region 視窗開關處理函式   
        private void Window_Closed(object sender, EventArgs e)
        {
            //儲存成文字格式
            List<string> datas = new List<string>();
            foreach (Shop_item i in items)
            {
                string data = "";

                data += i.Date_Box.Text + "|" + i.Content_Box.Text + "|" + i.Cost_Box.Text;

                datas.Add(data);
            }
            //內容存到以下路徑
            File.WriteAllLines(@"C:\Buy_temp\data.txt", datas);
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //如果檔案存在，就讀進來
            if (File.Exists(@"C:\Buy_temp\data.txt"))
            {
                string[] datas = File.ReadAllLines(@"C:\Buy_temp\data.txt");

                //個別產生項目
                foreach (string data in datas)
                {
                    string[] parts = data.Split('|');
                    Shop_item _Item = new Shop_item();

                    _Item.Date_Box.Text = parts[0];
                    _Item.Content_Box.Text = parts[1];
                    _Item.Cost_Box.Text = parts[2];
                    _Item.windows = this;//將此個體指向windows類別中

                    TaskPanel.Children.Add(_Item);
                    items.Add(_Item);
                    
                }
            }
            //重更新加總
            UpdateC();

        }
        #endregion

    }
}
