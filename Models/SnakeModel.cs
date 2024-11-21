using Snake.Enumerated;
using Snake.ViewModels;

namespace Snake.Models
{
    public class SnakeModel
    {
        private CellViewModel _start;
        private List<List<CellViewModel>> _gameArea;
        private Exception _gameOverEx = new Exception("Game Over");
        private Action _generateFood;
        public Queue<CellViewModel> SnakeCells { get; } = new Queue<CellViewModel>();

        public SnakeModel(List<List<CellViewModel>> gameArea, CellViewModel start, Action generateFood)
        {
            _start = start;
            _gameArea = gameArea;
            _generateFood = generateFood;
            _start.CellType = CellType.Snake;
            SnakeCells.Enqueue(start);
        }

        public void Move(MoveDirection moveDirection)
        {
            var headCell = SnakeCells.Last();
            int nextRow = headCell.Row;
            int nextColumn = headCell.Column;

            switch (moveDirection)
            {
                case MoveDirection.Left:
                    nextColumn--;
                    break;
                case MoveDirection.Right:
                    nextColumn++;
                    break;
                case MoveDirection.Up:
                    nextRow--;
                    break;
                case MoveDirection.Down:
                    nextRow++;
                    break;
                default:
                    break;
            }

            try
            {
                var nextCell = _gameArea[nextRow][nextColumn];

                switch (nextCell?.CellType)
                {
                    case CellType.None:
                        nextCell.CellType = CellType.Snake;
                        SnakeCells.Dequeue().CellType = CellType.None;
                        SnakeCells.Enqueue(nextCell);
                        break;
                    case CellType.Food:
                        nextCell.CellType = CellType.Snake;
                        SnakeCells.Enqueue(nextCell);
                        _generateFood?.Invoke();
                        break;
                    default:
                        throw _gameOverEx;
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                throw _gameOverEx;
            }
        }

        public void Restart()
        {
            foreach (var cell in SnakeCells)
            {
                cell.CellType = CellType.None;
            }
            SnakeCells.Clear();
            _start.CellType = CellType.Snake;
            SnakeCells.Enqueue(_start);
        }
    }
}
