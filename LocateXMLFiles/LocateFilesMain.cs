using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Adding system IO directive
using System.IO;

/* This Class is to Locate XML Files, Ingredients.xml, Recipes.xml, 
*  by searching for them in the same drive that contains the assembly for your application. 
*/

namespace LocateXMLFiles
{
    public class LocateFilesMain
    {
        static void Main(string[] args)
        {
            var IngredientsXMLFiles = "Ingredients.xml";
            var RecipeXMLFiles = "Recipes.xml";

            // Call Method in LocateFiles class
            LocateFiles locatefiles = new LocateFiles();

            // search for the Ingredients XML File
            // The output might need a modification while calling from another class
            if (locatefiles.LocateFileMethod(IngredientsXMLFiles) == true)
            { Console.WriteLine(IngredientsXMLFiles + " File Exists"); }
            else
            { Console.WriteLine(IngredientsXMLFiles + " File DOES NOT Exists"); } // This message needs to be displayed in the 

            // search for the Recipe XML File
            // The output might need a modification while calling from another class
            if (locatefiles.LocateFileMethod(RecipeXMLFiles) == true)            
            { Console.WriteLine(RecipeXMLFiles + " File Exists"); }
            else
            { Console.WriteLine(RecipeXMLFiles + " File File DOES NOT Exists"); }


            // ******  Export XML Call  *******
            // Call Method in LocateFiles class
            ExportXML exportfiles = new ExportXML();

            // Call method to write for the XML File
            // The output might need a modification while calling from another class
            try
            {
                if (exportfiles.ExportXMLMethod() == true)
                { Console.WriteLine("The XML Files have been WRITTEN Successfully."); }
                else
                { Console.WriteLine("The XML Files Failed to WRITE"); } // This message needs to be displayed in the 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }
    }
}
