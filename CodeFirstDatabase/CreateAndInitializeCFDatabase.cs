using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstDatabase
{
	public class CreateAndInitializeCFDatabase
	{
		public static void CreateAndInitializeDatabase()
		{
			Database.SetInitializer<CodeFirst>(new CodeFirstInitializer());
			using (CodeFirst context = new CodeFirst())
			{
				RecipeCF recipe = (from r in context.Recipes select r).FirstOrDefault();
			}
		}
	}
}
