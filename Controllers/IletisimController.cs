using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusranurCirikCv.Models.Entity;
using BusranurCirikCv.Repositories;

namespace BusranurCirikCv.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        IletisimRepository repo = new IletisimRepository();
        public ActionResult Index()
        {
            var iletisim = repo.List();
            return View(iletisim);
        }
    }
}