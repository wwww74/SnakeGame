using Snake.Interfaces;
using Snake.ViewModels;

namespace Snake.Views
{
    public partial class MainPageView : ContentPage
    {
        public MainPageView()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(this);
        }
    }
}
