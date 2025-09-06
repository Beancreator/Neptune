using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace Neptune
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Initialize WebView2
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.Navigate("https://www.bing.com"); // default homepage
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrl.Text))
                return;

            string url = txtUrl.Text;
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "https://" + url;
            }

            // Ensure WebView2 is initialized
            if (webView21.CoreWebView2 == null)
            {
                await webView21.EnsureCoreWebView2Async();
            }

            webView21.CoreWebView2.Navigate(url);
        }




        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webView21.CanGoBack)
                webView21.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webView21.CanGoForward)
                webView21.GoForward();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webView21.Reload();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://www.bing.com");
        }

        private void webView21_Click(object sender, EventArgs e)
        {
            // Optional: do nothing or handle if needed
        }
    }
}
