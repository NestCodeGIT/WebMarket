using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMarket.Modelss;

namespace Webmarket.Modelss
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Der Titel muss geschrieben werden")]
        [DisplayName("Title")]
        [MaxLength(150, ErrorMessage = "Der Titel muss zwischen 1 bis 150 sein")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Der Description muss geschrieben werden")]
        [DisplayName("Description")]
        public string Description { get; set; }

        
        public string ShortDescription { get; set; }



        [Required(ErrorMessage = "Der Titel muss geschrieben werden")]
        [DisplayName("ISBN")]
        [MaxLength(15, ErrorMessage = "ISBN darf maximal 15 Zeichen lang sein")]
        public string ISBN { get; set; }


        [Required(ErrorMessage = "Der Name des Autors ist obligatorisch")]
        [DisplayName("Author")]
        [MaxLength(150, ErrorMessage = "Der Name des Autors darf maximal 150 Zeichen lang sein")]
        public string Author { get; set; }


        [Required(ErrorMessage = "Preisliste ist obligatorisch")]
        [DisplayName("Preisliste")]
        public double ListPrice { get; set; }


        [Required(ErrorMessage = "Der Preis ist verbindlich")]
        [DisplayName("Preis")]
        public double Price { get; set; }

       
        public double Price50 { get; set; }

      
        public double Price100 { get; set; }


        [ValidateNever]
        public string ImgeUrl { get; set; }


        [Required(ErrorMessage = "Die Kategorie ist obligatorisch")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }


        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }


        [Required(ErrorMessage = "CovrType ist obligatorisch")]
        [DisplayName("CovrType")]
        public int CoverTypeId { get; set; }


        [ForeignKey("CoverTypeId")]
        [ValidateNever]
        public CoverType CoverType { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;



    }
}
