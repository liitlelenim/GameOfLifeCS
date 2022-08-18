using System.Numerics;
using GameOfLife.Game;
using Raylib_cs;

namespace GameOfLife.Engine;

public class CameraController : ITickable
{
    private Camera2D _camera;
    private Vector2 _cameraPosition = Vector2.Zero;
    private float _cameraSpeed = GameSettings.CameraSpeed;

    private readonly InputHandler _inputHandler;

    public Camera2D Camera => _camera;

    public CameraController(InputHandler inputHandler)
    {
        _camera = new Camera2D();
        _camera.zoom = 1f;
        _inputHandler = inputHandler;
        Vector2 boardMiddle = new Vector2(
            -GameSettings.CellSize * GameSettings.BoardSize - GameSettings.StartingCameraXOffset,
            -GameSettings.CellSize * GameSettings.BoardSize);
        _cameraPosition = boardMiddle;
        _camera.target = _cameraPosition;
    }

    public void Tick(float deltaTime)
    {
        Vector2 inputDirection = Vector2.Zero;
        if (_inputHandler.IsWKeyBeingPressed)
        {
            inputDirection.Y--;
        }

        if (_inputHandler.IsSKeyBeingPressed)
        {
            inputDirection.Y++;
        }

        if (_inputHandler.IsAKeyBeingPressed)
        {
            inputDirection.X--;
        }

        if (_inputHandler.IsDKeyBeingPressed)
        {
            inputDirection.X++;
        }

        _cameraPosition += inputDirection * deltaTime * _cameraSpeed;

        _camera.zoom += GameSettings.CameraZoomSpeed * _inputHandler.MouseWheelDelta * deltaTime;
        _camera.zoom = Math.Clamp(_camera.zoom, GameSettings.CameraMinZoom, GameSettings.CameraMaxZoom);
        _camera.target = _cameraPosition;

        _inputHandler.Camera = Camera;
    }
}