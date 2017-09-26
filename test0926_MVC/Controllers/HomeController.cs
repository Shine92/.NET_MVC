using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test0926_MVC.Models;

namespace test0926_MVC.Controllers
{
    public class HomeController : Controller
    {

        test0926DBEntities db = new test0926DBEntities();

        // GET: Home
        public ActionResult Index()
        {
            var query = from o in db.vIntDataInfoes
                        select o;
            return View(query.ToList());


            //var query = from o in db.testTables
            //            join t in db.intDataInfoes on o.intData equals t.intData
            //            select new HomeIndexViewModel {
            //                id = o.id,
            //                charData = o.charData,
            //                intData = o.intData,
            //                intDataName = t.intDataName
            //            };
            //return View(query.ToList()); ;

            //var query = from o in db.testTables
            //            select o;

            //List<testTable> viewData = query.ToList();



        }

        public ActionResult Create() {
            var viewData = new testTable();
            return View(viewData);
        }

        [HttpPost]
        public ActionResult Create(testTable data) {
            try {
                db.testTables.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch {
                return View(data);
            }
        }

        public ActionResult Edit(int id) {
            var query = from o in db.testTables
                        where o.id == id
                        select o;

            // testTable viewData = db.testTables.Find(id);
            testTable viewData = query.Single();
            return View(viewData);
        }

        [HttpPost]
        public ActionResult Edit(int id, testTable viewData) {
            testTable dbData = db.testTables.Find(id);

            // dbData.id = viewData.id;
            dbData.charData = viewData.charData;
            dbData.intData = viewData.intData;

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}