using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Adding system directives
using System.IO;
using System.Data;
using System.Xml.Linq;
using System.Data.Entity;
using CodeFirstDatabase;

namespace XMLManager
{
    class WriteXMLFiles
    {
        public static void LoadXDocumentsFromSQLTables()
        {
            using (CodeFirst recipeDB = new CodeFirst())
            {
                // Export Recipes table in RecipeOrganizer database to XML

                // Get all recipes.
                List<RecipeCF> recipes = recipeDB.GetRecipes();

                //create xml document from Recipes SQL table.
                XDocument document = new XDocument(
                  new XDeclaration("1.0", "utf-8", "yes"),
                  new XComment("Contents of Recipes table in RecipeOrganizer database"),
                  new XElement("Recipes",
                      from r in recipes  // Result is an IEnumerable<XElement> collection 
                      select new XElement("Recipe",
                                 new XElement("RecipeID", r.RecipeID),
                                 new XElement("Title", r.Title),
                                 new XElement("RecipeType", r.RecipeType),
                                 r.ServingSize == null ? null : new XElement("ServingSize", r.ServingSize),
                                 r.Yield == null ? null : new XElement("Yield", r.Yield),
                                 new XElement("Directions", r.Directions),
                                 r.Comment == null ? null : new XElement("Comment", r.Comment))
                     )
                );

                //save constructed document
                document.Save(ReadXMLFiles.GetFullFileName("Recipes.xml"));

                // Export Ingredients table in RecipeOrganizer database to XML

                // Get all ingredients.
                List<IngredientCF> ingredients = recipeDB.GetIngredients();

                //create xml document from Ingredients SQL table.
                document = new XDocument(
                  new XDeclaration("1.0", "utf-8", "yes"),
                  new XComment("Contents of Ingredients table in RecipeOrganizer database"),
                  new XElement("Ingredients",
                      from i in ingredients  // Result is an IEnumerable<XElement> collection 
                      select new XElement("Ingredient",
                             new XElement("IngredientID", i.IngredientID),
                             new XElement("RecipeID", i.RecipeID),
                             new XElement("Description", i.Description))
                  )
                );

                //save constructed document
                document.Save(ReadXMLFiles.GetFullFileName("Ingredients.xml"));
            }
        }
    }
}
