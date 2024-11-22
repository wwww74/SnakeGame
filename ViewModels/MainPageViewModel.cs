using CommunityToolkit.Maui.Views;
using Snake.Base;
using Snake.Views;
using System.Windows.Input;

namespace Snake.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private MainPageView _mainPage;
        public MainPageViewModel(MainPageView mainPage)
        {
            _mainPage = mainPage;

            ExitCommand = new RelayCommand(ExitButtonClick);
            StartGameCommand = new RelayCommand(StartGameButton_Click);
            ScoreCommand = new RelayCommand(ScoreButton_Click);
        }
        #region ICommand
        public ICommand ExitCommand { get; }
        public ICommand StartGameCommand { get; }
        public ICommand ScoreCommand { get; }
        #endregion

        #region NavigationButton
        private void StartGameButton_Click(object parameter) => _mainPage.ShowPopupAsync(new SelectDifficultyPageView());
        private void ScoreButton_Click(object parameter) => _mainPage.ShowPopupAsync(new ScorePageView());
        private void ExitButtonClick(object parameter) => Application.Current.Quit();
        #endregion
    }
}
