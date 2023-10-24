using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusranurCirikCv.Models.Entity;
using BusranurCirikCv.Repositories;

namespace BusranurCirikCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        HakkimdaRepository repo = new HakkimdaRepository();
        [HttpGet]
        public ActionResult Index()
        {
           
                var hakkimda = repo.List();
                return View(hakkimda);

        }

        [HttpPost]
        public ActionResult Index(TblHakkimdaa p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Telefon = p.Telefon;
            t.Mail = p.Mail;
            t.Aciklama = p.Aciklama;
            t.Resim = p.Resim;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}