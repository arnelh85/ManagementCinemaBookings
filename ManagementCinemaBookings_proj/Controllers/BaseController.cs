using ManagementCinemaBookings.Models;
using System.Web.Mvc;

namespace ManagementCinemaBookings.Controllers
{
    public class BaseController : Controller
    {
        protected ManagementCinemaBookingsDBEntities mcbDBEntities = new ManagementCinemaBookingsDBEntities();
    }
}