using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManagementCinemaBookings.ViewModels
{
    public partial class CinemaMovieVM
    {
        public int Id { get; set; }
        [DisplayName("Naziv filma")]
        [Required(ErrorMessage = "Polje naziv filma je obavezno za unos")]
        [StringLength(50, ErrorMessage = "Polje naziv filma mora sadržavati maksimalno 50 karaktera")]
        public string MovieName { get; set; }
        [DisplayName("Režiser filma")]
        [Required(ErrorMessage = "Polje režiser filma je obavezno za unos")]
        [StringLength(40, ErrorMessage = "Polje režiser filma mora sadržavati maksimalno 40 karaktera")]
        public string MovieDirector { get; set; }
        [DisplayName("Žanr filma")]
        [Required(ErrorMessage = "Polje žanr filma je obavezno za unos")]
        [StringLength(20, ErrorMessage = "Polje žanr filma mora sadržavati maksimalno 20 karaktera")]
        public string MovieGenre { get; set; }
        [DisplayName("Država filma")]
        [Required(ErrorMessage = "Polje država filma je obavezno za unos")]
        [StringLength(40, ErrorMessage = "Polje država filma mora sadržavati maksimalno 40 karaktera")]
        public string MovieIssuanceCountry { get; set; }
        [DisplayName("Godina filma")]
        [Required(ErrorMessage = "Polje godina filma je obavezno za unos")]
        public short MovieIssuanceYear { get; set; }
        [DisplayName("Trajanje filma")]
        [Required(ErrorMessage = "Polje trajanje filma je obavezno za unos")]
        public short MovieRuntime { get; set; }
    }
}