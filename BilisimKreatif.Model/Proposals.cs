using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BilisimKreatif.Model
{
    public class Proposal : BaseEntity
    {
        [Display(Name = "Teklif Verilen Firma")]
        public string CompanyName { get; set; }
        [Display(Name = "Firma Yetkilisin Adı")]
        public string Authorize { get; set; }
        [Display(Name = "Teklif İçerigi")]
        public string ProposalContext { get; set; }
        [Display(Name = "Teklif Verilen Firmanın Telefon Numarası")]
        public string Phone { get; set; }
        [Display(Name = "Firma E-posta Adresi")]
        public string Email { get; set; }
    }
}
