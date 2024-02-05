using ManagementCinemaBookings.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ManagementCinemaBookings.Controllers
{    
    public class AuthorizationController : BaseController
    {
        // GET: Authorization/Login
        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return await Task.Run(() => View());
        }

        // POST: Authorization/LoginConfirm        
        [HttpPost]
        [ActionName("Login")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginConfirm([Bind(Include = "EmployeeEmailAddress,EmployeePassword")] CinemaEmployeeVM cinemaEmployeeVM)
        {
            string login_email = null;
            string decr_pwd = null;
            var email_cred = await mcbDBEntities.CinemaEmployees.Where(ce => ce.EmployeeEmailAddress == cinemaEmployeeVM.EmployeeEmailAddress).FirstOrDefaultAsync();
            var cin_EmployeeType = await (from ce in mcbDBEntities.CinemaEmployees join cet in mcbDBEntities.CinemaEmployeeTypes on ce.EmployeeTypeId equals cet.Id
                                          where ce.EmployeeEmailAddress == cinemaEmployeeVM.EmployeeEmailAddress select cet.EmployeeTypeNo).FirstOrDefaultAsync();
            var retrievedFullName = await mcbDBEntities.CinemaEmployees.Where(ce => ce.EmployeeEmailAddress == cinemaEmployeeVM.EmployeeEmailAddress).Select(ce => ce.EmployeeName).FirstOrDefaultAsync();

            if (email_cred != null)
            {
                login_email = cinemaEmployeeVM.EmployeeEmailAddress;
                decr_pwd = email_cred.EmployeePassword.ConvertFromBase64String();
                Session["log_email"] = login_email;
                Session["log_password"] = decr_pwd;
                Session["cinemaEmployeeFullName"] = retrievedFullName;

                if (cinemaEmployeeVM.EmployeePassword == decr_pwd && cin_EmployeeType == 1)
                {
                    Session["IsAdmin"] = cin_EmployeeType;
                    return RedirectToAction("Index", "CinemaEmployees");
                }

                else if (cinemaEmployeeVM.EmployeePassword == decr_pwd && cin_EmployeeType == 2)
                {
                    Session["IsUser"] = cin_EmployeeType;
                    return RedirectToAction("Index", "CinemaTicketBookings");
                }

                else
                {
                    ModelState.AddModelError("EmployeePassword", "Unešena šifra nije ispravna!");
                    return View();
                }                
            }

            else
            {
                ModelState.AddModelError("EmployeeEmailAddress", "Unešena email adresa nije ispravna!");
                return View();
            }                      
        }

        // GET: Authorization/Logout
        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            Session["log_email"] = null;
            Session["log_password"] = null;
            Session["cinemaEmployeeFullName"] = null;
            Session["IsAdmin"] = null;
            Session["IsUser"] = null;
            return await Task.Run<ActionResult>(() => { return RedirectToAction("Login"); });
        }
    }
}