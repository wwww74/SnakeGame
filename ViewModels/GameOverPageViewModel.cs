using Snake.Base;
using Snake.Views;
using System.Windows.Input;

namespace Snake.ViewModels
{
    public class GameOverPageViewModel : BaseViewModel
    {
        private GamePageViewModel _gamePage;
        private GameOverPageView _gameOverView;
        public GameOverPageViewModel(GamePageViewModel gamePageView, GameOverPageView gameOverPageView)
        {
            _gamePage = gamePageView;
            _gameOverView = gameOverPageView;

            RestartGameCommand = new RelayCommand(RestartGameButton_Click);
            ShowMenuCommand = new RelayCommand(ShowMenuButton_Click);
        }

        #region ICommand
        public ICommand RestartGameCommand { get; }
        public ICommand ShowMenuCommand { get; }
        #endregion

        private void RestartGameButton_Click(object parameter)
        {
            _gamePage.RestartGame();
            _gameOverView.Close();
        }
        private async void ShowMenuButton_Click(object parameter)
        {
            _gameOverView.Close();
            await Shell.Current.GoToAsync("..");
        }
    }
}
