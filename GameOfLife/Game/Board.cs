using System.Numerics;
using System.Text.Json;
using GameOfLife.Engine;
using Raylib_cs;

namespace GameOfLife.Game;

public class Board : IDrawable, ITickable
{
    private const int _chachedBoardSize = GameSettings.BoardSize;
    private const int _cachedCellSize = GameSettings.CellSize;
    private const int _boundary = _cachedCellSize * _chachedBoardSize;
    private InputHandler _input;

    private float _gameTickTimer = 0.0f;
    private bool _isGameRunning = false;

    private bool[,] _cells = new bool[_chachedBoardSize, _chachedBoardSize];

    public Board(InputHandler inputHandler)
    {
        _input = inputHandler;
    }

    public void Draw()
    {
        for (int x = 0; x < _chachedBoardSize; x++)
        {
            for (int y = 0; y < _chachedBoardSize; y++)
            {
                if (_cells[x, y] == true)
                {
                    Vec2 _cellPosition = CoordsToPosition(x, y);
                    Raylib.DrawRectangle(_cellPosition.X, _cellPosition.Y, _cachedCellSize, _cachedCellSize,
                        Color.WHITE);
                }
            }
        }

        for (int i = 0; i <= _chachedBoardSize; i++)
        {
            //Vertical Line
            Vec2 lineStartVertical = CoordsToPosition(i, 0);
            Vec2 lineEndVertical = CoordsToPosition(i, _chachedBoardSize);
            Raylib.DrawLine(lineStartVertical.X, lineStartVertical.Y, lineEndVertical.X, lineEndVertical.Y,
                Color.WHITE);
            //Horizontal line
            Vec2 lineStartHorizontal = CoordsToPosition(-0, i);
            Vec2 lineEndHorizontal = CoordsToPosition(_chachedBoardSize, i);
            Raylib.DrawLine(lineStartHorizontal.X, lineStartHorizontal.Y, lineEndHorizontal.X, lineEndHorizontal.Y,
                Color.WHITE);
        }
    }

    public Vec2 CoordsToPosition(int x, int y) =>
        new Vec2(-_boundary + x * _cachedCellSize, -_boundary + y * _cachedCellSize);

    public Vec2 PositionToCords(Vec2 position) =>
        new Vec2((-_chachedBoardSize * _cachedCellSize + position.X) / _cachedCellSize + _chachedBoardSize * 2 - 1,
            (-_chachedBoardSize * _cachedCellSize + position.Y) / _cachedCellSize + _chachedBoardSize * 2 - 1);

    public void Tick(float deltaTime)
    {
        if (_isGameRunning)
        {
            _gameTickTimer += deltaTime;
        }

        if (_gameTickTimer >= GameSettings.GameTicKDuration)
        {
            GameOfLifeTick();
            _gameTickTimer = 0;
        }

        if (_input.IsMouseLeftButtonClicked)
        {
            Vec2 cords = PositionToCords(_input.MousePositionInWorld);
            bool inBounds = cords.X >= 0 && cords.Y >= 0 && cords.X < _chachedBoardSize && cords.Y < _chachedBoardSize;
            if (inBounds)
            {
                ToggleCell(cords);
            }
        }

        if (_input.IsSpaceBeingClicked)
        {
            _isGameRunning = !_isGameRunning;
        }
    }

    public void GameOfLifeTick()
    {
        bool[,] nextGeneration = new bool[_chachedBoardSize, _chachedBoardSize];
        for (int x = 0; x < _chachedBoardSize; x++)
        {
            for (int y = 0; y < _chachedBoardSize; y++)
            {
                int neighboursCount = GetNeighboursCount(x, y);
                if (_cells[x, y] == true)
                {
                    if (neighboursCount == 2 || neighboursCount == 3)
                    {
                        nextGeneration[x, y] = true;
                    }
                }
                else
                {
                    if (neighboursCount == 3)
                    {
                        nextGeneration[x, y] = true;
                    }
                }
            }
        }

        _cells = nextGeneration;
    }

    private int GetNeighboursCount(int x, int y)
    {
        int count = 0;
        if (x > 0 && _cells[x - 1, y])
        {
            count++;
        }

        if (x > 0 && y > 0 && _cells[x - 1, y - 1])
        {
            count++;
        }

        if (x > 0 && y < _chachedBoardSize-1 && _cells[x - 1, y + 1])
        {
            count++;
        }

        if (x < _chachedBoardSize-1 && _cells[x + 1, y])
        {
            count++;
        }

        if (x < _chachedBoardSize-1 && y > 0 && _cells[x + 1, y - 1])
        {
            count++;
        }

        if ((x < _chachedBoardSize-1 && y < _chachedBoardSize-1) && _cells[x + 1, y + 1])
        {
            count++;
        }

        if (y > 0 && _cells[x, y - 1])
        {
            count++;
        }

        if (y < _chachedBoardSize-1 && _cells[x, y + 1])
        {
            count++;
        }


        return count;
    }

    private void ToggleCell(Vec2 cords)
    {
        if (!_isGameRunning)
        {
            _cells[cords.X, cords.Y] = !_cells[cords.X, cords.Y];
        }
    }
}