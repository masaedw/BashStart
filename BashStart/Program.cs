using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BashStart
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Start();
            return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void Start()
        {
            Process.Start("notepad", ".");
        }
    }
}
