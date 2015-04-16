using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KnockoutTest.Models;

namespace KnockoutTest.Controllers
{
    public class ReservoirsController : Controller
    {
        private KnockoutTestContext db = new KnockoutTestContext();

        private List<Reservoir> _reservoirs;
        private List<ReservoirViewModel> _reservoirViewModels;


        private void GenerateTestData()
        {
            _reservoirs = new List<Reservoir> 
            {
                new Reservoir
                {
                    ReservoirId = 1,
                    Name = "Reservoir 1",
                    Traps = new List<Trap> 
                    {
                        new Trap {TrapId = 1, Name = "Trap 1", Details = "Trap details 1"},
                        new Trap {TrapId = 2, Name = "Trap 2", Details = "Trap details 2"},
                        new Trap {TrapId = 3, Name = "Trap 3", Details = "Trap details 3"},
                        new Trap {TrapId = 4, Name = "Trap 4", Details = "Trap details 4"}
                    }
                },
                new Reservoir
                {
                    ReservoirId = 2,
                    Name = "Reservoir 2",
                    Traps = new List<Trap> 
                    {
                        new Trap {TrapId = 5, Name = "Trap 5", Details = "Trap details 5"},
                        new Trap {TrapId = 6, Name = "Trap 6", Details = "Trap details 6"},
                        new Trap {TrapId = 7, Name = "Trap 7", Details = "Trap details 7"},
                        new Trap {TrapId = 8, Name = "Trap 8", Details = "Trap details 8"}
                    }
                },
                new Reservoir
                {
                    ReservoirId = 3,
                    Name = "Reservoir 3",
                    Traps = new List<Trap> 
                    {
                        new Trap {TrapId = 9, Name = "Trap 9", Details = "Trap details 9"},
                        new Trap {TrapId = 10, Name = "Trap 10", Details = "Trap details 10"},
                        new Trap {TrapId = 11, Name = "Trap 11", Details = "Trap details 11"},
                        new Trap {TrapId = 12, Name = "Trap 12", Details = "Trap details 12"}
                    }
                }
            };
        }

        private void ConvertToViewModels()
        {
            _reservoirViewModels = new List<ReservoirViewModel>();
            foreach (var res in _reservoirs)
            {
                _reservoirViewModels.Add(new ReservoirViewModel(res));
            }
        }

        // GET: Reservoirs
        public ActionResult Index()
        {
            GenerateTestData();
            ConvertToViewModels();
            return View(_reservoirViewModels);
            //return View(db.Reservoirs.ToList());
        }

        public ActionResult Index2()
        {
            GenerateTestData();
            ConvertToViewModels();
            return View(_reservoirViewModels);
            //return View(db.Reservoirs.ToList());
        }

        [HttpPost]
        public ActionResult Index(List<TrapViewModel> traps)
        {
            if(traps == null || traps.Count == 0)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        // GET: Reservoirs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservoir reservoir = db.Reservoirs.Find(id);
            if (reservoir == null)
            {
                return HttpNotFound();
            }
            return View(reservoir);
        }

        public class Foo
        {
            public string Name { get; set; }

            public Foo()
            {
                Name = "Puuppa";
            }

            public Foo(string name)
            {
                Name = name;
            }
        }

        // GET: Reservoirs/Traps/5
        public ActionResult FooBar(string data)
        {
            var foo = new Foo(data);
            return Json(foo, JsonRequestBehavior.AllowGet);

        }

        // GET: Reservoirs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservoirs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservoirId,Name")] Reservoir reservoir)
        {
            if (ModelState.IsValid)
            {
                db.Reservoirs.Add(reservoir);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reservoir);
        }

        // GET: Reservoirs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservoir reservoir = db.Reservoirs.Find(id);
            if (reservoir == null)
            {
                return HttpNotFound();
            }
            return View(reservoir);
        }

        // POST: Reservoirs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservoirId,Name")] Reservoir reservoir)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservoir).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservoir);
        }

        // GET: Reservoirs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservoir reservoir = db.Reservoirs.Find(id);
            if (reservoir == null)
            {
                return HttpNotFound();
            }
            return View(reservoir);
        }

        // POST: Reservoirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservoir reservoir = db.Reservoirs.Find(id);
            db.Reservoirs.Remove(reservoir);
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
