using Microsoft.AspNetCore.Mvc;
using webapp4_mvc.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace mvc_frountend.Controllers
{
  /*  [Authorize (Roles = "Broker")]*/
    public class BrokerController : Controller
    {
        Uri baseaddres = new Uri("https://localhost:7167/api");
        HttpClient client = new HttpClient();
        
        public BrokerController()
        {
            client.BaseAddress = baseaddres;
        }
        public IActionResult Index()
        {
                List<Broker> modellist = new List<Broker>();
                HttpResponseMessage responce = client.GetAsync(client.BaseAddress + "/Brokers").Result;
                if (responce.IsSuccessStatusCode)
                {
                    string str = responce.Content.ReadAsStringAsync().Result;
                    modellist = JsonConvert.DeserializeObject<List<Broker>>(str);

                }
                return View(modellist);
           
        }

        //CREATE POST//
       
        public ActionResult create()
        {
           
                return View();
           
           

        }
        [HttpPost]
        public ActionResult Create(Broker model)
        {
           // _logger.LogInformation("hi all");
            string user = User.Identity.Name.ToLower();
           /* ViewBag user1 = user;*/
            //here we convert normal data to the json format
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            //from here we go to the HttpPost method in Movies controller
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Brokers/", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int Id)
        {
            
                Broker modellist = new Broker();
                HttpResponseMessage responce = client.GetAsync(client.BaseAddress + "/Brokers/" + Id).Result;
                if (responce.IsSuccessStatusCode)
                {
                    string str = responce.Content.ReadAsStringAsync().Result;
                    modellist = JsonConvert.DeserializeObject<Broker>(str);

                }
                return View(modellist);

            
           

        }
        [HttpPost]
        public ActionResult Edit(Broker model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Brokers/" + model.BrokerId, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(model);



        }
        //Details//
        public IActionResult Details(int Id)
        {
            Broker modellist = new Broker();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Brokers/" + Id).Result;
            if (response.IsSuccessStatusCode)
            {
                string str = response.Content.ReadAsStringAsync().Result;
                modellist = JsonConvert.DeserializeObject<Broker>(str);

            }
            return View(modellist);

        }

    }
}
