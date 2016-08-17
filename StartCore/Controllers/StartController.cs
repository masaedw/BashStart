using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Windows.Forms;

namespace StartCore.Controllers
{
    public class StartOptions
    {
        [Required]
        public string Name { get; set; }

        public string Args { get; set; }

        [Required]
        public string CurrentDirectory { get; set; }
    }

    public class StartController : ApiController
    {
        public static string ToWindowsPath(string linuxPath) => // TODO: take care of outside of /mnt/c
            Regex.Replace(linuxPath, "/mnt/(.)/", @"$1:\")
                .Replace('/', '\\');

        [HttpPost]
        public void Post([FromBody]StartOptions options)
        {
            if (!ModelState.IsValid)
            {
                MessageBox.Show("Invalid arguments", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Environment.CurrentDirectory = ToWindowsPath(options.CurrentDirectory);
                var name = ToWindowsPath(options.Name);
                if (string.IsNullOrEmpty(options.Args))
                {
                    Process.Start(name);
                }
                else
                {
                    Process.Start(name, options.Args);
                }
            }
            catch (Win32Exception e)
            {
                MessageBox.Show(e.Message, options.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
