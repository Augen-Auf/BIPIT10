using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace БИПиТ10.Controllers
{
    public class OrderController : Controller
    {
        adverstEntities db = new adverstEntities();

        public ActionResult Order()
        {
            return View(db.OrderView.ToList());
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Clients = db.Client;
            ViewBag.Services = db.Service;
            return View("Create");
        }

        [HttpPost]
        public ActionResult Add(Order order)
        {
            db.Entry(order).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Order");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Order order = new Order { IdO = id };
            db.Entry(order).State = EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Order");
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Order order = db.Order.Find(id);
            if (order != null)
            {
                ViewBag.Clients = db.Client;
                ViewBag.Services = db.Service;
                return View("Edit", order);
            }
            return HttpNotFound();
        }

        public ActionResult Save(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Order");
        }
    }
}