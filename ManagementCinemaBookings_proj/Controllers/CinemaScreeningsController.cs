using ManagementCinemaBookings.Repository.Classes;
using ManagementCinemaBookings.Repository.Interfaces;
using ManagementCinemaBookings.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ManagementCinemaBookings.Controllers
{    
    public class CinemaScreeningsController : BaseController
    {        
        // GET: CinemaScreenings
        [HttpGet]
        [AuthorizeUser]
        public async Task<ActionResult> Index()
        {
            ICinemaScreening cinemaScreening = new CCinemaScreening();
            return View(await cinemaScreening.RetrieveCinemaScreenings());
        }

        // GET: CinemaScreenings/Create
        [HttpGet]
        public ActionResult Create()
        {           
            ViewBag.HallId = new SelectList(mcbDBEntities.CinemaHalls, "Id", "HallName");
            ViewBag.MovieId = new SelectList(mcbDBEntities.CinemaMovies, "Id", "MovieName");
            return View();
        }

        // POST: CinemaScreenings/CreateConfirm        
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateConfirm([Bind(Include = "Id,ScreeningStart,ScreeningEnd,SoldSeats,HallId,MovieId")] CinemaScreeningVM cinemaScreeningVM)
        {
            if (ModelState.IsValid)
            {
                ICinemaScreening cinemaScreening = new CCinemaScreening();
                await cinemaScreening.AddCinemaScreening(cinemaScreeningVM);
                return RedirectToAction("Index");
            }

            ViewBag.HallId = new SelectList(mcbDBEntities.CinemaHalls, "Id", "HallName", cinemaScreeningVM.HallId);
            ViewBag.Movieid = new SelectList(mcbDBEntities.CinemaMovies, "Id", "MovieName", cinemaScreeningVM.MovieId);           
            return View(cinemaScreeningVM);
        }

        // GET: CinemaScreenings/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            ICinemaScreening cinemaScreening = new CCinemaScreening();
            CinemaScreeningVM cinemaScreeningVM = await cinemaScreening.FindCinemaScreeningById(id);

            if (cinemaScreeningVM == null)
            {
                return HttpNotFound();
            }

            ViewBag.HallId = new SelectList(mcbDBEntities.CinemaHalls, "Id", "HallName", cinemaScreeningVM.HallId);
            ViewBag.MovieId = new SelectList(mcbDBEntities.CinemaMovies, "Id", "MovieName", cinemaScreeningVM.MovieId);
            return View(cinemaScreeningVM);
        }

        // POST: CinemaScreenings/EditConfirm/5        
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditConfirm([Bind(Include = "Id,ScreeningStart,ScreeningEnd,SoldSeats,HallId,MovieId")] CinemaScreeningVM cinemaScreeningVM)
        {
            if (ModelState.IsValid)
            {
                ICinemaScreening cinemaScreening = new CCinemaScreening();
                await cinemaScreening.EditCinemaScreening(cinemaScreeningVM);
                return RedirectToAction("Index");
            }

            ViewBag.HallId = new SelectList(mcbDBEntities.CinemaHalls, "Id", "HallName", cinemaScreeningVM.HallId);
            ViewBag.MovieId = new SelectList(mcbDBEntities.CinemaMovies, "Id", "MovieName", cinemaScreeningVM.MovieId);
            return View(cinemaScreeningVM);
        }                     
    }
}