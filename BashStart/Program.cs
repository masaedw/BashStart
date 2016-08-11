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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void Start()
        {
            var baseAddress = "http://localhost:5050/";

            App = WebApp.Start<Startup>(url: baseAddress);
        }
    }
}
