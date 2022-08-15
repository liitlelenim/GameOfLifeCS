using GameOfLife;
using Raylib_cs;

InputHandler inputHandler = new();
List<ITickable> tickables = new();

Raylib.InitWindow(GameSettings.InitialWindowWidth, GameSettings.InitialWindowHeight, GameSettings.WindowTitle);
Raylib.SetTargetFPS(60);


while (!Raylib.WindowShouldClose())
{
    foreach (ITickable tickable in tickables)
    {
        tickable.Tick();
    }

    inputHandler.CheckForInputs();
}

Raylib.CloseWindow();