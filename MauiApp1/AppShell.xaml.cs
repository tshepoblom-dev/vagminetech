using MauiApp1.Views;

namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RecipeList), typeof(RecipeList));
            Routing.RegisterRoute(nameof(RecipeDetail), typeof(RecipeDetail));
        }
    }
}
