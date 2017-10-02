using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Index(string uri)
        {
            string path = string.Empty;
            if (string.IsNullOrEmpty(uri))
            {
                path = "http://app.myzaker.com/index.php?app_id=660";
            }
            else
            {
                path = "http:" + uri;
            }
            HttpClient hc = new HttpClient();
            var content = hc.GetAsync(path);
            var str = content.Result.Content.ReadAsStringAsync().Result;
            //var start = str.IndexOf("<div class=\"article-content\">");
            //var end = str.IndexOf("<div class=\"y-box article-actions\">");
            var start = str.IndexOf("<body>");
            var end = str.IndexOf("</body>");
            //ViewBag.text = str.Substring(start, end - start); ;
            //str = str.Replace("<body>", "<body onload='$.getScript(\"demo_ajax_script.js\");'>");
            ViewBag.text = str;
            return View();
        }
    }

}
