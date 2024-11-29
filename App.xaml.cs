using Snake.Interfaces;
using Snake.ViewModels;

namespace Snake
{
    public partial class App : Application
    {
        public App(IWindowService windowService)
        {
            InitializeComponent();
            MainPage = windowService.GetAndCreateContentPage<MainPageViewModel>().View;
        }
    }
}
