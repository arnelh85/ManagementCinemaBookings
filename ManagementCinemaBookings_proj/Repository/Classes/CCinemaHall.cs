using AutoMapper;
using ManagementCinemaBookings.Models;
using ManagementCinemaBookings.Repository.Interfaces;
using ManagementCinemaBookings.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementCinemaBookings.Repository.Classes
{
    public class CCinemaHall : ICinemaHall
    {
        IDBContextContainer dbcc;
        Mapper mppr;

        public CCinemaHall()
        {
            dbcc = new DBContextContainer();
            mppr = MapperConfig.InitializeAutomapper();
        }


        public async Task<List<CinemaHallVM>> RetrieveCinemaHalls()
        {
            List<CinemaHall> cin_hallModel = null;
            List<CinemaHallVM> cin_hallModelVM = null;

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                cin_hallModel = await dbcc.mcbDBEntities.CinemaHalls.ToListAsync();
                cin_hallModelVM = mppr.Map<List<CinemaHall>, List<CinemaHallVM>>(cin_hallModel);
            }

            return cin_hallModelVM;
        }

        public async Task<bool> AddCinemaHall(CinemaHallVM cinemaHallVM)
        {
            var add_cinemaHall = mppr.Map<CinemaHallVM, CinemaHall>(cinemaHallVM);

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                dbcc.mcbDBEntities.Entry(add_cinemaHall).State = EntityState.Added;
                await dbcc.mcbDBEntities.SaveChangesAsync();
            }
            
            return true;
        }

        public async Task<CinemaHallVM> FindCinemaHallById(int? id)
        {
            CinemaHall cin_hallModel = null;
            CinemaHallVM cin_hallModelVM = null;

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                cin_hallModel = await dbcc.mcbDBEntities.CinemaHalls.Where(ch => ch.Id == id).FirstOrDefaultAsync();
                cin_hallModelVM = mppr.Map<CinemaHall, CinemaHallVM>(cin_hallModel);
            }

            return cin_hallModelVM;
        }

        public async Task<bool> EditCinemaHall(CinemaHallVM cinemaHallVM)
        {
            var edit_cinemaHall = mppr.Map<CinemaHallVM, CinemaHall>(cinemaHallVM);

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                dbcc.mcbDBEntities.Entry(edit_cinemaHall).State = EntityState.Modified;
                await dbcc.mcbDBEntities.SaveChangesAsync();
            }

            return true;
        }        
    }
}