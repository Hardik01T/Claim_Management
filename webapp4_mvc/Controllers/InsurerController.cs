using Microsoft.AspNetCore.Mvc;
using webapp4_mvc.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace mvc_frountend.Controllers
{
   /* 
    [Authorize(Roles = "Insurer")]*/
    public class InsurerController : Controller
    {
        Uri baseaddres = new Uri("https://localhost:7167/api");
        HttpClient client = new HttpClient();
        public InsurerController()
        {
            client.BaseAddress = baseaddres;
        }
        public IActionResult Index()
        {
           
                List<Insurer_mvc> modellist = new List<Insurer_mvc>();
                HttpResponseMessage responce = client.GetAsync(client.BaseAddress + "/Insurers").Result;
                if (responce.IsSuccessStatusCode)
                {
                    string str = responce.Content.ReadAsStringAsync().Result;
                    modellist = JsonConvert.DeserializeObject<List<Insurer_mvc>>(str);

                }
                return View(modellist);

            
           
        }
        //CREATE POST//
        public ActionResult create()
        {
           
                return View();
      


        }
        [HttpPost]
        public ActionResult Create(Insurer_mvc model)
        {
            //here we convert normal data to the json format
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            //from here we go to the HttpPost method in Movies controller
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Insurers/", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int Id)
        {
           
                Insurer_mvc modellist = new Insurer_mvc();
                HttpResponseMessage responce = client.GetAsync(client.BaseAddress + "/Insurers/" + Id).Result;
                if (responce.IsSuccessStatusCode)
                {
                    string str = responce.Content.ReadAsStringAsync().Result;
                    modellist = JsonConvert.DeserializeObject<Insurer_mvc>(str);

                }
                return View(modellist);

        }
        [HttpPost]
        public ActionResult Edit(Insurer_mvc model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Insurers/" + model.InsurerId, content).Result;
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View(model);

        }

        public IActionResult Details(int Id)
        {

           Insurer_mvc modellist = new Insurer_mvc();
            HttpResponseMessage responce = client.GetAsync(client.BaseAddress + "/Insurers/" + Id).Result;
            if (responce.IsSuccessStatusCode)
            {
                string str = responce.Content.ReadAsStringAsync().Result;
                modellist = JsonConvert.DeserializeObject<Insurer_mvc>(str);

            }
            return View(modellist);



        }
        //DELETE///
        public IActionResult Delete(int Id)
        {
            Insurer_mvc modellist = new Insurer_mvc();
            HttpResponseMessage responce = client.DeleteAsync(client.BaseAddress + "/Insurers/" + Id).Result;
            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");


            }
            return View();

        }


    }
}
