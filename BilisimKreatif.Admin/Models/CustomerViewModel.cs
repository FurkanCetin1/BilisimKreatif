using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BilisimKreatif.Admin.Models
{
    public class CustomerViewModel
    {
        public string Id { get; set; }
        [Display(Name="Ad")]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [MaxLength(200, ErrorMessage = "{0} çok uzun.")]
        public string FirstName { get; set; }
        [Display(Name="Soyad")]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [MaxLength(200, ErrorMessage = "{0} çok uzun.")]
        public string LastName { get; set; }
        [Display(Name="Telefon")]
        [Phone(ErrorMessage = "Telefon formatı geçersiz.")]
        [MaxLength(20, ErrorMessage = "{0} çok uzun.")]
        public string Phone { get; set; }
        [Display(Name="E-posta")]
        [MaxLength(200, ErrorMessage = "{0} çok uzun.")]
        [EmailAddress(ErrorMessage = "E-posta adresi geçersiz.")]
        public string Email { get; set; }
    }
}
