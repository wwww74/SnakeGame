using Snake.Base;
using System.Windows.Input;

namespace Snake.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            ExitCommand = new RelayCommand(ExitButtonClick);
        }
        public ICommand ExitCommand { get; }
        private void ExitButtonClick(object parameter) => Application.Current.Quit();
    }
}
