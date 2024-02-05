using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManagementCinemaBookings.ViewModels
{
    public partial class CinemaTicketBookingVM
    {
        public int Id { get; set; }
        [DisplayName("Naziv kupca")]
        [Required(ErrorMessage = "Polje naziv kupca je obavezno za unos")]
        [StringLength(40, ErrorMessage = "Polje naziv kupca mora sadržavati maksimalno 40 karaktera")]
        public string CustomerName { get; set; }
        [DisplayName("Dob kupca")]
        [Required(ErrorMessage = "Polje dob kupca je obavezno za unos")]
        [Range(18, 70, ErrorMessage = "Polje dob kupca mora biti minimalno 18, a maksimalno 70")]
        public short CustomerAge { get; set; }
        [DisplayName("Broj karte")]
        public int TicketNo { get; set; }
        [DisplayName("Cijena karte")]
        [Required(ErrorMessage = "Polje cijena karte je obavezno za unos")]
        public decimal TicketPrice { get; set; }
        [DisplayName("Valuta")]
        [Required(ErrorMessage = "Polje valuta je obavezno za unos")]
        [StringLength(5, ErrorMessage = "Polje valuta mora sadržavati maksimalno 5 karaktera")]
        public string Currency { get; set; }
        [DisplayName("Način plaćanja")]
        [Required(ErrorMessage = "Polje način plaćanja je obavezno za unos")]
        [StringLength(20, ErrorMessage = "Polje način plaćanja mora sadržavati maksimalno 20 karaktera")]
        public string PaymentMethod { get; set; }
        [DisplayName("Red sjedišta")]
        [Required(ErrorMessage = "Polje red sjedišta je obavezno za unos")]
        public byte SeatRow { get; set; }
        [DisplayName("Broj sjedišta")]
        [Required(ErrorMessage = "Polje broj sjedišta je obavezno za unos")]
        [StringLength(5, ErrorMessage = "Polje broj sjedišta mora sadržavati maksimalno 5 karaktera")]
        public string SeatNo { get; set; }
        [DisplayName("Tip sjedišta")]
        [Required(ErrorMessage = "Polje tip sjedišta je obavezno za unos")]
        [StringLength(10, ErrorMessage = "Polje tip sjedišta mora sadržavati maksimalno 10 karaktera")]
        public string SeatType { get; set; }
        public DateTime? TicketIssuanceDate { get; set; }
        public int MovieId { get; set; }
        public int ScreeningId { get; set; }
        public int EmployeeId { get; set; }
    }
}