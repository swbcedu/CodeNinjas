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
    public class Ingredient
    {
        public int IngredientID { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public int RecipeID { get; set; }
    }
}
