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
        //公開類型 windows ，裡面有 Shop_item 的個體 。 用這個的意義是可以不用Eventhandler。 可以直接在這呼叫MainWindow中的方法
        public MainWindow windows;
        public Shop_item()
        {
            InitializeComponent();
        }
        


        //內容文字按下 BackSpace 觸發刪除事件
        private void Content_Box_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Content_Box.Text == "" && e.Key == Key.Back)
            {
                windows.Destroy_item(this); //指向windows中的item個體
            }
        }

        //文字改變時觸發加總事件
        private void Cost_Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(windows !=null)
            {
                windows.UpdateC();
            }
        }
    }
}
