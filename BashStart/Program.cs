using System;
using System.Windows.Forms;
using Microsoft.Owin.Hosting;

namespace BashStart
{
    internal static class Program
    {
        private static IDisposable App;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Start();

            var menuItem = new MenuItem
            {
                Index = 0,
                Text = "E&xit",
            };

            menuItem.Click += (o, e) => Application.Exit();

            var contextMenu = new ContextMenu(new[] { menuItem });

            var home = Environment.GetEnvironmentVariable("USERPROFILE");
            Environment.CurrentDirectory = home;

            var icon = new NotifyIcon
            {
                Icon = new System.Drawing.Icon($@"{home}\AppData\Local\lxss\bash.ico"),
                ContextMenu = contextMenu,
                Text = "StartServer",
                Visible = true,
            };

            Application.ApplicationExit += (o, e) => icon.Visible = false;

            Application.Run();
        }

        private static void Start()
        {
            var baseAddress = "http://localhost:5050/";

            App = WebApp.Start<Startup>(url: baseAddress);
        }
    }
}
