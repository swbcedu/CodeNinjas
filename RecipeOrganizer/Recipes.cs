using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseFirst;

namespace RecipeOrganizer
{
    public class Recipes
    {
        List<Recipe> recipes = new List<Recipe>();
        
        public List<Recipe> RecipeObjects
        {
            get { return recipes; }
        }

        public Recipe this[int index]
        {
            get { return recipes[index]; }
            set { recipes.Add(value); }
        }

        public void RecipeSort()
        {
            recipes.Sort();
        }
    }
}
