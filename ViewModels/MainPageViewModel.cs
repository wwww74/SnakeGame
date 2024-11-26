using Snake.Base;
using Snake.Interfaces;
using Snake.Models;
using Snake.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Snake.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private bool _visibleLevelPanel;
        private bool _visibleScorePanel;
        private readonly IDatabaseService _databaseService;
        public ObservableCollection<ScoresModel> ScoreList { get; set; }
        public MainPageViewModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;

            StartGameCommand = new RelayCommand(StartGameButton_Click);
            HideLevelPanelCommand = new RelayCommand(HideLevelPanel_Click);
            SelectedDifficultyGameCommand = new RelayCommand(SelectedDifficult_Click);
            ScoreCommand = new RelayCommand(ScoreButton_Click);
            HideScorePanelCommand = new RelayCommand(HideScorePanel_Click);
            ExitCommand = new RelayCommand(ExitButtonClick);

            VisibleLevelPanel = false;
            VisibleScorePanel = false;

            ScoreList = new ObservableCollection<ScoresModel>();
        }

        #region ICommand
        public ICommand StartGameCommand { get; }
        public ICommand HideLevelPanelCommand { get; }
        public ICommand SelectedDifficultyGameCommand { get; }
        public ICommand ScoreCommand { get; }
        public ICommand HideScorePanelCommand { get; }
        public ICommand ExitCommand { get; }
        #endregion

        #region ViewProperty
        public bool VisibleLevelPanel
        {
            get => _visibleLevelPanel;
            set
            {
                _visibleLevelPanel = value;
                OnPropertyChanged(nameof(VisibleLevelPanel));
            }
        }
        public bool VisibleScorePanel
        {
            get => _visibleScorePanel;
            set
            {
                _visibleScorePanel = value;
                OnPropertyChanged(nameof(VisibleScorePanel));
            }
        }
        #endregion

        #region NavigationButton
        private void StartGameButton_Click(object parameter) => VisibleLevelPanel = !VisibleLevelPanel;
        private void HideLevelPanel_Click(object parameter) => VisibleLevelPanel = false;
        private async void SelectedDifficult_Click(object parameter)
        {
            VisibleLevelPanel = false;
            await Shell.Current.GoToAsync(nameof(GamePageView), true, new Dictionary<string, object> { { "parameter", parameter } });
        }
        private void ScoreButton_Click(object parameter)
        {
            VisibleScorePanel = true;
            _databaseService.GetFiveHighScores().ForEach(p =>
            {
                ScoreList.Add(new ScoresModel { Id = ScoreList.Count + 1, Difficulty = p.Difficulty, Score = p.Score });
            });
        }
        private void HideScorePanel_Click(object parameter)
        {
            VisibleScorePanel = false;
            ScoreList.Clear();
        }
        private void ExitButtonClick(object parameter) => Application.Current.Quit();
        #endregion
    }
}
