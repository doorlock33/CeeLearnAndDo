using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CeeLearnAndDo.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Titel")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Artikel")]
        public string Content { get; set; }
        [Required]
        [Display(Name = "Datum")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Afbeelding")]
        public string Picture { get; set; }

        public ApplicationUser User { get; set; }
        [ScaffoldColumn(false)]
        public string UserId { get; set; }
    }
}