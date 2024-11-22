using Snake.Models;

namespace Snake.Interfaces
{
    public interface IDatabaseService
    {
        bool Add(ScoresModel scoresModel);
        List<ScoresModel> GetFiveHighScores();
        int GetHighScore();
        int GetMaxIdScore();
    }
}
