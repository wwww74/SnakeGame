using CommunityToolkit.Maui.Views;
using Snake.ViewModels;

namespace Snake.Views;

public partial class GameOverPageView : Popup
{
	private GamePageViewModel _gamePage;
	public GameOverPageView(GamePageViewModel gamePageView)
	{
		InitializeComponent();
		_gamePage = gamePageView;
		BindingContext = new GameOverPageViewModel(_gamePage, this);
	}
}