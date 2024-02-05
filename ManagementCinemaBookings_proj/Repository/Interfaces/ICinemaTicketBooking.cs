using ManagementCinemaBookings.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementCinemaBookings.Repository.Interfaces
{
    public interface ICinemaTicketBooking
    {
        Task<List<CinemaTicketBookingVM>> RetrieveCinemaTicketBookings();
        Task<bool> AddCinemaTicket(CinemaTicketBookingVM cinemaTicketBookingVM);
    }
}