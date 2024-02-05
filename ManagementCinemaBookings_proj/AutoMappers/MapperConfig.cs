using AutoMapper;
using ManagementCinemaBookings.Models;
using ManagementCinemaBookings.ViewModels;

namespace ManagementCinemaBookings
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {            
            var config = new MapperConfiguration(cfg =>
            { 
                // Directions From Models To ViewModels
                cfg.CreateMap<CinemaHall, CinemaHallVM>();
                cfg.CreateMap<CinemaMovie, CinemaMovieVM>();
                cfg.CreateMap<CinemaScreening, CinemaScreeningVM>();
                cfg.CreateMap<CinemaEmployee, CinemaEmployeeVM>();
                cfg.CreateMap<CinemaTicketBooking, CinemaTicketBookingVM>();
                
                // Directions From ViewModels To Models
                cfg.CreateMap<CinemaHallVM, CinemaHall>();
                cfg.CreateMap<CinemaMovieVM, CinemaMovie>();
                cfg.CreateMap<CinemaScreeningVM, CinemaScreening>();
                cfg.CreateMap<CinemaEmployeeVM, CinemaEmployee>();
                cfg.CreateMap<CinemaTicketBookingVM, CinemaTicketBooking>();
            });            
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}