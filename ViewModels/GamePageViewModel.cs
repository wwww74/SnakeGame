﻿using Snake.Base;
using Snake.Enumerated;
using Snake.Interfaces;
using Snake.Models;
using System.Windows.Input;

namespace Snake.ViewModels
{
    public class GamePageViewModel : BaseViewModel
    {
        #region GameVariable
        private bool _visibleStartButton = true;
        private bool _continueGame;
        private int _rowCount = 10;
        private int _columnCount = 10;
        private const int SPEED = 500;
        private int _snakeSpeed = SPEED;
        private float _speedBoost = 0.95f;
        private int _scoreCount;
        private int _highScore;
        private string _nameDifficulty;
        public string Difficulty;

        private SnakeModel _snake;
        private MoveDirection _currentMoveDirection = MoveDirection.Right;
        private CellViewModel _lastFood;
        private bool _visibleGameOverPanel;
        public List<List<CellViewModel>> GameArea { get; } = new List<List<CellViewModel>>();

        private readonly IDatabaseService _databaseService;
        private readonly IWindowService _windowService;
        #endregion

        public GamePageViewModel(IDatabaseService databaseService, IWindowService windowService)
        {
            _databaseService = databaseService;
            _windowService = windowService;

            VisibleStartButton = true;
            VisibleGameOverPanel = false;
            ScoreLabel = -1;
            HighScoreLabel = 0;
            Difficulty = Preferences.Get("difficulty", "1");

            StartGameCommand = new RelayCommand(StartGameButton_Click);
            MoveUpCommand = new RelayCommand(MoveUpButton_Click);
            MoveDownCommand = new RelayCommand(MoveDownButton_Click);
            MoveLeftCommand = new RelayCommand(MoveLeftButton_Click);
            MoveRightCommand = new RelayCommand(MoveRightButton_Click);
            RestartGameCommand = new RelayCommand(RestartGameButton_Click);
            ShowMenuCommand = new RelayCommand(ShowMenuButton_Click);

            for (int row = 0; row < _rowCount; row++)
            {
                var rowList = new List<CellViewModel>();

                for (int column = 0; column < _columnCount; column++)
                {
                    var cell = new CellViewModel(row, column);
                    rowList.Add(cell);
                }

                GameArea.Add(rowList);
            }

            _snake = new SnakeModel(GameArea, GameArea[_rowCount / 2][_columnCount / 2], CreateFood);
            CreateFood();
        }

        #region ICommand
        public ICommand StartGameCommand { get; }
        public ICommand RestartGameCommand { get; }
        public ICommand ShowMenuCommand { get; }
        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }
        public ICommand MoveLeftCommand { get; }
        public ICommand MoveRightCommand { get; }
        #endregion

        #region ICommandMethods
        private void RestartGameButton_Click(object parameter)
        {
            RestartGame();
            VisibleGameOverPanel = false;
        }
        private void ShowMenuButton_Click(object parameter)
        {
            VisibleGameOverPanel = false;
            Application.Current.MainPage = _windowService.GetAndCreateContentPage<MainPageViewModel>().View;
        }
        #endregion

        #region ViewProperty
        public bool ContinueGame
        {
            get => _continueGame;
            set
            {
                _continueGame = value;
                OnPropertyChanged(nameof(ContinueGame));

                if (_continueGame) SnakeGo();
            }
        }
        public bool VisibleStartButton
        {
            get => _visibleStartButton;
            set
            {
                _visibleStartButton = value;
                OnPropertyChanged(nameof(VisibleStartButton));
            }
        }
        public bool VisibleGameOverPanel
        {
            get => _visibleGameOverPanel;
            set
            {
                _visibleGameOverPanel = value;
                OnPropertyChanged(nameof(VisibleGameOverPanel));
            }
        }
        public int ScoreLabel
        {
            get => _scoreCount;
            set
            {
                _scoreCount = value;
                OnPropertyChanged(nameof(ScoreLabel));
            }
        }
        public int HighScoreLabel
        {
            get => _highScore;
            set
            {
                _highScore = value;
                OnPropertyChanged(nameof(HighScoreLabel));
            }
        }
        #endregion

        #region MoveButton
        private void MoveUpButton_Click(object parameter)
        {
            if (_currentMoveDirection != MoveDirection.Down)
            {
                _currentMoveDirection = MoveDirection.Up;
            }
        }
        private void MoveDownButton_Click(object parameter)
        {
            if (_currentMoveDirection != MoveDirection.Up)
                _currentMoveDirection = MoveDirection.Down;
        }
        private void MoveLeftButton_Click(object parameter)
        {
            if (_currentMoveDirection != MoveDirection.Right)
                _currentMoveDirection = MoveDirection.Left;
        }
        private void MoveRightButton_Click(object parameter)
        {
            if (_currentMoveDirection != MoveDirection.Left)
                _currentMoveDirection = MoveDirection.Right;
        }
        #endregion

        #region GameMethods
        private void StartGameButton_Click(object parameter)
        {
            ContinueGame = !ContinueGame;
            VisibleStartButton = false;
        }
        private async Task SnakeGo()
        {
            switch (Difficulty)
            {
                case "1":
                    _nameDifficulty = "Легкий";
                    _snakeSpeed = SPEED;
                    _speedBoost = 0.95f;
                    break;
                case "2":
                    _nameDifficulty = "Нормальный";
                    _snakeSpeed = 400;
                    _speedBoost = 0.85f;
                    break;
                case "3":
                    _nameDifficulty = "Сложный";
                    _snakeSpeed = 300;
                    _speedBoost = 0.80f;
                    break;
            }

            HighScoreLabel = _databaseService.GetHighScore(_nameDifficulty);

            while (ContinueGame)
            {
                await Task.Delay(_snakeSpeed);

                try
                {
                    _snake.Move(_currentMoveDirection);
                }
                catch (Exception)
                {
                    ContinueGame = false;
                    _databaseService.Add(new ScoresModel { Id = _databaseService.GetMaxIdScore() + 1, Difficulty = _nameDifficulty, Score = ScoreLabel });
                    VisibleGameOverPanel = true;
                }
            }
        }
        private void CreateFood()
        {
            var rnd = new Random();
            int row = rnd.Next(0, _rowCount);
            int column = rnd.Next(0, _columnCount);

            _lastFood = GameArea[row][column];

            if (_snake.SnakeCells.Contains(_lastFood))
                CreateFood();

            _lastFood.CellType = CellType.Food;
            ScoreLabel++;
            _snakeSpeed = (int)(_snakeSpeed * _speedBoost);
        }
        public void RestartGame()
        {
            VisibleStartButton = true;
            ScoreLabel = -1;
            HighScoreLabel = _databaseService.GetHighScore(_nameDifficulty);
            _snakeSpeed = SPEED;
            _speedBoost = 0.95f;
            _snake.Restart();
            _lastFood.CellType = CellType.None;
            CreateFood();
        }
        #endregion
    }
}
