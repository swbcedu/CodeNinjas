using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
// Adding system directives
using System.IO;
using System.Xml.Linq;
using CodeFirstDatabase;

namespace XMLManager
{
	public class ExportXML
	{
		public bool filesWritten = false;
		public bool ExportXMLMethod()
		{
			// Instantiate Entity Dataabase
			CodeFirst codeFirst = new CodeFirst();
			// Get current Directory which is the same drive that contains the assembly for your application.
			var getcurrentpath = Directory.GetCurrentDirectory();  //this is not a search - its a hard coded 'put files here'

			try
			{   //roe.Database.Connection.Open();
				//Console.WriteLine("Connection Established");

				// Get All the records using List and XDocument from Recipes Table

				//List<RecipeCF> RList = codeFirst.Recipes.ToList();
				/*
				if (RList.Count > 0)
				{
					{
						XDocument xD = new XDocument(
						new XDeclaration("1.0", "UTF-8", "yes"),
						new XComment("Contents of Recipes table in RecipeOrganizer database"),
						new XElement("Recipes",
								from rsc in RList
								select new XElement("Recipe",
											new XElement("RecipeID", rsc.RecipeID),
											new XElement("Title", rsc.Title),
											new XElement("RecipeType", rsc.RecipeType),
											new XElement("ServingSize", rsc.ServingSize),
											new XElement("Yield", rsc.Yield),
											new XElement("Directions", rsc.Directions),
											new XElement("Comment", rsc.Comment))));
						xD.Save(Path.Combine(getcurrentpath, "Recipes.xml"));
					}
				}

				// Get All the records using List and XDocument from Ingredients Table
				//List<IngredientCF> IList = codeFirst.Ingredients.ToList();
				if (IList.Count > 0)
				{
					{
						XDocument xD = new XDocument(
						new XDeclaration("1.0", "UTF-8", "yes"),
						new XComment("Contents of Ingredients table in RecipeOrganizer database"),
						new XElement("Ingredients",
								from id in IList
								select new XElement("Ingredient",
											new XElement("IngredientID", id.IngredientID),
											new XElement("RecipeID", id.RecipeID),
											new XElement("Description", id.Description))));
						xD.Save(Path.Combine(getcurrentpath, "Ingredients.xml"));
					}
				}
				*/


				//  Console.ReadKey();
				//roe.Database.Connection.Close();
				// roe.Dispose();

				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}