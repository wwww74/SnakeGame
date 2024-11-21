using Snake.ViewModels;

namespace Snake.Views;
public partial class GamePageView : ContentPage
{
	public GamePageView()
	{
		InitializeComponent();
		BindingContext = new GamePageViewModel(this);
	}
}