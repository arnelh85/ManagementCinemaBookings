using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManagementCinemaBookings.ViewModels
{
    public partial class CinemaEmployeeVM
    {
        public int Id { get; set; }
        [DisplayName("Naziv")]
        [Required(ErrorMessage = "Polje naziv je obavezno za unos")]
        [StringLength(40, ErrorMessage = "Polje naziv mora sadržavati maksimalno 40 karaktera")]
        public string EmployeeName { get; set; }
        [DisplayName("Dob")]
        [Required(ErrorMessage = "Polje dob je obavezno za unos")]
        [Range(22, 65, ErrorMessage = "Polje dob mora biti minimalno 22, a maksimalno 65")]
        public short EmployeeAge { get; set; }
        [DisplayName("Spol")]
        [Required(ErrorMessage = "Polje spol je obavezno za unos")]
        [StringLength(10, ErrorMessage = "Polje spol mora sadržavati maksimalno 10 karaktera")]
        public string EmployeeGender { get; set; }
        [DisplayName("JMBG")]
        [Required(ErrorMessage = "Polje JMBG je obavezno za unos")]
        [StringLength(13, ErrorMessage = "Polje JMBG mora biti maksimalno 13")]
        public string EmployeePIDN { get; set; }
        [DisplayName("Država")]
        [Required(ErrorMessage = "Polje država je obavezno za unos")]
        [StringLength(40, ErrorMessage = "Polje država mora sadržavati maksimalno 40 karaktera")]
        public string EmployeeCountry { get; set; }               
        [DisplayName("Grad")]
        [Required(ErrorMessage = "Polje grad je obavezno za unos")]
        [StringLength(40, ErrorMessage = "Polje grad mora sadržavati maksimalno 40 karaktera")]
        public string EmployeeCity { get; set; }
        [DisplayName("Broj telefona")]
        [Required(ErrorMessage = "Polje broj telefona je obavezno za unos")]
        [StringLength(50, ErrorMessage = "Polje broj telefona mora sadržavati maksimalno 50 karaktera")]
        public string EmployeePhoneNumber { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Polje email je obavezno za unos")]
        [StringLength(50, ErrorMessage = "Polje email mora sadržavati maksimalno 50 karaktera")]       
        public string EmployeeEmailAddress { get; set; }
        [DisplayName("Šifra")]
        [Required(ErrorMessage = "Polje šifra je obavezno za unos")]
        [StringLength(1000, ErrorMessage = "Polje šifra mora sadržavati maksimalno 1000 karaktera")]
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }
        public int EmployeeTypeId { get; set; }
    }
}