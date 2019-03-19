using System;
using System.Data.Entity;
using System.Linq;
using System.Configuration;

namespace CodeFirstDatabase
{
	public partial class CodeFirst : DbContext
	{
		#region comments
		// Your context has been configured to use a 'CodeFirst' connection string from your application's 
		// configuration file (App.config or Web.config). By default, this connection string targets the 
		// 'CodeFirstDatabase.CodeFirst' database on your LocalDb instance. 
		// 
		// If you wish to target a different database and/or database provider, modify the 'CodeFirst' 
		// connection string in the application configuration file.
		// the Application  has been modified to point to the local DB=- 
		#endregion
		public CodeFirst() : base("CodeFirst") { }
        public DbSet<IngredientCF> Ingredients { get; set; }
        public DbSet<RecipeCF> Recipes { get; set; }
	}
}