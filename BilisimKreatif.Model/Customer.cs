using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BilisimKreatif.Model
{
    public class Customer: BaseEntity
    {
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        [Display(Name = "Tam Ad")]
        public string FullName {  get { return FirstName + ' ' + LastName; } }
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [Display(Name = "E-posta")]
        public string Email { get; set; }
    }
}
