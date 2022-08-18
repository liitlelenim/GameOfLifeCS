using System.Numerics;
using GameOfLife.Engine;
using Raylib_cs;

namespace GameOfLife.Game;

public class Board : IDrawable
{
    private const int _chachedBoardSize = GameSettings.BoardSize;
    private const int _cachedCellSize = GameSettings.CellSize;
    private const int _boundary = _cachedCellSize * _chachedBoardSize;


    private bool[,] _cells = new bool[_chachedBoardSize, _chachedBoardSize];


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
}