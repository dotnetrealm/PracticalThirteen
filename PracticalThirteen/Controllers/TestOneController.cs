using Microsoft.AspNetCore.Mvc;
using PracticalThirteen.Data.Contexts;
using PracticalThirteen.Data.Models;

namespace PracticalThirteen.Controllers
{
    public class TestOneController : Controller
    {
        EmployeeCodeFirstDBContext _context;
        public TestOneController(EmployeeCodeFirstDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Home Page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns list of all employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            IEnumerable<Employee> employees = _context.Employees.ToList();
            return PartialView("_EmployeesTable", employees);
        }

        /// <summary>
        /// Get specific employee by Id
        /// </summary>
        /// <param name="id">EmployeeId</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EmployeeDetails(int id)
        {
            Employee? data = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (data == null) return new StatusCodeResult(404);
            return PartialView("_EmployeeDetails", data);
        }

        // <summary>
        /// Return PartialView for new user creation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult Create()
        {
            return PartialView("_Create");
        }

        /// <summary>
        /// Create new employee
        /// </summary>
        /// <param name="user">Employee object</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Create([Bind(include: new[] { "Name, JoiningDate, Age" })] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    string messages = string.Join("\n", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                    throw new Exception(messages);
                }

                _context.Employees.Add(employee);
                _context.SaveChanges();
                return Json(new { Result = "OK", Data = new { employee } });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        /// <summary>
        /// Return PartialView for edit employee with data
        /// </summary>
        /// <param name="id">EmployeeId</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee? data = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (data == null) return new StatusCodeResult(404);
            return PartialView("_Edit", data);
        }

        /// <summary>
        /// Edit employee by id
        /// </summary>
        /// <param name="id">EmployeeId</param>
        /// <param name="user">Employee object</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(int id, [Bind("Name, JoiningDate, Age")] Employee emp)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    string messages = string.Join("\n", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                    throw new Exception(messages);
                }

                var employee = _context.Employees.SingleOrDefault(e => e.Id == id);
                if (employee != null)
                {
                    employee.Name = emp.Name;
                    employee.Age = emp.Age;
                    employee.JoiningDate = Convert.ToDateTime(emp.JoiningDate).Date;
                    _context.SaveChanges();
                }
                return Json(new { Result = "OK", Data = new { employee } });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete employee by id
        /// </summary>
        /// <param name="id">EmployeeId</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(int id)
        {
            Employee employee = new Employee() { Id = id };
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Json(new { Result = "OK" });
        }
    }
}