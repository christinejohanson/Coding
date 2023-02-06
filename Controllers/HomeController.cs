using Coding.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Coding.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Header = "startsida";
            return View();
        }

        [Route("/about")]
        public IActionResult About()
        {
            ViewBag.Header = "om olika program och språken";
            //system io för att läsa in filer lokalt
            var JsonStr = System.IO.File.ReadAllText("coding.json");
            //konvertera till en lista av typen coursemodel
            var JsonObj = JsonConvert.DeserializeObject<List<CodeModel>>(JsonStr);
            return View(JsonObj);
        }

        [Route("/today")]
        public IActionResult Today()
        {
            ViewBag.Header = "idag";
            return View();
        }

        [Route("/addcode")]
        public IActionResult AddCode()
        {
            ViewBag.Header = "lägg till ny data";
            return View();
        }


        //post anrop med http. mot addcode
        [HttpPost("/addcode")]
        public IActionResult AddCode(CodeModel model)
        {
            //om formuläret korrekt ifyllt med modelstateisvalid
            if (ModelState.IsValid)
            {
                //system io för att läsa in filer lokalt
                var JsonStr = System.IO.File.ReadAllText("coding.json");
                //konvertera till en lista av typen coursemodel
                var JsonObj = JsonConvert.DeserializeObject<List<CodeModel>>(JsonStr);
                if (JsonObj != null)
                {
                    JsonObj.Add(model);
                    //skriv till filen. serialize gör till textsträng från jsondata.formatting hur man vill ha det.
                    System.IO.File.WriteAllText("coding.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));

                    //rensa formuläret
                    ModelState.Clear();
                }

            }
            return View();
        }
    }
}