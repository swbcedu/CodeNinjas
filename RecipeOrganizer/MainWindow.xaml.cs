using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CodeFirstDatabase;
using DatabaseFirst;
using XMLManager;

namespace RecipeOrganizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
			txtblkComments.Text = "";
			txtblkDirections.Text = "";
			txtblkRecipeType.Text = "";
			txtblkTitle.Text = "";
			txtblkYield.Text = "";
			txtblkServingSize.Text = "";


			try
            {
                CreateAndInitializeCFDatabase.CreateAndInitializeDatabase();

            }

            catch (Exception ex)
            {
                txtBlockErrors.Text = ex.Message;
            }

            // Query the database for all recipes
            // and populate to list
            using (RecipeOrganizerEntities recipeDB = new RecipeOrganizerEntities())
            {
                // Export Recipes table in RecipeOrganizer database to XML

                // Get all recipes.
                List<Recipe> recipes = (from r in recipeDB.Recipes
                                        orderby r.Title
                                        select r).ToList();

                foreach (var recipe in recipes)
                {
                    recipesListBox.Items.Add(recipe.Title);
                }

            }

            Console.ReadLine();
        }
		/*
        private void Window_Closed(object sender, EventArgs e)
        {
			//WriteXMLFiles.LoadXDocumentsFromSQLTables();
			var closeFromUI = new CloseFromUI();
			if (closeFromUI.ShowDialog() == true)
			{
				//
			}
		}
		*/

		private void Refresh_button_Click(object sender, RoutedEventArgs e)
		{
			//for the clearing of all populated controls on the form
			txtblkComments.Text = "";
			txtblkDirections.Text = "";
			txtblkRecipeType.Text = "";
			txtblkTitle.Text = "";
			txtblkYield.Text = "";
			txtblkServingSize.Text = "";
            txtblkIngredients.Items.Clear();
            //recipesListBox.Items.Clear(); //we still want the list of recipes, but "no recipe selected"
            recipesListBox.SelectedIndex = -1;
		}

		private void Exit_button_Click(object sender, RoutedEventArgs e)
		{
			//our custom close application button - 
			Close();
		}

        private void recipesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (recipesListBox.SelectedIndex != -1)
            {
                string title = recipesListBox.SelectedItem.ToString();
                Recipe recipe = new Recipe();
                List<Ingredient> ingredients = new List<Ingredient>();

                using (RecipeOrganizerEntities recipeDB = new RecipeOrganizerEntities())
                {
                    recipe = (from r in recipeDB.Recipes
                              where r.Title.Equals(title)
                              select r).FirstOrDefault();

                    ingredients = (from i in recipeDB.Ingredients
                                   where i.RecipeID.Equals(recipe.RecipeID)
                                   orderby i.IngredientID
                                   select i).ToList();
                }

                txtblkTitle.Text = title;
                txtblkYield.Text = recipe.Yield == null ? "" : recipe.Yield;
                txtblkServingSize.Text = recipe.ServingSize == null ? "" : recipe.ServingSize;
                txtblkDirections.Text = recipe.Directions == null ? "" : recipe.Directions;
                txtblkComments.Text = recipe.Comment == null ? "" : recipe.Comment;
                txtblkRecipeType.Text = recipe.RecipeType == null ? "" : recipe.RecipeType;

                txtblkIngredients.Items.Clear();
                foreach (Ingredient ingredient in ingredients)
                {
                    txtblkIngredients.Items.Add(ingredient.Description);
                }
            }
        }
    }
}