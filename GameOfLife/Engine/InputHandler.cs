using System.Numerics;
using Raylib_cs;

namespace GameOfLife.Engine;

public class InputHandler
{
    public float MouseWheelDelta { get; private set; } = 0f;
    public bool IsMouseLeftButtonClicked { get; private set; } = false;
    public bool IsMouseRightButtonClicked { get; private set; } = false;

    public bool IsWKeyBeingPressed { get; private set; } = false;
    public bool IsSKeyBeingPressed { get; private set; } = false;
    public Vec2 MousePositionInWorld { get; private set; }

    public bool IsAKeyBeingPressed { get; private set; } = false;
    public bool IsDKeyBeingPressed { get; private set; } = false;

    public Camera2D Camera { private get; set; }

    public void CheckForInputs()
    {
        IsMouseLeftButtonClicked = Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON);
        IsMouseRightButtonClicked = Raylib.IsMouseButtonPressed(MouseButton.MOUSE_RIGHT_BUTTON);

        Vector2 tempMousePosition = Raylib.GetScreenToWorld2D(Raylib.GetMousePosition(), Camera);
        MousePositionInWorld = new Vec2((int)tempMousePosition.X, (int)tempMousePosition.Y);

        IsWKeyBeingPressed = Raylib.IsKeyDown(KeyboardKey.KEY_W);
        IsSKeyBeingPressed = Raylib.IsKeyDown(KeyboardKey.KEY_S);
        IsAKeyBeingPressed = Raylib.IsKeyDown(KeyboardKey.KEY_A);
        IsDKeyBeingPressed = Raylib.IsKeyDown(KeyboardKey.KEY_D);
        Raylib.PollInputEvents();
        MouseWheelDelta = Raylib.GetMouseWheelMove();
    }
}