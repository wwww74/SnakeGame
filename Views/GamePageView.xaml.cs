using Snake.Interfaces;
using Snake.ViewModels;

namespace Snake.Views;
public partial class GamePageView : ContentPage
{
	private readonly IDatabaseService _databaseService;
	public GamePageView()
	{
		InitializeComponent();

        _databaseService = Application.Current.MainPage.Handler.MauiContext.Services.GetService<IDatabaseService>();

        BindingContext = new GamePageViewModel(this, _databaseService);
	}
}