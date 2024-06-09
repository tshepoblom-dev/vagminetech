using Microsoft.VisualStudio.TestTools.UnitTesting;
using MauiApp1.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Models;
using MauiApp1.Views;
using MauiApp1.Services;
using Moq;

namespace MauiApp1.Viewmodels.Tests
{
    [TestClass()]
    public class RecipeListViewmodelTests
    {
        private RecipeListViewmodel _recipeListViewModel;
        private Mock<IApiService> _mockApiService;

        [TestInitialize]
        public void SetUp()
        {
            _mockApiService = new Mock<IApiService>();
            _recipeListViewModel = new RecipeListViewmodel(_mockApiService.Object);
        }

        [TestCleanup]
        public void TearDown()
        {
            _mockApiService.Reset();
            _recipeListViewModel = null;
        }

        [TestMethod()]
        public async Task ApplyQueryAttributes_LoadsRecipesByCategory()
        {
            // Arrange
            var category = new Category { strCategory = "Starter", idCategory = "10", strCategoryDescription = "An entrée in modern French table service and that of much of the English-speaking world (apart from the United States and parts of Canada) is a dish served before the main course of a meal; it may be the first dish served, or it may follow a soup or other small dish or dishes. In the United States and parts of Canada, an entrée is the main dish or the only dish of a meal.\r\n\r\nHistorically, the entrée was one of the stages of the “Classical Order” of formal French table service of the 18th and 19th centuries. It formed a part of the “first service” of the meal, which consisted of potage, hors d’œuvre, and entrée (including the bouilli and relevé). The “second service” consisted of roast (rôti), salad, and entremets (the entremets sometimes being separated into a “third service” of their own). The final service consisted only of dessert.[3]:3–11 :13–25" , strCategoryThumb = "https://www.themealdb.com/images/category/starter.png" };
            var recipes = new List<Recipe>
            {
                new Recipe { strMeal ="Broccoli & Stilton soup", strMealThumb="https://www.themealdb.com/images/media/meals/tvvxpv1511191952.jpg", idMeal="52842" },
                new Recipe { strMeal = "Clam chowder", strMealThumb = "https://www.themealdb.com/images/media/meals/rvtvuw1511190488.jpg", idMeal="52840" },
                new Recipe { strMeal = "Cream Cheese Tart", strMealThumb = "https://www.themealdb.com/images/media/meals/wurrux1468416624.jpg", idMeal= "52779" },
                new Recipe { strMeal = "Creamy Tomato Soup", strMealThumb = "https://www.themealdb.com/images/media/meals/stpuws1511191310.jpg", idMeal = "52841" }
            };

            _mockApiService.Setup(x => x.GetRecipesByCategory(category.strCategory)).ReturnsAsync(recipes);

            var query = new Dictionary<string, object>
            {
                { "categoryId", category }
            };

            // Act
            _recipeListViewModel.ApplyQueryAttributes(query);

            // Assert
            Assert.AreEqual(recipes.Count, _recipeListViewModel.Recipes.Count);
            // Additional assertions can be made on individual recipe properties if needed
        }

        [TestMethod()]
        public async Task GoToRecipeDetail_NavigatesToRecipeDetail()
        {
            // Arrange
            var recipe = new Recipe
            {
                idMeal = "52842",
                strMeal = "Broccoli & Stilton soup",
                strDrinkAlternate = null,
                strCategory = "Starter",
                strArea = "British",
                strInstructions = @"Heat the rapeseed oil in a large saucepan and then add the onions. Cook on a medium heat until soft. Add a splash of water if the onions start to catch.

Add the celery, leek, potato and a knob of butter. Stir until melted, then cover with a lid. Allow to sweat for 5 minutes. Remove the lid.

Pour in the stock and add any chunky bits of broccoli stalk. Cook for 10 – 15 minutes until all the vegetables are soft.

Add the rest of the broccoli and cook for a further 5 minutes. Carefully transfer to a blender and blitz until smooth. Stir in the stilton, allowing a few lumps to remain. Season with black pepper and serve.",
                strMealThumb = "https://www.themealdb.com/images/media/meals/tvvxpv1511191952.jpg",
                strTags = null,
                strYoutube = "https://www.youtube.com/watch?v=_HgVLpmNxTY",
                strIngredient1 = "Rapeseed Oil",
                strIngredient2 = "Onion",
                strIngredient3 = "Celery",
                strIngredient4 = "Leek",
                strIngredient5 = "Potatoes",
                strIngredient6 = "Butter",
                strIngredient7 = "Vegetable Stock",
                strIngredient8 = "Broccoli",
                strIngredient9 = "Stilton Cheese",
                strIngredient10 = "",
                strIngredient11 = "",
                strIngredient12 = "",
                strIngredient13 = "",
                strIngredient14 = "",
                strIngredient15 = "",
                strIngredient16 = "",
                strIngredient17 = "",
                strIngredient18 = "",
                strIngredient19 = "",
                strIngredient20 = "",
                strMeasure1 = "2 tblsp ",
                strMeasure2 = "1 finely chopped ",
                strMeasure3 = "1",
                strMeasure4 = "1 sliced",
                strMeasure5 = "1 medium",
                strMeasure6 = "1 knob",
                strMeasure7 = "1 litre hot",
                strMeasure8 = "1 Head chopped",
                strMeasure9 = "140g",
                strMeasure10 = "",
                strMeasure11 = "",
                strMeasure12 = "",
                strMeasure13 = "",
                strMeasure14 = "",
                strMeasure15 = "",
                strMeasure16 = "",
                strMeasure17 = "",
                strMeasure18 = "",
                strMeasure19 = "",
                strMeasure20 = "",
                strSource = "https://www.bbcgoodfood.com/recipes/1940679/broccoli-and-stilton-soup",
                strImageSource = null,
                strCreativeCommonsConfirmed = null,
                dateModified = null
            };

            // Act
            await _recipeListViewModel.GoToRecipeDetail(recipe);

            // Assert
            Assert.IsTrue(_recipeListViewModel.IsNavigationCalled);
            Assert.AreEqual(nameof(RecipeDetail), _recipeListViewModel.NavigationTarget);
        }
      
    }
}