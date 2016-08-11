using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BashStartApi.Controllers
{
    [Route("api/[controller]")]
    public class StartController : Controller
    {
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string[] args)
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
    }
}
