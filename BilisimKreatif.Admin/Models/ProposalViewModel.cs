using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BilisimKreatif.Admin.Models
{
    public class ProposalViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Teklif Verilen Firma")]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [MaxLength(200, ErrorMessage = "{0} çok uzun.")]
        public string CompanyName { get; set; }
        [Display(Name = "Firma Yetkilisi")]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [MaxLength(200, ErrorMessage = "{0} çok uzun.")]
        public string Authorize { get; set; }
        [Display(Name = "Firma Numarası")]
        [Phone(ErrorMessage = "Telefon formatı geçersiz.")]
        [MaxLength(20, ErrorMessage = "{0} çok uzun.")]
        public string Phone { get; set; }
        [Display(Name = "Firma E-posta Adresi")]
        [MaxLength(200, ErrorMessage = "{0} çok uzun.")]
        [EmailAddress(ErrorMessage = "E-posta adresi geçersiz.")]
        public string Email { get; set; }
        [Display(Name = "Teklif İçerigi")]
        public string ProposalContext { get; set; }
    }
}