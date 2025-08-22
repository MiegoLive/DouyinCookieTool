using System.Windows;

namespace DouyinCookieTool
{
    public partial class CookieWindow : Window
    {
        public CookieWindow(string cookie)
        {
            InitializeComponent();
            tbCookie.Text = cookie;      // 直接赋值
            try
            {
                Clipboard.SetText(cookie); // 顺手复制到剪贴板
            }
            catch
            {
                this.Title = "请手动复制 Cookie 到剪贴板";
            }
        }
    }
}