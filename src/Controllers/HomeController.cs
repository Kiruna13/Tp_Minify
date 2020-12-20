using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Minify.Controllers
{
    [Controller]
    [Route("/redirect")]
    public class RedirectController : ControllerBase
    {
        [HttpGet]
        [Route("/redirect/{id}")]
        public IActionResult Get(string id)
        {
            var url = new Repository().Get(id).Url;
            return Redirect(url);
        }
    }
}