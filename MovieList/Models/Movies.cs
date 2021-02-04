using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Models
{
    public class Movies
    {
        [Required]
        public string category { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string year { get; set; }
        [Required]
        public string director { get; set; }
        [Required]
        public string rating { get; set; }
        public bool? edited { get; set; }
        public string lent_to { get; set; }
        public string notes { get; set; }


    }
}
