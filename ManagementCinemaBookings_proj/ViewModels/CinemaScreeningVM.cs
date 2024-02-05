using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManagementCinemaBookings.ViewModels
{
    public partial class CinemaScreeningVM
    {
        public int Id { get; set; }
        [DisplayName("Početak projekcije")]
        [Required(ErrorMessage = "Polje početak projekcije je obavezno za unos")]
        public DateTime ScreeningStart { get; set; }
        [DisplayName("Kraj projekcije")]
        [Required(ErrorMessage = "Polje kraj projekcije je obavezno za unos")]
        public DateTime ScreeningEnd { get; set; }
        [DisplayName("Prodana mjesta")]
        [Required(ErrorMessage = "Polje prodana mjesta je obavezno za unos")]
        public short SoldSeats { get; set; }
        public int HallId { get; set; }
        public int MovieId { get; set; }
    }
}