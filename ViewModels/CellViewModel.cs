using Snake.Base;
using Snake.Enumerated;

namespace Snake.ViewModels
{
    public class CellViewModel : BaseViewModel
    {
        private CellType _cellType = CellType.None;
        public int Row { get; }
        public int Column { get; }
        public CellType CellType
        {
            get => _cellType;
            set
            {
                _cellType = value;
                OnPropertyChanged(nameof(CellType));
            }
        }

        public CellViewModel(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
