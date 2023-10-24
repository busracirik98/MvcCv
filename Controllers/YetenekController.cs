using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusranurCirikCv.Models.Entity;
using BusranurCirikCv.Repositories;

namespace BusranurCirikCv.Controllers
{
    public class YetenekController : Controller
    {
        YetenekRepository repo = new YetenekRepository();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }

        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YetenekEkle(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            TblYeteneklerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGuncelle(int id)
        {
            var yeteneklerim = repo.Find(x => x.ID == id);
            return View(yeteneklerim);
        }

        [HttpPost]
        public ActionResult YetenekGuncelle(TblYeteneklerim p)
        {
            var yeteneklerim = repo.Find(x => x.ID == p.ID);
            yeteneklerim.Yetenekler = p.Yetenekler;
            yeteneklerim.Oran = p.Oran;
            repo.TUpdate(yeteneklerim);
            return RedirectToAction("Index");
        }
    }
}