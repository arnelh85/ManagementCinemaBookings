using ManagementCinemaBookings.Models;
using ManagementCinemaBookings.Repository.Interfaces;

namespace ManagementCinemaBookings.Repository.Classes
{
    public class DBContextContainer : IDBContextContainer
    {
        public ManagementCinemaBookingsDBEntities mcbDBEntities { get; set; }
    }
}