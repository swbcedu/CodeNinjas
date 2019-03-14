using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ConsoleApplication1
{
    class exportToXML
    {
        static void Main(string[] args)
        {
            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter1;
            SqlDataAdapter adapter2;
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            string sqlingredients = null;
            string sqlrecipes = null;

            var xmlfoldername = System.IO.Directory.GetCurrentDirectory();
            var xmlIngredients = "Ingredients.xml";
            var xmlRecipes = "Recipes.xml";
            // **** UPDATE The connection string before you run.
            connetionString = "Data Source='MININT-8862EOM\\SQLEXPRESS';Initial Catalog=RecipeOrganizer;Integrated Security=SSPI;";
            connection = new SqlConnection(connetionString);
            sqlingredients = "select * from Ingredients";
            sqlrecipes = "select * from Recipes";

            try
            {
                connection.Open();
                adapter1 = new SqlDataAdapter(sqlingredients, connection);
                adapter1.Fill(ds1, "Ingredients");                
                ds1.WriteXml((Path.Combine(xmlfoldername, xmlIngredients)));

                adapter2 = new SqlDataAdapter(sqlrecipes, connection);
                adapter2.Fill(ds2, "Recipes");
                ds2.WriteXml((Path.Combine(xmlfoldername, xmlRecipes)));

                connection.Close();

                Console.WriteLine("Done");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }            
        }

    }
}
