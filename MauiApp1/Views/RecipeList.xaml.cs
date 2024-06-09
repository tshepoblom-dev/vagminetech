using MauiApp1.Viewmodels;

namespace MauiApp1.Views;

public partial class RecipeList : ContentPage
{
	
	public RecipeList(RecipeListViewmodel recipeListViewmodel)
	{
		BindingContext = recipeListViewmodel;
		InitializeComponent();
	}
}