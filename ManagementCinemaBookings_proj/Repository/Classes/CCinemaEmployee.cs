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
    public class CCinemaEmployee : ICinemaEmployee
    {
        IDBContextContainer dbcc;
        Mapper mppr;

        public CCinemaEmployee()
        {
            dbcc = new DBContextContainer();
            mppr = MapperConfig.InitializeAutomapper();            
        }
        
        public async Task<List<CinemaEmployeeVM>> RetrieveCinemaEmployees()
        {
            List<CinemaEmployee> cin_employeeModel = null;
            List<CinemaEmployeeVM> cin_employeeModelVM = null;

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                cin_employeeModel = await dbcc.mcbDBEntities.CinemaEmployees.ToListAsync();
                cin_employeeModelVM = mppr.Map<List<CinemaEmployee>, List<CinemaEmployeeVM>>(cin_employeeModel);
            }

            return cin_employeeModelVM;
        }

        public async Task<bool> AddCinemaEmployee(CinemaEmployeeVM cinemaEmployeeVM)
        {            
            cinemaEmployeeVM.EmployeePassword = cinemaEmployeeVM.EmployeePassword.ConvertToBase64String();
            var add_cinemaEmployee = mppr.Map<CinemaEmployeeVM, CinemaEmployee>(cinemaEmployeeVM);

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                dbcc.mcbDBEntities.Entry(add_cinemaEmployee).State = EntityState.Added;
                await dbcc.mcbDBEntities.SaveChangesAsync();
            }

            return true;
        }

        public async Task<CinemaEmployeeVM> FindCinemaEmployeeById(int? id)
        {
            CinemaEmployee cin_employeeModel = null;
            CinemaEmployeeVM cin_employeeModelVM = null;

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                cin_employeeModel = await dbcc.mcbDBEntities.CinemaEmployees.Where(ce => ce.Id == id).FirstOrDefaultAsync();
                cin_employeeModelVM = mppr.Map<CinemaEmployee, CinemaEmployeeVM>(cin_employeeModel);
            }

            return cin_employeeModelVM;
        }

        public async Task<bool> EditCinemaEmployee(CinemaEmployeeVM cinemaEmployeeVM)
        {
            cinemaEmployeeVM.EmployeePassword = cinemaEmployeeVM.EmployeePassword.ConvertToBase64String();
            var edit_cinemaEmployee = mppr.Map<CinemaEmployeeVM, CinemaEmployee>(cinemaEmployeeVM);

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                dbcc.mcbDBEntities.Entry(edit_cinemaEmployee).State = EntityState.Modified;
                await dbcc.mcbDBEntities.SaveChangesAsync();
            }

            return true;
        }

        public async Task<CinemaEmployeeVM> RemoveCinemaEmployeeById(int? id)
        {
            CinemaEmployee cin_employeeModel = null;
            CinemaEmployeeVM cin_employeeModelVM = null;

            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {
                cin_employeeModel = await dbcc.mcbDBEntities.CinemaEmployees.Where(ce => ce.Id == id).FirstOrDefaultAsync();
                cin_employeeModelVM = mppr.Map<CinemaEmployee, CinemaEmployeeVM>(cin_employeeModel);
            }

            return cin_employeeModelVM;
        }

        public async Task<bool> DeleteCinemaEmployee(int id)
        {           
            using (dbcc.mcbDBEntities = new ManagementCinemaBookingsDBEntities())
            {                
                var del_cinemaEmployee = await dbcc.mcbDBEntities.CinemaEmployees.Where(ce => ce.Id == id).FirstOrDefaultAsync();
                dbcc.mcbDBEntities.Entry(del_cinemaEmployee).State = EntityState.Deleted;
                await dbcc.mcbDBEntities.SaveChangesAsync();
            }

            return true;
        }
    }
}