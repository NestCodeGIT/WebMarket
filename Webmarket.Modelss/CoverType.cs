using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webmarket.Modelss
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Title muss geschrieben werden")]
        [DisplayName(" Title")]
        public string? Name { get; set; }

    }
}
