using MauiApp1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class ApiService : IApiService
    {
        HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;   
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            try
            {
                var _uri = $"categories.php";
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, _uri);
                HttpResponseMessage responseMessage = await _httpClient.SendAsync(message);
                responseMessage.EnsureSuccessStatusCode();
                var responseBody = await responseMessage.Content.ReadAsStringAsync();
                //var obj = JsonConvert.DeserializeObject<IEnumerable<Category>>(responseBody);
                //return obj.Categories;
                CategoriesList response = JsonConvert.DeserializeObject<CategoriesList>(responseBody);
                return response.Categories;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
            }
            return null;
        }
        public async Task<IEnumerable<Recipe>> GetRecipesByCategory(string strCategory)
        {
            try
            {
                var _uri = $"filter.php?c={strCategory}";
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, _uri);
                HttpResponseMessage responseMessage = await _httpClient.SendAsync(message);
                responseMessage.EnsureSuccessStatusCode();
                var responseBody = await responseMessage.Content.ReadAsStringAsync();
                //var obj = JsonConvert.DeserializeObject<IEnumerable<Recipe>>(responseBody);
                //return obj;
                RecipesList response = JsonConvert.DeserializeObject<RecipesList>(responseBody);
                return response.Meals;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
            }
            return null;
        }
        public async Task<Recipe> GetRecipe(string recipeId)
        {
            try
            {
                var _uri = $"lookup.php?i={recipeId}";
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, _uri);
                HttpResponseMessage responseMessage = await _httpClient.SendAsync(message);
                responseMessage.EnsureSuccessStatusCode();
                var responseBody = await responseMessage.Content.ReadAsStringAsync();
                //var obj = JsonConvert.DeserializeObject<Recipe>(responseBody);
                //return obj;
                RecipesList response = JsonConvert.DeserializeObject<RecipesList>(responseBody);
                return response.Meals.FirstOrDefault();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
            }
            return null;
        }

    }
}
