using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Windows.Forms;

namespace StartCore.Controllers
{
    public class StartController : ApiController
    {
        [HttpPost]
        public void Post([FromBody]string[] args)
        {
            try
            {
                switch (args.Length)
                {
                    case 0:
                        return;

                    case 1:
                        Process.Start(args[0]);
                        return;

                    default:
                        Process.Start(args[0], string.Join(" ", args.Skip(1)));
                        return;
                }
            }
            catch (Win32Exception e)
            {
                MessageBox.Show(e.Message, args.FirstOrDefault() ?? "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
