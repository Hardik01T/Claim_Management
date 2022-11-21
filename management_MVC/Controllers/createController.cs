using managementapi.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;


namespace management_MVC.Controllers
{
    public class CreateController1 : Controller
    {
        Uri baseaddres = new Uri("https://localhost:7167/api");
        HttpClient client = new HttpClient();

        public CreateController1()
        {
            client.BaseAddress = baseaddres;
        }
        public IActionResult Index()
        {
            List<Create> modellist = new List<Create>();
            HttpResponseMessage responce = client.GetAsync(client.BaseAddress + "/Creates").Result;
            if (responce.IsSuccessStatusCode)
            {
                string str = responce.Content.ReadAsStringAsync().Result;
                modellist = JsonConvert.DeserializeObject<List<Create>>(str);

            }
            return View(modellist);

        }
    }
}
