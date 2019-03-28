using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    public partial class Recipe : IComparable<Recipe>
    {
        public Recipe(Recipe recipe)
        {
            this.Comment = recipe.Comment;
            this.Directions = recipe.Directions;
            this.Ingredients = recipe.Ingredients;
            this.RecipeID = recipe.RecipeID;
            this.RecipeType = recipe.RecipeType;
            this.ServingSize = recipe.ServingSize;
            this.Title = recipe.Title;
            this.Yield = recipe.Yield;
        }

        public int CompareTo(Recipe other)
        {
            string recipeTitle = RecipeType + Title;
            string otherRecipeTitle = other.RecipeType + other.Title;
            return recipeTitle.CompareTo(otherRecipeTitle);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
