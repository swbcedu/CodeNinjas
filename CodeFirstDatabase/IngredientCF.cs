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
	[Table("Ingredients")]
	public class IngredientCF
	{
		[Key]
		public int IngredientID { get; set; }

		[MaxLength(100), Required]
		public string Description { get; set; }

		[Required]
		public int RecipeID { get; set; }

		[ForeignKey("RecipeID")]
		public virtual RecipeCF Recipe { get; set; }
    }
}