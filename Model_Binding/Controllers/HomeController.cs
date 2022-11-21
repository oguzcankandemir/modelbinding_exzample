using Microsoft.AspNetCore.Mvc;
using Model_Binding.Models.ViewsModel;
using System;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Model_Binding.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        // ‘IDistributedCache’ interface’ını kullanarak dependency injection’dan servisi talep ediyorum
        IDistributedCache _distributedCache;
        public HomeController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        //Metinsel türde key-value tarzında veri depolamasını gerçekleştiren metot
        public IActionResult CacheSetString()
        {
            _distributedCache.SetString("date", DateTime.Now.ToString(), new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(1200),
                SlidingExpiration = TimeSpan.FromSeconds(60)
            });
            return View();
        }

        // 
        public IActionResult Viewbag_ornek()
        {
            List<Kursiyer> kursiyerler = new List<Kursiyer>
            {
                new Kursiyer { ID = 1, Adi = "Ali" },
                new Kursiyer { ID = 2, Adi="Ayhan" },
                new Kursiyer { ID = 3, Adi="Erdem"},
                new Kursiyer {ID = 4, Adi="Oğuzcan"}

            };
            //içine yazıyorum
            ViewBag.Kursiyerler = new SelectList(kursiyerler, "ID", "Adi");
            return View();

        }
    }
}
