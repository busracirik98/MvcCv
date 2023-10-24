using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusranurCirikCv.Models.Entity;

namespace BusranurCirikCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities(); // tablo bağlantısınuu burada yaparız. 
        public ActionResult Index()
        {
            var degerler = db.TblHakkimdaa.ToList();  // Tabloyu listelemek için 
            return View(degerler);
        }

        public PartialViewResult SosyalMedya() //Birden fazla tablo kullanmak için partial yapısı kullanırız.
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x => x.Durum == true).ToList();
            return PartialView(sosyalmedya);
        }

        public PartialViewResult Deneyim() //Birden fazla tablo kullanmak için partial yapısı kullanırız.
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult Egitim() //Birden fazla tablo kullanmak için partial yapısı kullanırız.
        {
           var egitimler = db.TblEgitimlerim.ToList();
           // var egitimler = db.TblEgitimlerim.OrderBy(s => s.Tarih).ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yetenek() //Birden fazla tablo kullanmak için partial yapısı kullanırız.
        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobi() //Birden fazla tablo kullanmak için partial yapısı kullanırız.
        {
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);
        }

        public PartialViewResult Sertifika() //Birden fazla tablo kullanmak için partial yapısı kullanırız.
        {
            //var sertifikalar = db.TblSertifikalarim.ToList();
            var sertifikalar = db.TblSertifikalarim.OrderByDescending(s => s.Aciklama).ToList();
            return PartialView(sertifikalar);
        }

        [HttpGet]
        public PartialViewResult Iletisim() 
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletisim(TblIletisim t) 
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblIletisim.Add(t); 
            db.SaveChanges();  //kaydetmek
            return PartialView();
        }
    }
}