using GameOfLife;
using GameOfLife.Engine;
using GameOfLife.Game;
using Raylib_cs;


InputHandler inputHandler = new();
List<ITickable> tickables = new();
List<IDrawable> drawables = new();
CameraController cameraController = new(inputHandler);

tickables.Add(cameraController);

Board board = new Board();
drawables.Add(board);

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
    foreach (IDrawable drawable in drawables)
    {
        drawable.Draw();
    }

    Raylib.EndMode2D();
    Raylib.EndDrawing();
    inputHandler.CheckForInputs();
}

Raylib.CloseWindow();