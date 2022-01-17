using System;
using System.Collections.Generic;
using System.Drawing;

namespace TuppersFormula
{
    public class Grid
    {
        private readonly bool[,] _grid;
        private readonly int _horizontalScale;
        private readonly int _verticalScale;
        private readonly Canvas _canvas;
        private readonly Dictionary<int, Point> _chosenCells;
        private bool _isRectangleOriginSelected;
        private Rectangle _rectangle;
        private Point _rectangleOriginPoint;
        private Point _rectangleSecondPoint;
        public event EventHandler<GridUpdatedEventArgs> GridUpdated;

        public Grid(int width, int height, int horizontalScale, int verticalScale)
        {
            _grid = new bool[width, height];
            _horizontalScale = horizontalScale;
            _verticalScale = verticalScale;
            _canvas = new Canvas(width * horizontalScale, height * verticalScale);
            _canvas.Clear(Color.White);
            _chosenCells = new Dictionary<int, Point>();
            _isRectangleOriginSelected = false;
            _rectangle = new Rectangle();
        }

        private void UpdateGrid()
        {
            GridUpdated?.Invoke(this, new GridUpdatedEventArgs(_canvas.DirectBitmap.Bitmap));
        }

        private int Clamp(int value, int min, int max)
        {
            return value < min ? min : (value > max ? max : value);
        }

        private Point GetCellFromCoordinates(int x, int y)
        {
            var i = Clamp(x / _horizontalScale, 0, _grid.GetLength(0) - 1);
            var j = Clamp(y / _verticalScale, 0, _grid.GetLength(1) - 1);

            return new Point(i, j);
        }

        public bool[,] GetGrid()
        {
            var grid = new bool[_grid.GetLength(0), _grid.GetLength(1)];

            for (var i = 0; i < _grid.GetLength(0); i++)
            {
                for (var j = 0; j < _grid.GetLength(1); j++)
                {
                    grid[i, j] = _grid[i, j];
                }
            }

            return grid;
        }

        public string GetBinaryFormat()
        {
            var binaryFormat = "";
            for (var i = 0; i < _grid.GetLength(0); i++)
            {
                for (var j = _grid.GetLength(1) - 1; j >= 0; j--)
                {
                    binaryFormat += _grid[i, j] ? "1" : "0";
                }
            }

            return binaryFormat;
        }

        public void UpdateGridFromMatrix(bool[,] matrix)
        {
            if (!(_grid.GetLength(0) == matrix.GetLength(0) &&
                _grid.GetLength(1) == matrix.GetLength(1)))
            {
                throw new Exception("Matrices dimensions do not match!");
            }

            _canvas.Clear(Color.White);

            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    _grid[i, j] = matrix[i, j];
                    var color = _grid[i, j] ? Color.Black : Color.White;
                    _canvas.FillCell(i * _horizontalScale, j * _verticalScale, _horizontalScale, _verticalScale, color);
                }
            }

