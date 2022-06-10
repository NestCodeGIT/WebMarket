using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webmarket.Modelss
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Name Firma")]
        public string Name { get; set; }

        [Display(Name = "Name Straße")]
        public string? StreetAddress { get; set; }

        [Display(Name = "Name Stadt")]
        public string? City { get; set; }

        [Display(Name = "TelefonNummer")]
        public string? PhonNumber { get; set; }

    }
}
