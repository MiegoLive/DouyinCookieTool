using System;
using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Web.WebView2.Core;

namespace DouyinCookieTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            InitWebView();
        }
        
        private async void InitWebView()
        {
            var customUserDataFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "MiegoLive", "DouyinCookieTool");
            var environment = await CoreWebView2Environment.CreateAsync(null, customUserDataFolder);
            await webView.EnsureCoreWebView2Async(environment);
            webView.CoreWebView2.Navigate("https://live.douyin.com");
        }

        private async void GetCookie_Click(object sender, RoutedEventArgs e)
        {
            // 取当前站点全部 Cookie
            var cookies = await webView.CoreWebView2.CookieManager.GetCookiesAsync("https://live.douyin.com");

            // 拼接成 name=value; 形式
            var sb = new StringBuilder();
            foreach (var c in cookies)
                sb.Append($"{c.Name}={c.Value}; ");

            var cookieStr = sb.ToString().TrimEnd(' ', ';');

            // 弹出窗口
            new CookieWindow(cookieStr).ShowDialog();
        }
    }
}