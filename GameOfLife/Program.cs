using GameOfLife;
using GameOfLife.Engine;
using Raylib_cs;


InputHandler inputHandler = new();
List<ITickable> tickables = new();

CameraController cameraController = new(inputHandler);

tickables.Add(cameraController);

Raylib.InitWindow(GameSettings.InitialWindowWidth, GameSettings.InitialWindowHeight, GameSettings.WindowTitle);
Raylib.SetTargetFPS(60);


while (!Raylib.WindowShouldClose())
{
    float deltaTime = Raylib.GetFrameTime();
    foreach (ITickable tickable in tickables)
    {
        tickable.Tick(deltaTime);
    }

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLACK);
    Raylib.BeginMode2D(cameraController.Camera);
    Raylib.EndMode2D();
    Raylib.EndDrawing();
    inputHandler.CheckForInputs();
}

Raylib.CloseWindow();