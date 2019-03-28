﻿using System;
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
using System.Windows.Shapes;

namespace RecipeOrganizer
{
	/// <summary>
	/// Interaction logic for SearchWindow.xaml
	/// </summary>
	public partial class SearchWindow : Window
	{
		public SearchWindow()
		{
			InitializeComponent();
		}

		private void SearchRecipesButton_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}

		public string UserEntry
		{
			get { return userSearchEntry.Text; }
		}
	}
}
