using ManagementCinemaBookings.Models;

namespace ManagementCinemaBookings.Repository.Interfaces
{
    interface IDBContextContainer
    {         
        ManagementCinemaBookingsDBEntities mcbDBEntities { get; set; }
    }
}
