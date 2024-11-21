using CommunityToolkit.Maui.Views;
using Snake.ViewModels;

namespace Snake.Views;

public partial class ScorePageView : Popup
{
	public ScorePageView()
	{
		InitializeComponent();
		BindingContext = new ScorePageViewModel();
	}
}