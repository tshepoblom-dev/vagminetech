using MauiApp1.Viewmodels;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewmodel mainPageViewmodel)
        {
            BindingContext = mainPageViewmodel;
            InitializeComponent();
        }

    }

}
