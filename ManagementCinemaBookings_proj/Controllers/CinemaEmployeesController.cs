using System.Threading.Tasks;
using System.Web.Mvc;
using ManagementCinemaBookings.Repository.Interfaces;
using ManagementCinemaBookings.Repository.Classes;
using ManagementCinemaBookings.ViewModels;

namespace ManagementCinemaBookings.Controllers
{
    public class CinemaEmployeesController : BaseController
    {       
        // GET: CinemaEmployees
        [HttpGet]
        [AuthorizeUser]
        public async Task<ActionResult> Index()
        {
            ICinemaEmployee cinemaEmployee = new CCinemaEmployee();
            return View(await cinemaEmployee.RetrieveCinemaEmployees());
        }
        
        // GET: CinemaEmployees/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.EmployeeTypeId = new SelectList(mcbDBEntities.CinemaEmployeeTypes, "Id", "EmployeeTypeName");
            return View();
        }

        // POST: CinemaEmployees/CreateConfirm        
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateConfirm([Bind(Include = "Id,EmployeeName,EmployeeAge,EmployeeGender,EmployeePIDN,EmployeeCountry,EmployeeCity,EmployeePhoneNumber,EmployeeEmailAddress,EmployeePassword,EmployeeTypeId")] CinemaEmployeeVM cinemaEmployeeVM)
        {
            if (ModelState.IsValid)
            {
                ICinemaEmployee cinemaEmployee = new CCinemaEmployee();
                await cinemaEmployee.AddCinemaEmployee(cinemaEmployeeVM);
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeTypeId = new SelectList(mcbDBEntities.CinemaEmployeeTypes, "Id", "EmployeeTypeName", cinemaEmployeeVM.EmployeeTypeId);
            return View(cinemaEmployeeVM);
        }

        // GET: CinemaEmployees/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            ICinemaEmployee cinemaEmployee = new CCinemaEmployee();
            CinemaEmployeeVM cinemaEmployeeVM = await cinemaEmployee.FindCinemaEmployeeById(id);

            if (cinemaEmployeeVM == null)
            {
                return HttpNotFound();
            }

            ViewBag.EmployeeTypeId = new SelectList(mcbDBEntities.CinemaEmployeeTypes, "Id", "EmployeeTypeName", cinemaEmployeeVM.EmployeeTypeId);
            return View(cinemaEmployeeVM);
        }

        // POST: CinemaEmployees/EditConfirm/5        
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditConfirm([Bind(Include = "Id,EmployeeName,EmployeeAge,EmployeeGender,EmployeePIDN,EmployeeCountry,EmployeeCity,EmployeePhoneNumber,EmployeeEmailAddress,EmployeePassword,EmployeeTypeId")] CinemaEmployeeVM cinemaEmployeeVM)
        {
            if (ModelState.IsValid)
            {
                ICinemaEmployee cinemaEmployee = new CCinemaEmployee();
                await cinemaEmployee.EditCinemaEmployee(cinemaEmployeeVM);
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeTypeId = new SelectList(mcbDBEntities.CinemaEmployeeTypes, "Id", "EmployeeTypeName", cinemaEmployeeVM.EmployeeTypeId);
            return View(cinemaEmployeeVM);
        }

        // GET: CinemaEmployees/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            ICinemaEmployee cinemaEmployee = new CCinemaEmployee();
            CinemaEmployeeVM cinemaEmployeeVM = await cinemaEmployee.RemoveCinemaEmployeeById(id);

            if (cinemaEmployeeVM == null)
            {
                return HttpNotFound();
            }

            ViewBag.EmployeeTypeId = new SelectList(mcbDBEntities.CinemaEmployeeTypes, "Id", "EmployeeTypeName", cinemaEmployeeVM.EmployeeTypeId);
            return View(cinemaEmployeeVM);
        }

        // POST: CinemaEmployees/DeleteConfirm/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(int id)
        {
            ICinemaEmployee cinemaEmployee = new CCinemaEmployee();
            await cinemaEmployee.DeleteCinemaEmployee(id);           
            return RedirectToAction("Index");            
        }       
    }
}