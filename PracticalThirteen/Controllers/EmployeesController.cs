using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticalThirteen.Data.Contexts;
using PracticalThirteen.Data.Models;
using PracticalThirteen.ViewModels;

namespace PracticalThirteen.Controllers
{
    public class EmployeesController : Controller
    {
        readonly OrganizationDBContext _db;
        public EmployeesController(OrganizationDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var employees = _db.EmployeesWithSalary.Include(e => e.Designation);
            return View(await employees.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error/404");
            }
            EmployeeWithSalary? employees = await _db.EmployeesWithSalary.Where(e => e.Id == id).Include(e => e.Designation).FirstOrDefaultAsync();
            if (employees == null)
            {
                return View("Error/404");
            }
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DesignationId = new SelectList(_db.Designations, "Id", "DesignationName");
            return View(new EmployeeWithSalary());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(include: new[] { "Id,FirstName,MiddleName,LastName,DOB,MobileNumber,Address,Salary,DesignationId" })] EmployeeWithSalary employee)
        {
            if (ModelState.IsValid)
            {
                _db.EmployeesWithSalary.Add(employee);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DesignationId = new SelectList(_db.Designations, "Id", "DesignationName", employee.DesignationId);
            return View(employee);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null) return View("Error/404");
            var employee = await _db.EmployeesWithSalary.Include(e => e.Designation).ToListAsync();
            var emp = employee.ToList().Find(i=>i.Id == id);
            if (emp == null) return View("Error/404");
            ViewBag.DesignationId = new SelectList(_db.Designations, "Id", "DesignationName", emp.DesignationId);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EmployeeWithSalary employee)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(employee).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DesignationId = new SelectList(_db.Designations, "Id", "DesignationName", employee.DesignationId);
            return View(employee);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("Error/404");
            }
            var employees = await _db.EmployeesWithSalary.Include(e => e.Designation).ToListAsync();
            var emp = employees.Find(i => i.Id == id);
            if (emp == null)
            {
                return View("Error/404");
            }
            return View(emp);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var employee = await _db.EmployeesWithSalary.FindAsync(id);
            if (employee == null) return RedirectToAction("Error/404");
            _db.EmployeesWithSalary.Remove(employee);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Display Columns Employee Id, First Name, Middle Name, Last Name, Designation Name, DOB, 
        /// Mobile Number, Address & Salary with the help of LINQ query.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("EmployeeWithDesignation")]
        public async Task<ActionResult> GetEmployeesUsingLINQ()
        {
            List<EmployeeWithDesignation> employees = await _db.EmployeesWithSalary
                                                            .Join(_db.Designations, emp => emp.DesignationId, desg => desg.Id, (emp, desg) => new { emp, desg })
                                                            .Select((e) => new EmployeeWithDesignation() { Employee = e.emp, Designation = e.desg })
                                                            .ToListAsync();
            return View(employees);
        }

        /// <summary>
        /// Display the count number of records of the employee by designation name using LINQ query.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("EmployeesCountByDesignation")]
        public async Task<ActionResult> GetEmployeesCountByDesignationUsingLINQ()
        {
            var employee = await _db.EmployeesWithSalary
                                .Join(_db.Designations, emp => emp.DesignationId, desg => desg.Id, (emp, desg) => new { emp, desg })
                                .GroupBy(x => x.desg.DesignationName)
                                .Select(s => new EmployeeCountByDesignation() { Degination = s.Key, EmployeeCount = s.Count() })
                                .ToListAsync();
            return View(employee);
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
