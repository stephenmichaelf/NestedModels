using System.Data;
using System.Linq;
using System.Web.Mvc;
using NestedModels.Models;

namespace NestedModels.Controllers
{
    public class ExtensionsController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Extensions/

        public ActionResult Index()
        {
            return View(db.Extensions.ToList());
        }

        //
        // GET: /Extensions/Details/5

        public ActionResult Details(int id = 0)
        {
            Extension extension = db.Extensions.Find(id);
            if (extension == null)
            {
                return HttpNotFound();
            }
            return View(extension);
        }

        //
        // GET: /Extensions/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Extensions/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Extension extension)
        {
            if (ModelState.IsValid)
            {
                db.Extensions.Add(extension);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(extension);
        }

        //
        // GET: /Extensions/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Extension extension = db.Extensions.Find(id);
            if (extension == null)
            {
                return HttpNotFound();
            }
            return View(extension);
        }

        //
        // POST: /Extensions/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Extension extension)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extension).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(extension);
        }

        //
        // GET: /Extensions/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Extension extension = db.Extensions.Find(id);
            if (extension == null)
            {
                return HttpNotFound();
            }
            return View(extension);
        }

        //
        // POST: /Extensions/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Extension extension = db.Extensions.Find(id);
            db.Extensions.Remove(extension);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}