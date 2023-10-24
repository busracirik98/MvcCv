using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusranurCirikCv.Models.Entity;
using BusranurCirikCv.Repositories;

namespace BusranurCirikCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        SosyalMedyaRepository repo = new SosyalMedyaRepository();
        public ActionResult Index()
        {
            var sosyalmedya = repo.List();
            return View(sosyalmedya);
        }

        public ActionResult SosyalMedyaSil(int id)
        {
            TblSosyalMedya t = repo.Find(x => x.ID == id);
            t.Durum = false;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SosyalMedyaEkle(TblSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SosyalMedyaGuncelle(int id)
        {
            TblSosyalMedya t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult SosyalMedyaGuncelle(TblSosyalMedya p)
        {
            TblSosyalMedya t = repo.Find(x => x.ID == p.ID);
            t.Ad = p.Ad;
            t.Link = p.Link;
            t.İkon = p.İkon;
            t.Durum = true;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}