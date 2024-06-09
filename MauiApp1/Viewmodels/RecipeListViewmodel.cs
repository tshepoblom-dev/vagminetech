using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.Views;
using System.Collections.ObjectModel;

namespace MauiApp1.Viewmodels
{
    public partial class RecipeListViewmodel : ObservableObject, IQueryAttributable
    {

        //used for testing
        private bool _isNavigationCalled;
        private string _navigationTarget;
        public bool IsNavigationCalled
        {
            get { return _isNavigationCalled; }
            set { SetProperty(ref _isNavigationCalled, value); }
        }

        public string NavigationTarget
        {
            get { return _navigationTarget; }
            set { SetProperty(ref _navigationTarget, value); }
        }


        [ObservableProperty]
        ObservableCollection<Recipe> recipes;
        IApiService _apiService;

        [ObservableProperty]
        Recipe selectedRecipe;
        public RecipeListViewmodel(IApiService apiService)
        {
            _apiService = apiService;
            Recipes = new ObservableCollection<Recipe>();
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var category = (Category)query["categoryId"];
            Recipes = new ObservableCollection<Recipe>(await _apiService.GetRecipesByCategory(category.strCategory));
        }

        [RelayCommand]
        public async Task GoToRecipeDetail(Recipe recipe)
        {
            var navParam = new Dictionary<string, object> { {"recipeId", recipe } };
            await Shell.Current.GoToAsync(nameof(RecipeDetail), navParam);

            // Set properties for testing
            IsNavigationCalled = true;
            NavigationTarget = nameof(RecipeDetail);
        }
    }
}
