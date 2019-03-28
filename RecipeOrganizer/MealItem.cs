using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseFirst;

namespace RecipeOrganizer
{
    class MealItem : Recipe
    {
        public MealItem(Recipe recipe) : base(recipe)
        {
        }

        public override string ToString()
        {
            return "M-" + base.Title;
        }
    }
}
