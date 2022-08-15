using Raylib_cs;

namespace GameOfLife;

public class InputHandler
{
    public float MouseWheelDelta { get; private set; } = 0f;
    public bool IsMouseLeftButtonClicked { get; private set; } = false;
    public bool IsMouseRightButtonClicked { get; private set; } = false;

    public bool IsWKeyBeingPressed { get; private set; } = false;
    public bool IsSKeyBeingPressed { get; private set; } = false;

    public bool IsAKeyBeingPressed { get; private set; } = false;
    public bool IsDKeyBeingPressed { get; private set; } = false;


    public void CheckForInputs()
    {
        Raylib.PollInputEvents();
        MouseWheelDelta = Raylib.GetMouseWheelMove();
        IsMouseLeftButtonClicked = Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT);
        IsMouseRightButtonClicked = Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT);

        IsWKeyBeingPressed = Raylib.IsKeyDown(KeyboardKey.KEY_W);
        IsSKeyBeingPressed = Raylib.IsKeyDown(KeyboardKey.KEY_S);
        IsAKeyBeingPressed = Raylib.IsKeyDown(KeyboardKey.KEY_A);
        IsDKeyBeingPressed = Raylib.IsKeyDown(KeyboardKey.KEY_D);
    }
}