            UpdateGrid();
        }

        public void ClearChosenCells()
        {
            _chosenCells.Clear();
            _isRectangleOriginSelected = false;
            _rectangle.X = 0;
            _rectangle.Y = 0;
            _rectangle.Width = 0;
            _rectangle.Height = 0;
            _rectangleOriginPoint.X = 0;
            _rectangleOriginPoint.Y = 0;
            _rectangleSecondPoint.X = 0;
            _rectangleSecondPoint.Y = 0;
        }

        public void AddChosenCell(int x, int y, DrawingStyle style)
        {
            switch (style)
            {
                case DrawingStyle.Draw:
                case DrawingStyle.Erase:
                {
                    var p = GetCellFromCoordinates(x, y);
                    var index = p.X + (p.Y * _grid.GetLength(0));
                    if (!_chosenCells.ContainsKey(index))
                    {
                        _chosenCells.Add(index, p);
                        var markUpColor = style == DrawingStyle.Draw ? Color.Blue : (style == DrawingStyle.Erase ? Color.Red : Color.Black);
                        _canvas.DrawCell(p.X * _horizontalScale, p.Y * _verticalScale, _horizontalScale, _verticalScale, markUpColor);
                    }
                }
                break;

                case DrawingStyle.RectangleDraw:
                case DrawingStyle.RectangleErase:
                {
                    if (!_isRectangleOriginSelected)
                    {
                        _rectangleOriginPoint = GetCellFromCoordinates(x, y);
                        _isRectangleOriginSelected = true;
                        _rectangleSecondPoint = GetCellFromCoordinates(x, y);
                    }
                    else
                    {
                        _rectangleSecondPoint = GetCellFromCoordinates(x, y);
                    }

                    for (var i = _rectangle.Location.X; i <= _rectangle.Right; i++)
                    {
                        for (var j = _rectangle.Location.Y; j <= _rectangle.Bottom; j++)
                        {
                            var previousColor = _grid[i, j] ? Color.Black : Color.White;
                            _canvas.FillCell(i * _horizontalScale, j* _verticalScale, _horizontalScale, _verticalScale, previousColor);
                        }
                    }

                    _rectangle.Location = new Point(
                        Math.Min(_rectangleOriginPoint.X, _rectangleSecondPoint.X),
                        Math.Min(_rectangleOriginPoint.Y, _rectangleSecondPoint.Y));
                    _rectangle.Size = new Size(
                        Math.Abs(_rectangleOriginPoint.X - _rectangleSecondPoint.X),
                        Math.Abs(_rectangleOriginPoint.Y - _rectangleSecondPoint.Y));

                    for (var i = _rectangle.Location.X; i <= _rectangle.Right; i++)
                    {
                        for (var j = _rectangle.Location.Y; j <= _rectangle.Bottom; j++)
                        {
                            var markUpColor = style == DrawingStyle.RectangleDraw ? Color.Blue : (style == DrawingStyle.RectangleErase ? Color.Red : Color.Black);
                            _canvas.DrawCell(i * _horizontalScale, j * _verticalScale, _horizontalScale, _verticalScale, markUpColor);
                        }
                    }
                }
                break;
            }
            
            UpdateGrid();
        }

        public void ApplyChosenCells(DrawingStyle drawingStyle)
        {
            switch (drawingStyle)
            {
                case DrawingStyle.Draw:
                case DrawingStyle.Erase:
                    foreach (var cell in _chosenCells.Values)
                    {
                        _grid[cell.X, cell.Y] = drawingStyle == DrawingStyle.Draw ? true : false;
                        var color = drawingStyle == DrawingStyle.Draw ? Color.Black : Color.White;
                        _canvas.FillCell(cell.X * _horizontalScale, cell.Y * _verticalScale, _horizontalScale, _verticalScale, color);
                    }
                    break;

                case DrawingStyle.RectangleDraw:
                case DrawingStyle.RectangleErase:
                    for (var i = _rectangle.Location.X; i <= _rectangle.Right; i++)
                    {
                        for (var j = _rectangle.Location.Y; j <= _rectangle.Bottom; j++)
                        {
                            _grid[i, j] = drawingStyle == DrawingStyle.RectangleDraw ? true : false;
                            var color = drawingStyle == DrawingStyle.RectangleDraw ? Color.Black : Color.White;
                            _canvas.FillCell(i * _horizontalScale, j * _verticalScale, _horizontalScale, _verticalScale, color);
                        }
                    }
                    break;
            }

            UpdateGrid();
        }

        public void NegateCells()
        {
            _canvas.Clear(Color.White);

            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    _grid[i, j] = !_grid[i, j];
                    var color = _grid[i, j] ? Color.Black : Color.White;
                    _canvas.FillCell(i * _horizontalScale, j * _verticalScale, _horizontalScale, _verticalScale, color);
                }
            }

            UpdateGrid();
        }

        private bool IsWithinBounds(int i, int j)
        {
            return i >= 0 && i < _grid.GetLength(0) && j >= 0 && j < _grid.GetLength(1);
        }

        public void MoveCells(Direction direction)
        {
            var incrementX = 0;
            var incrementY = 0;

            switch (direction)
            {
                case Direction.Right:
                    incrementX = 1;
                    break;
                case Direction.Left:
                    incrementX = -1;
                    break;
                case Direction.Up:
                    incrementY = -1;
                    break;
                case Direction.Down:
                    incrementY = 1;
                    break;
            }

            var newGrid = new bool[_grid.GetLength(0), _grid.GetLength(1)];

            for (int i = 0; i < newGrid.GetLength(0); i++)
            {
                for (int j = 0; j < newGrid.GetLength(1); j++)
                {
                    if (_grid[i, j] && IsWithinBounds(i + incrementX, j + incrementY))
                    {
                        newGrid[i + incrementX, j + incrementY] = true;
                    }
                }
            }

            UpdateGridFromMatrix(newGrid);
        }

        public void ClearGrid()
        {
            _canvas.Clear(Color.White);

            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    _grid[i, j] = false;
                }
            }

            UpdateGrid();
        }

        public void FlipGrid(FlipType flipType)
        {
            var newGrid = GetGrid();

            var width = newGrid.GetLength(0);
            var height = newGrid.GetLength(1);
            var flipX = false;
            var flipY = false;

            switch (flipType)
            {
                case FlipType.Horizontally:
                    flipX = true;
                    break;
                case FlipType.Vertically:
                    flipY = true;
                    break;
            }

            for (int i = 0; i < (flipX ? width / 2 : width); i++)
            {
                for (int j = 0; j < (flipY ? height / 2 : height); j++)
                {
                    var i1 = flipX ? width - i - 1 : i;
                    var j1 = flipY ? height - j - 1 : j;
                    var t = newGrid[i, j];
                    newGrid[i, j] = newGrid[i1, j1];
                    newGrid[i1, j1] = t;
                }
            }

            UpdateGridFromMatrix(newGrid);
        }
    }
}
