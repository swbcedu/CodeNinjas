using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirstDatabase;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int recsAdded = 0;

            using (CodeFirst db = new CodeFirst())
            {
                Recipe recipe = new Recipe
                {
                    Comment = "Fun Comment",
                    Directions = "New Directions",
                    RecipeType = "Object Recipe Type",
                    ServingSize = "Serves Sizes XS-XL",
                    Title = "Delicious Recipe",
                    Yield = "Yield. No you yield!"
                };

                Ingredient ingredient = new Ingredient()
                {
                    Description = "This is my cool description",
                    RecipeID = 1
                };

                db.Recipes.Add(recipe);
                db.Ingredients.Add(ingredient);
                recsAdded = db.SaveChanges();

                Recipe rec = (from r in db.Recipes
                              select r).FirstOrDefault();

                System.Console.WriteLine(rec.Comment.ToString());

                System.Console.ReadLine();
            }
        }
    }
}
