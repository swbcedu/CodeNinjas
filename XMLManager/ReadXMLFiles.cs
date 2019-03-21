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
using DatabaseFirst;

namespace XMLManager
{
    public class ReadXMLFiles
    {
        /// <summary>
        /// Query loaded XDocument to place recipe data into a List collection. 
        /// </summary>
        public static List<Recipe> GetRecipeDataFromXDocument()
        {
            //Get contents of XML file using LINQ to XML.
            var recipesXML = (
                from r in XDocument.Load(GetFullFileName("Recipes.xml")).Descendants("Recipe")
                select r).ToList();

            // Set up collection to store contents from XML file
            List<Recipe> recipes = new List<Recipe>(recipesXML.Count);

            Recipe recipe = null;

            // Store contents from LINQ to XML into List collection
            foreach (var r in recipesXML)
            {
                recipe = new Recipe();

                //Filling the recipe object
                recipe.RecipeID = int.Parse(r.Element("RecipeID").Value);
                recipe.Title = r.Element("Title").Value;
                recipe.Directions = r.Element("Directions").Value;
                recipe.RecipeType = r.Element("RecipeType").Value;

                // Retrieve optional elements
                foreach (XElement x in r.Elements())
                {
                    switch (x.Name.ToString())
                    {
                        case "ServingSize":
                            recipe.ServingSize = r.Element("ServingSize").Value;
                            break;
                        case "Comment":
                            recipe.Comment = r.Element("Comment").Value;
                            break;
                        case "Yield":
                            recipe.Yield = r.Element("Yield").Value;
                            break;
                    }
                }

                //Appending the row to the List collection
                recipes.Add(recipe);
            }

            return recipes;
        }

        /// <summary>
        /// Query loaded XDocument to place ingredient data into a List collection. 
        /// </summary>
        public static List<Ingredient> GetIngredientDataFromXDocument()
        {
            //Get contents of XML file using LINQ to XML.
            var ingredientsXML = (
                from i in XDocument.Load(GetFullFileName("Ingredients.xml")).Descendants("Ingredient")
                select i).ToList();

            // Set up collection to store contents from XML file
            List<Ingredient> ingredients = new List<Ingredient>(ingredientsXML.Count);

            Ingredient ingredient = null;

            // Store contents from LINQ to XML into List collection
            foreach (var i in ingredientsXML)
            {
                ingredient = new Ingredient();

                ingredient.IngredientID = int.Parse(i.Element("IngredientID").Value);
                ingredient.Description = i.Element("Description").Value;
                ingredient.RecipeID = int.Parse(i.Element("RecipeID").Value);

                //Appending the row to the List collection
                ingredients.Add(ingredient);
            }

            return ingredients;
        }

        internal static string GetFullFileName(string fileNameString)
        {
            DirectoryInfo rootDirectory = null;
            FileInfo[] files = null;

            try
            {
                rootDirectory =
                    new DirectoryInfo(@"..\..\..\");
            }
            catch
            {
                return null;
            }

            files =
                rootDirectory.GetFiles(fileNameString, SearchOption.AllDirectories);

            if (files.GetLength(0) == 0)
            {
                return null;
            }

            return files[0].FullName;
        }
    }
}
