using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseFirst;

namespace RecipeOrganizer
{
    class Dessert : Recipe
    {
        public Dessert(Recipe recipe) : base(recipe)
        {
        }

        public override string ToString()
        {
            return "D-" + base.Title;
        }
    }
}
