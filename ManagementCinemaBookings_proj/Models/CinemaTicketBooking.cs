//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagementCinemaBookings.Models
{
    using System;
        
    public partial class CinemaTicketBooking
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public short CustomerAge { get; set; }
        public int TicketNo { get; set; }
        public decimal TicketPrice { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public byte SeatRow { get; set; }
        public string SeatNo { get; set; }
        public string SeatType { get; set; }
        public DateTime? TicketIssuanceDate { get; set; }
        public int MovieId { get; set; }
        public int ScreeningId { get; set; }
        public int EmployeeId { get; set; }    
        public virtual CinemaEmployee CinemaEmployee { get; set; }
        public virtual CinemaMovie CinemaMovie { get; set; }
        public virtual CinemaScreening CinemaScreening { get; set; }
    }
}