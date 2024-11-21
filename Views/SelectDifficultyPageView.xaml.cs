using CommunityToolkit.Maui.Views;
using Snake.ViewModels;

namespace Snake.Views;

public partial class SelectDifficultyPageView : Popup
{
	public SelectDifficultyPageView()
	{
		InitializeComponent();
		BindingContext = new SelectDifficultyPageViewModel(this);
	}
}