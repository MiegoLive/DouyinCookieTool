using System.Windows;

namespace DouyinCookieTool
{
    public partial class CookieWindow : Window
    {
        public CookieWindow(string cookie)
        {
            InitializeComponent();
            tbCookie.Text = cookie;      // 直接赋值
            Clipboard.SetText(cookie);   // 顺手复制到剪贴板
        }
    }
}