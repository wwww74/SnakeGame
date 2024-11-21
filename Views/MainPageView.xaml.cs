using CommunityToolkit.Maui.Views;
using Snake.ViewModels;

namespace Snake.Views
{
    public partial class MainPageView : ContentPage
    {
        int count = 0;

        public MainPageView()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private async void StartGameButton_Clicked(object sender, EventArgs e) => await this.ShowPopupAsync(new SelectDifficultyPageView());
        private async void ScoreButton_Clicked(object sender, EventArgs e) => await this.ShowPopupAsync(new ScorePageView());
    }

}
