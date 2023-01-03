using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HavaYoluMVC.Models;
using System.Web.Mvc;
using System.Net.Http;

namespace HavaYoluMVC.Controllers
{
    public class SirketController : Controller
    {
        // GET: Sirket
        public ActionResult Index()
        {
            IEnumerable<MVCSirketmodel> calList;
            HttpResponseMessage response = GlobalVariables.WebApClient.GetAsync("Sirkets").Result;//apideki controllerin adı olacak(katmanlıyapidakı controller)
            calList = response.Content.ReadAsAsync<IEnumerable<MVCSirketmodel>>().Result;

            return View(calList);
        }


        public ActionResult Ekle(int id = 0)//crup hem ekleme hem guncelleme aynı sayfada olunca denir.
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApClient.GetAsync("Sirkets/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVCSirketmodel>().Result);
            }
        }

        [HttpPost]

        public ActionResult Ekle(MVCSirketmodel sirket)//crup
        {
            if (sirket.SirketNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApClient.PostAsJsonAsync("Sirkets", sirket).Result;
                TempData["SuccessMessage"] = "başarılı şekilde eklendi";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApClient.PutAsJsonAsync("Sirkets/" + sirket.SirketNo, sirket).Result;
                TempData["SuccessMessage"] = "başarılı şekilde güncellendi";
            }
            return RedirectToAction("Index");
        }


        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApClient.DeleteAsync("Sirkets/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "başarılı şekilde silindi";
            return RedirectToAction("Index");
        }



    }
}