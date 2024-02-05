using ManagementCinemaBookings.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementCinemaBookings.Repository.Interfaces
{
    public interface ICinemaScreening
    {
        Task<List<CinemaScreeningVM>> RetrieveCinemaScreenings();
        Task<bool> AddCinemaScreening(CinemaScreeningVM cinemaScreeningVM);
        Task<CinemaScreeningVM> FindCinemaScreeningById(int? id);
        Task<bool> EditCinemaScreening(CinemaScreeningVM cinemaScreeningVM);
    }
}