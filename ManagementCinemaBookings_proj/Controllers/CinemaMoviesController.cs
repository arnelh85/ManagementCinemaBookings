using System.Threading.Tasks;
using System.Web.Mvc;
using ManagementCinemaBookings.ViewModels;
using ManagementCinemaBookings.Repository.Interfaces;
using ManagementCinemaBookings.Repository.Classes;

namespace ManagementCinemaBookings.Controllers
{   
    public class CinemaMoviesController : BaseController
    {
        // GET: CinemaMovies
        [HttpGet]
        [AuthorizeUser]
        public async Task<ActionResult> Index()
        {
            ICinemaMovie cinemaMovie = new CCinemaMovie();
            return View(await cinemaMovie.RetrieveCinemaMovies());
        }

        // GET: CinemaMovies/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CinemaMovies/CreateConfirm       
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateConfirm([Bind(Include = "Id,MovieName,MovieDirector,MovieGenre,MovieIssuanceCountry,MovieIssuanceYear,MovieRuntime")] CinemaMovieVM cinemaMovieVM)
        {
            if (ModelState.IsValid)
            {
                ICinemaMovie cinemaMovie = new CCinemaMovie();
                await cinemaMovie.AddCinemaMovie(cinemaMovieVM);
                return RedirectToAction("Index");
            }

            return View(cinemaMovieVM);
        }

        // GET: CinemaMovies/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            ICinemaMovie cinemaMovie = new CCinemaMovie();
            CinemaMovieVM cinemaMovieVM = await cinemaMovie.FindCinemaMovieById(id);

            if (cinemaMovieVM == null)
            {
                return HttpNotFound();
            }

            return View(cinemaMovieVM);
        }

        // POST: CinemaMovies/EditConfirm/5       
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditConfirm([Bind(Include = "Id,MovieName,MovieDirector,MovieGenre,MovieIssuanceCountry,MovieIssuanceYear,MovieRuntime")] CinemaMovieVM cinemaMovieVM)
        {
            if (ModelState.IsValid)
            {
                ICinemaMovie cinemaMovie = new CCinemaMovie();
                await cinemaMovie.EditCinemaMovie(cinemaMovieVM);
                return RedirectToAction("Index");
            }

            return View(cinemaMovieVM);
        }

        // GET: CinemaMovies/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            ICinemaMovie cinemaMovie = new CCinemaMovie();
            CinemaMovieVM cinemaMovieVM = await cinemaMovie.RemoveCinemaMovieById(id);

            if (cinemaMovieVM == null)
            {
                return HttpNotFound();
            }

            return View(cinemaMovieVM);
        }

        // POST: CinemaMovies/DeleteConfirm/5
        [HttpPost] 
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(int id)
        {
            ICinemaMovie cinemaMovie = new CCinemaMovie();
            await cinemaMovie.DeleteCinemaMovie(id);
            return RedirectToAction("Index");
        }       
    }
}