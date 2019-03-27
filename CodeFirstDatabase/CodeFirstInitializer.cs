using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DatabaseFirst;
using XMLManager;

namespace CodeFirstDatabase
{
	class CodeFirstInitializer : DropCreateDatabaseAlways<CodeFirst>
	{
		protected override void Seed(CodeFirst context)
		{
            List<Recipe> recipes = ReadXMLFiles.GetRecipeDataFromXDocument();
            List<Ingredient> ingredients = ReadXMLFiles.GetIngredientDataFromXDocument();

            foreach (Recipe recipe in recipes)
            {
                RecipeCF recipeCF = new RecipeCF
                {
                    RecipeID = recipe.RecipeID,
                    Title = recipe.Title,
                    Yield = recipe.Yield,
                    ServingSize = recipe.ServingSize,
                    Directions = recipe.Directions,
                    Comment = recipe.Comment,
                    RecipeType = recipe.RecipeType
                };

                List<Ingredient> recipeIngredients = (from i in ingredients
                                                      where i.RecipeID == recipe.RecipeID
                                                      select i).ToList();

                foreach (Ingredient ingredient in recipeIngredients)
                {
                    IngredientCF ingredientCF = new IngredientCF
                    {
                        Description = ingredient.Description,
                        Recipe = recipeCF
                    };

                    context.Ingredients.Add(ingredientCF);
                }

                context.SaveChanges();
            }
        }
	}
}