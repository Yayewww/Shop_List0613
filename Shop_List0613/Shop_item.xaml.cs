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
    /// Shop_item.xaml 的互動邏輯
    /// </summary>
    public partial class Shop_item : UserControl
    {
        public int item_coco = 0;

        public Shop_item()
        {
            InitializeComponent();
        }

        // 自訂刪除事件
        public event EventHandler DeleteItem;
        //自訂算錢事件
        public event EventHandler PlusAll;

        //封裝屬性 : 控制項內容文字
        public string item_Content
        {
            get
            {
                return Content_Box.Text;
            }
            set
            {
                Content_Box.Text = value;
            }
        }

        //加總文字項，按下Enter執行 計算加總事件
        private void Cost_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (Cost_Box.Text != "" && e.Key == Key.Enter)
            {
                PlusAll(this, null);
            }
        }

        //取得費用
        public string item_value
        {
            get
            {
                return Cost_Box.Text;
            }
            set
            {
                Cost_Box.Text = value;
            }
        }
        //封裝屬性 : 日期
        public string item_Date
        {
            get
            {
                return Date_Box.Text;
            }
            set
            {
                Date_Box.Text = value;
            }
        }
        

        
        //內容文字項，按下事件
        private void Content_Box_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //當內容空白，且按下Backspace時，引發DeleteItem事件。
            if(Content_Box.Text =="" && e.Key == Key.Back)
            {
                DeleteItem(this, null);
            }
        }
    }
}
