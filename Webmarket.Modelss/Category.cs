using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMarket.Modelss

{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title muss geschrieben werden")]
        [DisplayName("Category Title")]
        public string? Name { get; set; }



        [Range(1, 100, ErrorMessage = "Zwiscen 1-100 Schreiben")]
        public string? DesplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;

    }
}
