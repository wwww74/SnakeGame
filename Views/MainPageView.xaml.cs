using Snake.Interfaces;
using Snake.ViewModels;

namespace Snake.Views
{
    public partial class MainPageView : ContentPage
    {
        private readonly IDatabaseService _databaseService;
        public MainPageView()
        {
            InitializeComponent();

            _databaseService = Application.Current.MainPage.Handler.MauiContext.Services.GetService<IDatabaseService>();

            BindingContext = new MainPageViewModel(_databaseService);
        }
    }
}
