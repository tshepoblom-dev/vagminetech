using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Models;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Viewmodels
{
    public partial class RecipeDetailViewmodel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        Recipe recipe;

        IApiService _apiService;
        public RecipeDetailViewmodel(IApiService apiService)
        {
            _apiService = apiService;
            Recipe = new Recipe();
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var recipeId = (Recipe)query["recipeId"];
            Recipe = await _apiService.GetRecipe(recipeId.idMeal);
        }
    }
}
