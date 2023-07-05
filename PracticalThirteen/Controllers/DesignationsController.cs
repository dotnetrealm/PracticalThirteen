using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticalThirteen.Data.Contexts;
using PracticalThirteen.Data.Models;

namespace PracticalThirteen.Controllers
{
    public class DesignationsController : Controller
    {
        private OrganizationDBContext _db;

        public DesignationsController(OrganizationDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _db.Designations.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null) return View("Error/404");
            Designation? designation = await _db.Designations.FindAsync(id);
            if (designation == null) return View("Error/404");
            return View(designation);
        }

        // GET: Designations/Create
        public ActionResult Create()
        {
            return View(new Designation());
        }

        // POST: Designations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Designation designation)
        {
            if (ModelState.IsValid)
            {
                _db.Designations.Add(designation);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(designation);
        }

        // GET: Designations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Designation? designation = await _db.Designations.FindAsync(id);
            if (designation == null)
            {
                return View("Error");
            }
            return View(designation);
        }

        // POST: Designations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Designation designation)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(designation).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(designation);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return View("Error");
            Designation? designation = await _db.Designations.FindAsync(id);
            if (designation == null) return View("Error");
            return View(designation);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Designation? designation = await _db.Designations.FindAsync(id);
            if (designation == null) return View("Error/404");
            _db.Designations.Remove(designation);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
