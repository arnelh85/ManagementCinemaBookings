using AutoMapper;
using ManagementCinemaBookings.Models;
using ManagementCinemaBookings.Repository.Interfaces;
using ManagementCinemaBookings.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementCinemaBookings.Repository.Classes
{
    public class CCinemaMovie : ICinemaMovie
    {
        IDBContextContainer dbcc;
        Mapper mppr;

        public CCinemaMovie()
        {
            dbcc = new DBContextContainer();
            mppr = MapperConfig.InitializeAutomapper();
        }


        public async Task<List<CinemaMovieVM>> RetrieveCinemaMovies()
        {
            List<CinemaMovie> cin_movieModel = null;
            List<CinemaMovieVM> cin_movieModelVM = null;

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                cin_movieModel = await dbcc.mcbDBEntities.CinemaMovies.ToListAsync();
                cin_movieModelVM = mppr.Map<List<CinemaMovie>, List<CinemaMovieVM>>(cin_movieModel);
            }

            return cin_movieModelVM;
        }

        public async Task<bool> AddCinemaMovie(CinemaMovieVM cinemaMovieVM)
        {
            var add_cinemaMovie = mppr.Map<CinemaMovieVM, CinemaMovie>(cinemaMovieVM);

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                dbcc.mcbDBEntities.Entry(add_cinemaMovie).State = EntityState.Added;
                await dbcc.mcbDBEntities.SaveChangesAsync();
            }

            return true;
        }

        public async Task<CinemaMovieVM> FindCinemaMovieById(int? id)
        {
            CinemaMovie cin_movieModel = null;
            CinemaMovieVM cin_movieModelVM = null;

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                cin_movieModel = await dbcc.mcbDBEntities.CinemaMovies.Where(cm => cm.Id == id).FirstOrDefaultAsync();
                cin_movieModelVM = mppr.Map<CinemaMovie, CinemaMovieVM>(cin_movieModel);
            }

            return cin_movieModelVM;
        }

        public async Task<bool> EditCinemaMovie(CinemaMovieVM cinemaMovieVM)
        {
            var edit_cinemaMovie = mppr.Map<CinemaMovieVM, CinemaMovie>(cinemaMovieVM);

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                dbcc.mcbDBEntities.Entry(edit_cinemaMovie).State = EntityState.Modified;
                await dbcc.mcbDBEntities.SaveChangesAsync();
            }

            return true;
        }

        public async Task<CinemaMovieVM> RemoveCinemaMovieById(int? id)
        {
            CinemaMovie cin_movieModel = null;
            CinemaMovieVM cin_movieModelVM = null;

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                cin_movieModel = await dbcc.mcbDBEntities.CinemaMovies.Where(cm => cm.Id == id).FirstOrDefaultAsync();
                cin_movieModelVM = mppr.Map<CinemaMovie, CinemaMovieVM>(cin_movieModel);
            }

            return cin_movieModelVM;
        }

        public async Task<bool> DeleteCinemaMovie(int id)
        {
            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                var del_cinemaMovie = await dbcc.mcbDBEntities.CinemaMovies.Where(cm => cm.Id == id).FirstOrDefaultAsync();
                dbcc.mcbDBEntities.Entry(del_cinemaMovie).State = EntityState.Deleted;
                await dbcc.mcbDBEntities.SaveChangesAsync();
            }

            return true;
        }        
    }
}