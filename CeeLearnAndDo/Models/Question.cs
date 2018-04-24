using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CeeLearnAndDo.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Titel")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Vraag")]
        public string Description { get; set; }
        [Display(Name = "Geplaatst op")]
        public DateTime CreatedAt { get; set; }

        public ApplicationUser User { get; set; }

        [Display(Name = "Antwoord")]
        public string Content { get; set; }

        [Display(Name = "Goedgekeurd")]
        public bool Approved { get; set; }
    }
}