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
	[Table("Recipes")]
    public class RecipeCF
    {
		[Key]
		public int RecipeID { get; set; }

		[Required, MaxLength(50)]
        public string Title { get; set; }

		//[Required]
        public string Yield { get; set; }

        [MaxLength(200)]
        public string ServingSize { get; set; }

        [Required]
        public string Directions { get; set; }

        public string Comment { get; set; }

        [Required, MaxLength(30)]
        public string RecipeType { get; set; }
		public virtual ICollection<IngredientCF> Ingredients { get; set; }
    }
}
