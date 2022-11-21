using Microsoft.AspNetCore.Mvc;
using webapp4_mvc.Models;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using webapp4_mvc.Areas.Identity.Data;  

namespace mvc_frountend.Controllers
{
   /* [Authorize (Roles ="User")]*/
    public class UserController : Controller
    {
        
        Uri baseaddres = new Uri("https://localhost:7167/api");
        HttpClient client = new HttpClient();
        
        public UserController()
        {
            client.BaseAddress = baseaddres;
        }
        public IActionResult Index()
        {
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                /* List<Createmvc> searchs = db.AdjestorId.To();*/
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                List<Createmvc> modellist = new List<Createmvc>();
                HttpResponseMessage responce = client.GetAsync(client.BaseAddress + "/Creates").Result;
                if (responce.IsSuccessStatusCode)
                {
                    string str = responce.Content.ReadAsStringAsync().Result;
                    modellist = JsonConvert.DeserializeObject<List<Createmvc>>(str);
                


                }
                return View(modellist);
            


        }
        //CREATE POST//
        public ActionResult create()
        {
                
                var user = User.Identity.Name;
                List<Broker> broker_list = new List<Broker>();
                List<Insurer_mvc> insurer_List = new List<Insurer_mvc>();

                HttpResponseMessage BrokerResponse = client.GetAsync(client.BaseAddress + "/Brokers").Result;
                HttpResponseMessage InsurerResponse = client.GetAsync(client.BaseAddress + "/Insurers").Result;

                if (BrokerResponse.IsSuccessStatusCode && InsurerResponse.IsSuccessStatusCode)
                {
                    string brokerResString = BrokerResponse.Content.ReadAsStringAsync().Result;
                    string insurerResString = InsurerResponse.Content.ReadAsStringAsync().Result;
                    broker_list = JsonConvert.DeserializeObject<List<Broker>>(brokerResString);
                    insurer_List = JsonConvert.DeserializeObject<List<Insurer_mvc>>(insurerResString);
                }


                Createmvc UserMvc = new Createmvc();

                Dictionary<int, string> BrokersList = new Dictionary<int, string>();
                Dictionary<string, string> InsurerList = new Dictionary<string, string>();

                foreach (Broker broker in broker_list)
                {
                    BrokersList.Add(broker.BrokerId, broker.BrokerName);
                }

                foreach (Insurer_mvc insurer in insurer_List)
                {
                    InsurerList.Add(insurer.InsurerId, insurer.OrganizationCode);
                }

                UserMvc.BrokersList = BrokersList;
                UserMvc.InsurerList = InsurerList;

                return View(UserMvc);

            

        }

        [HttpPost]
        public ActionResult Create(Createmvc model)
        {
            //here we convert normal data to the json format
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            //from here we go to the HttpPost method in Movies controller
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Creates", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //Details//
        public IActionResult Details(int Id)
        {
           
                Createmvc modellist = new Createmvc();
                HttpResponseMessage responce = client.GetAsync(client.BaseAddress + "/Creates/" + Id).Result;
                if (responce.IsSuccessStatusCode)
                {
                    string str = responce.Content.ReadAsStringAsync().Result;
                    modellist = JsonConvert.DeserializeObject<Createmvc>(str);

                }
                return View(modellist);
           
            

        }
        //DELETE///
        public IActionResult Delete(int Id)
        {
            
                Createmvc modellist = new Createmvc();
                HttpResponseMessage responce = client.DeleteAsync(client.BaseAddress + "/Creates/" + Id).Result;
                if (responce.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");


                }
                return View();
           
            

        }

        public IActionResult Edit(int Id)
        {
           
                Createmvc modellist = new Createmvc();
                HttpResponseMessage responce = client.GetAsync(client.BaseAddress + "/Creates/" + Id).Result;
                if (responce.IsSuccessStatusCode)
                {
                    string str = responce.Content.ReadAsStringAsync().Result;
                    modellist = JsonConvert.DeserializeObject<Createmvc>(str);

                }
                return View(modellist);
            
            

        }
        [HttpPost]
        public ActionResult Edit(Createmvc model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Creates/" + model.Id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(model);



        }
    }
}
