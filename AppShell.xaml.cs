using Snake.Views;

namespace Snake
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GamePageView), typeof(GamePageView));
            Routing.RegisterRoute(nameof(MainPageView), typeof(MainPageView));
        }
    }
}
