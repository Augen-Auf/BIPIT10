using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace БИПиТ10.Controllers
{
    public class ServiceController : Controller
    {
        adverstEntities db = new adverstEntities();

        public ActionResult Service()
        {
            return View(db.Service.ToList());
        }

        [Authorize]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Add(Service service)
        {
            db.Entry(service).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Service");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Service service = new Service { IdS = id };
            db.Entry(service).State = EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Service");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Service service = db.Service.Find(id);
            if (service != null)
                return View("Edit", service);
            return HttpNotFound();
        }

        public ActionResult Save(Service service)
        {
            db.Entry(service).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Service");
        }
    }
}