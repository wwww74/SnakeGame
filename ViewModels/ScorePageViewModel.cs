using Snake.Base;
using Snake.Interfaces;
using Snake.Models;
using System.Collections.ObjectModel;

namespace Snake.ViewModels
{
    public class ScorePageViewModel : BaseViewModel
    {
        private readonly IDatabaseService _databaseService;
        public ObservableCollection<ScoresModel> ScoreList { get; set; }
        public ScorePageViewModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
            ScoreList = new ObservableCollection<ScoresModel>();

            _databaseService.GetFiveHighScores().ForEach(p =>
            {
                ScoreList.Add(new ScoresModel { Id = ScoreList.Count + 1, Score = p.Score });
            });
        }
    }
}
