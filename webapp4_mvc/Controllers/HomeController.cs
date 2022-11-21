using Microsoft.AspNetCore.Mvc;
using webapp4_mvc.Models;

using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace mvc_frountend.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        
        private readonly ILogger<HomeController> _logger;

        Uri baseaddres = new Uri("https://localhost:7167/api");

        HttpClient client = new HttpClient();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            //  var result = cc.Creates.All(m => m.CloseDate!=null);
            /* var res= from item in cc.Creates where item.CloseDate!=null select item;*/
            ViewBag.Date= DateTime.Now;
           

            List<Createmvc> modellist = new List<Createmvc>();
            List<Createmvc> modellist1 = new List<Createmvc>();
/*            
*/
            HttpResponseMessage responce = client.GetAsync(baseaddres + "/Creates/ClosedClaim").Result;
            HttpResponseMessage responce1 = client.GetAsync(baseaddres + "/Creates").Result;
            HttpResponseMessage responce2 = client.GetAsync(baseaddres + "/LoginDs").Result;

            if (responce.IsSuccessStatusCode && responce1.IsSuccessStatusCode)
            {
                string str = responce.Content.ReadAsStringAsync().Result;
                modellist = JsonConvert.DeserializeObject<List<Createmvc>>(str);
                string str1 = responce1.Content.ReadAsStringAsync().Result;
                modellist1 = JsonConvert.DeserializeObject<List<Createmvc>>(str1);
                string str2 = responce1.Content.ReadAsStringAsync().Result;
/*                modellist2 = JsonConvert.DeserializeObject<List<Login>>(str2);
*/
            }
            int dates = modellist1.FindAll(l => l.CreatedDate == DateTime.Today.Date).Count();

            Tuple<int, int, int> counts = new Tuple<int, int, int>(modellist.Count(), modellist1.Count(), dates);

            return View(counts);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}