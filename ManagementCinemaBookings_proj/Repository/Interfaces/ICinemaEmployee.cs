using ManagementCinemaBookings.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementCinemaBookings.Repository.Interfaces
{
    public interface ICinemaEmployee
    {
        Task<List<CinemaEmployeeVM>> RetrieveCinemaEmployees();
        Task<bool> AddCinemaEmployee(CinemaEmployeeVM cinemaEmployeeVM);
        Task<CinemaEmployeeVM> FindCinemaEmployeeById(int? id);
        Task<bool> EditCinemaEmployee(CinemaEmployeeVM cinemaEmployeeVM);
        Task<CinemaEmployeeVM> RemoveCinemaEmployeeById(int? id);
        Task<bool> DeleteCinemaEmployee(int id);
    }
}