using ManagementCinemaBookings.Repository.Classes;
using ManagementCinemaBookings.Repository.Interfaces;
using ManagementCinemaBookings.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ManagementCinemaBookings.Controllers
{    
    public class CinemaTicketBookingsController : BaseController
    {        
        // GET: CinemaTicketBookings
        [HttpGet]
        [AuthorizeUser]
        public async Task<ActionResult> Index()
        {
            ICinemaTicketBooking cinemaTicketBooking = new CCinemaTicketBooking(); 
            return View(await cinemaTicketBooking.RetrieveCinemaTicketBookings());
        }
       
        // GET: CinemaTicketBookings/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MovieId = new SelectList(mcbDBEntities.CinemaMovies, "Id", "MovieName");
            ViewBag.ScreeningId = new SelectList(mcbDBEntities.CinemaScreenings, "Id", "ScreeningStart");
            ViewBag.EmployeeId = new SelectList(mcbDBEntities.CinemaEmployees, "Id", "EmployeeName");
            return View();
        }

        // POST: CinemaTicketBookings/CreateConfirm        
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateConfirm([Bind(Include = "Id,CustomerName,CustomerAge,TicketNo,TicketPrice,Currency,PaymentMethod,SeatRow,SeatNo,SeatType,TicketIssuanceDate,MovieId,ScreeningId,EmployeeId")] CinemaTicketBookingVM cinemaTicketBookingVM)
        {
            if (ModelState.IsValid)
            {
                ICinemaTicketBooking cinemaTicketBooking = new CCinemaTicketBooking();
                await cinemaTicketBooking.AddCinemaTicket(cinemaTicketBookingVM);
                return RedirectToAction("Index");
            }

            ViewBag.MovieId = new SelectList(mcbDBEntities.CinemaMovies, "Id", "MovieName", cinemaTicketBookingVM.MovieId);
            ViewBag.ScreeningId = new SelectList(mcbDBEntities.CinemaScreenings, "Id", "ScreeningStart", cinemaTicketBookingVM.ScreeningId);
            ViewBag.EmployeeId = new SelectList(mcbDBEntities.CinemaEmployees, "Id", "EmployeeName", cinemaTicketBookingVM.EmployeeId);
            return View(cinemaTicketBookingVM);
        }                                     
    }
}