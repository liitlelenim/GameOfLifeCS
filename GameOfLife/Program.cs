using GameOfLife;
using Raylib_cs;

Raylib.InitWindow(GameSettings.InitialWindowWidth, GameSettings.InitialWindowHeight, GameSettings.WindowTitle);
Raylib.SetTargetFPS(60);
while (!Raylib.WindowShouldClose())
{
    Raylib.PollInputEvents();
}

Raylib.CloseWindow();