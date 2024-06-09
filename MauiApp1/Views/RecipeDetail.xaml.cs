using MauiApp1.Viewmodels;

namespace MauiApp1.Views;

public partial class RecipeDetail : ContentPage
{
	public RecipeDetail(RecipeDetailViewmodel recipeDetailViewmodel)
	{
		BindingContext = recipeDetailViewmodel;
		InitializeComponent();
	}
}