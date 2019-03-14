using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CodeFirstDatabase
{
    public class Recipe
    {
        public int RecipeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Yield { get; set; }

        [StringLength(50)]
        public string ServingSize { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Directions { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        [Required]
        [StringLength(30)]
        public string RecipeType { get; set; }
    }
}
