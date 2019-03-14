using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Linq;

namespace ReadWriteXMLFiles
{
    public class ReadWriteXML
    {
        public static void OpenXMLDoc()
        {
            string recipesFileLocation = "../../../resources/Recipes.xml";
            string ingredientsFileLocation = "../../../resources/Ingredients.xml";
            List<XElement> recipeList = new List<XElement>();
            List<XElement> ingredientList = new List<XElement>();

            var recipesXDocument = XDocument.Load(recipesFileLocation).Descendants("Recipe");
            var ingredientXDocument = XDocument.Load(ingredientsFileLocation).Descendants("Ingredient");

            foreach (XElement recipe in recipesXDocument)
            {
                int recipeID = int.Parse(recipe.Element("RecipeID").ToString());
                string title = recipe.Element("Title").ToString();
                string recipeType = recipe.Element("RecipeType").ToString();
                string servingSize = recipe.Element("ServingSize").ToString();
                string yield = recipe.Element("Yield").ToString();
                string directions = recipe.Element("Directions").ToString();
                string comment = recipe.Element("Comment").ToString();

                Console.WriteLine(title);
                Console.WriteLine(recipeType);
                Console.WriteLine(servingSize);
                Console.WriteLine();

                //recipeList.Add(recipe);
            }


            Console.Write("Press ENTER to continue.");
            Console.ReadLine();

            Console.ReadLine();
        }
    }
}
