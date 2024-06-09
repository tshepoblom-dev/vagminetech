using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public interface  IApiService
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Recipe>> GetRecipesByCategory(string strCategory);
        Task<Recipe> GetRecipe(string recipeId);
    }
}
