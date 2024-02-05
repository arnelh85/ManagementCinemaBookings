using System.Threading.Tasks;
using System.Web.Mvc;
using ManagementCinemaBookings.Repository.Classes;
using ManagementCinemaBookings.Repository.Interfaces;
using ManagementCinemaBookings.ViewModels;

namespace ManagementCinemaBookings.Controllers
{    
    public class CinemaHallsController : BaseController
    {        
        // GET: CinemaHalls
        [HttpGet]
        [AuthorizeUser]
        public async Task<ActionResult> Index()
        {
            ICinemaHall cinemaHall = new CCinemaHall();
            return View(await cinemaHall.RetrieveCinemaHalls());
        }

        // GET: CinemaHalls/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CinemaHalls/CreateConfirm       
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateConfirm([Bind(Include = "Id,CinemaCity,CinemaAddress,CinemaName,HallName,HallType,SeatCapacity")] CinemaHallVM cinemaHallVM)
        {
            if (ModelState.IsValid)
            {
                ICinemaHall cinemaHall = new CCinemaHall();
                await cinemaHall.AddCinemaHall(cinemaHallVM);
                return RedirectToAction("Index"); 
            }

            return View(cinemaHallVM);
        }

        // GET: CinemaHalls/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            ICinemaHall cinemaHall = new CCinemaHall();
            CinemaHallVM cinemaHallVM = await cinemaHall.FindCinemaHallById(id);

            if (cinemaHallVM == null)
            {
                return HttpNotFound();
            }

            return View(cinemaHallVM);
        }

        // POST: CinemaHalls/EditConfirm/5       
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditConfirm([Bind(Include = "Id,CinemaCity,CinemaAddress,CinemaName,HallName,HallType,SeatCapacity")] CinemaHallVM cinemaHallVM)
        {
            if (ModelState.IsValid)
            {
                ICinemaHall cinemaHall = new CCinemaHall();
                await cinemaHall.EditCinemaHall(cinemaHallVM);
                return RedirectToAction("Index");
            }

            return View(cinemaHallVM);
        }       
    }
}