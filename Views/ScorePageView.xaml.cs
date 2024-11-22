using CommunityToolkit.Maui.Views;
using Snake.Interfaces;
using Snake.ViewModels;

namespace Snake.Views;

public partial class ScorePageView : Popup
{
	private readonly IDatabaseService _databaseService;
	public ScorePageView()
	{
		InitializeComponent();

        _databaseService = Application.Current.MainPage.Handler.MauiContext.Services.GetService<IDatabaseService>();

        BindingContext = new ScorePageViewModel(_databaseService);
	}
}