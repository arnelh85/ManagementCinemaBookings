using ManagementCinemaBookings.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementCinemaBookings.Repository.Interfaces
{
    public interface ICinemaMovie
    {
        Task<List<CinemaMovieVM>> RetrieveCinemaMovies();
        Task<bool> AddCinemaMovie(CinemaMovieVM cinemaMovieVM);
        Task<CinemaMovieVM> FindCinemaMovieById(int? id);
        Task<bool> EditCinemaMovie(CinemaMovieVM cinemaMovieVM);
        Task<CinemaMovieVM> RemoveCinemaMovieById(int? id);
        Task<bool> DeleteCinemaMovie(int id);        
    }
}