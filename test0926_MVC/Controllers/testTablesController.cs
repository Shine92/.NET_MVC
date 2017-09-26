using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test0926_MVC.Models;

namespace test0926_MVC.Controllers
{
    public class testTablesController : Controller
    {
        private test0926DBEntities db = new test0926DBEntities();

        // GET: testTables
        public ActionResult Index()
        {
            return View(db.testTables.ToList());
        }

        // GET: testTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testTable testTable = db.testTables.Find(id);
            if (testTable == null)
            {
                return HttpNotFound();
            }
            return View(testTable);
        }

        // GET: testTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: testTables/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,charData,intData")] testTable testTable)
        {
            if (ModelState.IsValid)
            {
                db.testTables.Add(testTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testTable);
        }

        // GET: testTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testTable testTable = db.testTables.Find(id);
            if (testTable == null)
            {
                return HttpNotFound();
            }
            return View(testTable);
        }

        // POST: testTables/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,charData,intData")] testTable testTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testTable);
        }

        // GET: testTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testTable testTable = db.testTables.Find(id);
            if (testTable == null)
            {
                return HttpNotFound();
            }
            return View(testTable);
        }

        // POST: testTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            testTable testTable = db.testTables.Find(id);
            db.testTables.Remove(testTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
