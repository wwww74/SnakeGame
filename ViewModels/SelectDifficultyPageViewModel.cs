using Snake.Base;
using Snake.Views;
using System.Windows.Input;

namespace Snake.ViewModels
{
    public class SelectDifficultyPageViewModel : BaseViewModel
    {
        private SelectDifficultyPageView _view;
        public int Difficulty { get; set; }
        public SelectDifficultyPageViewModel(SelectDifficultyPageView view)
        {
            _view = view;
            SelectedDifficultyGameCommand = new RelayCommand(SelectedDifficult_Click);
        }

        public ICommand SelectedDifficultyGameCommand { get; }

        private async void SelectedDifficult_Click(object parameter)
        {
            _view.Close();
            await Shell.Current.GoToAsync(nameof(GamePageView), true, new Dictionary<string, object> { { "parameter", parameter } });
        }
    }
}
