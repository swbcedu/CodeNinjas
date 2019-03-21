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

            using (CodeFirst cfDB = new CodeFirst())
            {
                foreach(var recipe in recipes)
                {
                    RecipeCF r = new RecipeCF();

                    r.RecipeID = recipe.RecipeID;
                    r.Title = recipe.Title;
                    r.Yield = recipe.Yield;
                    r.ServingSize = recipe.ServingSize;
                    r.Directions = recipe.Directions;
                    r.Comment = recipe.Comment;
                    r.RecipeType = recipe.RecipeType;

                    cfDB.Recipes.Add(r);
                }

                try
                {
                    cfDB.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
                
            }

            //Console.WriteLine("");
        }
	}
}