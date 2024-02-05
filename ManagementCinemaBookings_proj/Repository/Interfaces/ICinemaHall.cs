using ManagementCinemaBookings.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementCinemaBookings.Repository.Interfaces
{
    public interface ICinemaHall
    {
        Task<List<CinemaHallVM>> RetrieveCinemaHalls();
        Task<bool> AddCinemaHall(CinemaHallVM cinemaHallVM);
        Task<CinemaHallVM> FindCinemaHallById(int? id);
        Task<bool> EditCinemaHall(CinemaHallVM cinemaHallVM);       
    }
}