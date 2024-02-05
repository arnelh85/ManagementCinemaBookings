using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManagementCinemaBookings.ViewModels
{
    public partial class CinemaHallVM
    {
        public int Id { get; set; }
        [DisplayName("Grad kina")]
        [Required(ErrorMessage = "Polje grad kina je obavezno za unos")]
        [StringLength(40, ErrorMessage = "Polje grad kina mora sadržavati maksimalno 40 karaktera")]
        public string CinemaCity { get; set; }
        [DisplayName("Adresa kina")]
        [Required(ErrorMessage = "Polje adresa kina je obavezno za unos")]
        [StringLength(50, ErrorMessage = "Polje adresa kina mora sadržavati maksimalno 50 karaktera")]
        public string CinemaAddress { get; set; }
        [DisplayName("Naziv kina")]
        [Required(ErrorMessage = "Polje naziv kina je obavezno za unos")]
        [StringLength(20, ErrorMessage = "Polje naziv kina mora sadržavati maksimalno 20 karaktera")]
        public string CinemaName { get; set; }
        [DisplayName("Naziv dvorane")]
        [Required(ErrorMessage = "Polje naziv dvorane je obavezno za unos")]
        [StringLength(10, ErrorMessage = "Polje naziv dvorane mora sadržavati maksimalno 10 karaktera")]
        public string HallName { get; set; }
        [DisplayName("Tip dvorane")]
        [Required(ErrorMessage = "Polje tip dvorane je obavezno za unos")]
        [StringLength(10, ErrorMessage = "Polje tip dvorane mora sadržavati maksimalno 10 karaktera")]
        public string HallType { get; set; }
        [DisplayName("Kapacitet sjedišta")]
        [Required(ErrorMessage = "Polje kapacitet sjedišta je obavezno za unos")]       
        [Range(70, 130, ErrorMessage = "Polje kapacitet sjedišta mora biti minimalno 70, a maksimalno 130")]
        public short SeatCapacity { get; set; }
    }
}