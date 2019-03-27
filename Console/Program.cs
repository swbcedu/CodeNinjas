using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirstDatabase;
using RecipeOrganizer;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> searchSubject = new List<string>();
            List<string> keywords = new List<string>();

            bool wasItFound = false;
            List<int> foundIndexLocations = new List<int>();

            searchSubject.Add("The video is pretty mesmerizing on its own");
            searchSubject.Add("And so far, it looks pretty slick");
            searchSubject.Add("The Galaxy Fold is set to release on April 26th, starting at $1,980");
            searchSubject.Add("I didn’t see a crease on those like in other leaked videos.");

            keywords.Add("Video");
            keywords.Add("Galaxy Fold");
            keywords.Add("Galaxy");
            keywords.Add("CrEasE");
            keywords.Add("leaked");

            Search s = new Search(keywords, searchSubject);

            System.Console.ReadLine();

            //int recsAdded = 0; 

            //using (CodeFirst db = new CodeFirst())
            //{
            //    RecipeCF recipe = new RecipeCF
            //    {
            //        Comment = "Fun Comment",
            //        Directions = "New Directions",
            //        RecipeType = "Object Recipe Type",
            //        ServingSize = "Serves Sizes XS-XL",
            //        Title = "Delicious Recipe",
            //        Yield = "Yield. No you yield!"
            //    };

            //    IngredientCF ingredient = new IngredientCF()
            //    {
            //        Description = "This is my cool description",
            //        RecipeID = 1
            //    };

            //    db.Recipes.Add(recipe);
            //    db.Ingredients.Add(ingredient);
            //    recsAdded = db.SaveChanges();

            //    RecipeCF rec = (from r in db.Recipes
            //                  select r).FirstOrDefault();

            //    System.Console.WriteLine(rec.Comment.ToString());

            //    System.Console.ReadLine();
            //}
        }
    }
}
