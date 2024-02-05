using AutoMapper;
using ManagementCinemaBookings.Models;
using ManagementCinemaBookings.Repository.Interfaces;
using ManagementCinemaBookings.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementCinemaBookings.Repository.Classes
{
    public class CCinemaTicketBooking : ICinemaTicketBooking
    {
        IDBContextContainer dbcc;
        Mapper mppr;

        public CCinemaTicketBooking()
        {
            dbcc = new DBContextContainer();
            mppr = MapperConfig.InitializeAutomapper();
        }
      
        public async Task<List<CinemaTicketBookingVM>> RetrieveCinemaTicketBookings()
        {
            List<CinemaTicketBooking> cin_ticketbookingModel = null;
            List<CinemaTicketBookingVM> cin_ticketbookingModelVM = null;

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                cin_ticketbookingModel = await dbcc.mcbDBEntities.CinemaTicketBookings.ToListAsync();
                cin_ticketbookingModelVM = mppr.Map<List<CinemaTicketBooking>, List<CinemaTicketBookingVM>>(cin_ticketbookingModel);
            }

            return cin_ticketbookingModelVM;
        }

        public async Task<bool> AddCinemaTicket(CinemaTicketBookingVM cinemaTicketBookingVM)
        {                        
            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                int initial_CinemaTicketNo = 10000000;
                var executed_CinemaTicketNo = await dbcc.mcbDBEntities.CinemaTicketBookings.OrderByDescending(ctb => ctb.Id).Select(ctb => ctb.TicketNo).FirstOrDefaultAsync();
                cinemaTicketBookingVM.TicketNo = executed_CinemaTicketNo == 0 ? initial_CinemaTicketNo : (executed_CinemaTicketNo + 1);              
                DateTime dt = DateTime.Now;
                cinemaTicketBookingVM.TicketIssuanceDate = dt;
                var add_cinemaTicket = mppr.Map<CinemaTicketBookingVM, CinemaTicketBooking>(cinemaTicketBookingVM);
                dbcc.mcbDBEntities.Entry(add_cinemaTicket).State = EntityState.Added;
                await dbcc.mcbDBEntities.SaveChangesAsync();
            }

            return true;
        }
    }
}