using Microsoft.EntityFrameworkCore;
using Snake.Infrastructure;
using Snake.Interfaces;
using Snake.Models;

namespace Snake.Services
{
    public class DatabaseService(ApplicationContext context) : IDatabaseService
    {
        public bool Add(ScoresModel scoresModel)
        {
            try
            {
                context.Scores.Add(scoresModel);
                context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public List<ScoresModel> GetFiveHighScores() => context.Scores.FromSqlRaw("SELECT * FROM Scores ORDER BY Score DESC LIMIT 5").ToList();
        public int GetHighScore(string difficulty)
        {
            try { return context.Scores.ToList().Where(p => p.Difficulty == difficulty).Max(p => p.Score ); }
            catch { return 0; }
        }
        public int GetMaxIdScore()
        {
            try { return context.Scores.ToList().Max(p => p.Id); }
            catch { return 0; }
        }
    }
}
