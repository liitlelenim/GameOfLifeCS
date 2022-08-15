using GameOfLife;
using Raylib_cs;

InputHandler inputHandler = new();

Raylib.InitWindow(GameSettings.InitialWindowWidth, GameSettings.InitialWindowHeight, GameSettings.WindowTitle);
Raylib.SetTargetFPS(60);


while (!Raylib.WindowShouldClose())
{
    
    inputHandler.CheckForInputs();
}

Raylib.CloseWindow();