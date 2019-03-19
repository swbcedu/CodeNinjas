using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Adding system IO directive
using System.IO;

/// This Class is to Locate XML Files, Ingredients.xml, Recipes.xml, 
/// by searching for them in the same drive that contains the assembly for your application. 

namespace LocateXMLFiles
{
    public class LocateFiles
    {
        public bool LocateFileMethod(string XMLFile)
        {
            bool filexists = false;

            // Get current Directory which is the same drive that contains the assembly for your application.
            var getcurrentpath = System.IO.Directory.GetCurrentDirectory();
            DirectoryInfo projectDirectory = new DirectoryInfo(getcurrentpath);

            // declation to get all the files directly under the project directory
            FileInfo[] files = projectDirectory.GetFiles();

            // loop through each file to match the needed files
            foreach (var filename in files)
            {
                if ((filename.ToString() == XMLFile))
                {
                    filexists = true;
                }
        }
            return filexists;
        }
    }
}