using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HavaYoluMVC.Models;
using System.Net.Http;

namespace HavaYoluMVC.Controllers
{
    public class UcakController : Controller
    {
        // GET: Ucak
        public ActionResult Index()
        {
            IEnumerable<MVCUcakmodel> calList;
            HttpResponseMessage response = GlobalVariables.WebApClient.GetAsync("Ucaks").Result;//apideki controllerin adı olacak(katmanlıyapidakı controller)
            calList = response.Content.ReadAsAsync<IEnumerable<MVCUcakmodel>>().Result;

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
                HttpResponseMessage response = GlobalVariables.WebApClient.GetAsync("Ucaks/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVCUcakmodel>().Result);
            }
        }

        [HttpPost]

        public ActionResult Ekle(MVCUcakmodel ucak)//crup
        {
            if (ucak.UcakNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApClient.PostAsJsonAsync("Ucaks", ucak).Result;
                TempData["SuccessMessage"] = "başarılı şekilde eklendi";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApClient.PutAsJsonAsync("Ucaks/" + ucak.UcakNo, ucak).Result;
                TempData["SuccessMessage"] = "başarılı şekilde güncellendi";
            }
            return RedirectToAction("Index");
        }


        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApClient.DeleteAsync("Ucaks/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "başarılı şekilde silindi";
            return RedirectToAction("Index");
        }








    }
}