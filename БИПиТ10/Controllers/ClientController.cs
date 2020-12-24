using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace БИПиТ10.Controllers
{
    public class ClientController : Controller
    {
        adverstEntities db = new adverstEntities();

        public ActionResult Client()
        {
            return View(db.Client.ToList());
        }

        [Authorize]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Add(Client client)
        {
            db.Entry(client).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Client");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Client client = new Client { IdC = id };
            db.Entry(client).State = EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Client");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Client client = db.Client.Find(id);
            if (client != null)
                return View("Edit", client);
            return HttpNotFound();
        }

        public ActionResult Save(Client client)
        {
            db.Entry(client).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Client");
        }
    }
}