using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.Views;

namespace MauiApp1.Viewmodels
{
    public partial class MainPageViewmodel : ObservableObject
    {
        IApiService _apiService;

        [ObservableProperty]
        ObservableCollection<Category> categories;

        [ObservableProperty]
        Category selectedCategory;

        public MainPageViewmodel(IApiService apiService)
        {
            _apiService = apiService;
            Categories = new ObservableCollection<Category>();
            GetCategories();
        }

        async void GetCategories()
        {
            Categories = new ObservableCollection<Category>(await _apiService.GetCategories());
        }

        [RelayCommand]
        public async Task EnterCategory(Category category)
        {
            try 
            { 
                var navParam = new Dictionary<string, object> { {"categoryId", category } };
                await Shell.Current.GoToAsync(nameof(RecipeList), navParam);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
            }
        }
    }
}
