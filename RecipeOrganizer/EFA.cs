using System;
using System.Data.Entity;
using System.Linq;

namespace RecipeOrganizer
{
	public class EFA : DbContext
	{
		public EFA() : base("name=EFA")
		{
		}
	}
}