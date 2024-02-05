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
    public class CCinemaScreening : ICinemaScreening
    {        
        IDBContextContainer dbcc;
        Mapper mppr;
        
        public CCinemaScreening()
        {
            dbcc = new DBContextContainer();
            mppr = MapperConfig.InitializeAutomapper();           
        }


        public async Task<List<CinemaScreeningVM>> RetrieveCinemaScreenings()
        {
            List<CinemaScreening> cin_screeningModel = null;
            List<CinemaScreeningVM> cin_screeningModelVM = null;

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                cin_screeningModel = await dbcc.mcbDBEntities.CinemaScreenings.ToListAsync();
                cin_screeningModelVM = mppr.Map<List<CinemaScreening>, List<CinemaScreeningVM>>(cin_screeningModel);
            }

            return cin_screeningModelVM;
        }

        public async Task<bool> AddCinemaScreening(CinemaScreeningVM cinemaScreeningVM)
        {           
            var add_cinemaScreening = mppr.Map<CinemaScreeningVM, CinemaScreening>(cinemaScreeningVM);
                                            
            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {                
                dbcc.mcbDBEntities.Entry(add_cinemaScreening).State = EntityState.Added;
                await dbcc.mcbDBEntities.SaveChangesAsync();
            }
            
            return true;
        }

        public async Task<CinemaScreeningVM> FindCinemaScreeningById(int? id)
        {
            CinemaScreening cin_screeningModel = null;
            CinemaScreeningVM cin_screeningModelVM = null;

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                cin_screeningModel = await dbcc.mcbDBEntities.CinemaScreenings.Where(cs => cs.Id == id).FirstOrDefaultAsync();
                cin_screeningModelVM = mppr.Map<CinemaScreening,CinemaScreeningVM>(cin_screeningModel);
            }

            return cin_screeningModelVM;
        }

        public async Task<bool> EditCinemaScreening(CinemaScreeningVM cinemaScreeningVM)
        {
            var edit_cinemaScreening = mppr.Map<CinemaScreeningVM, CinemaScreening>(cinemaScreeningVM);

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                dbcc.mcbDBEntities.Entry(edit_cinemaScreening).State = EntityState.Modified;
                await dbcc.mcbDBEntities.SaveChangesAsync();
            }

            return true;
        }
    }
}