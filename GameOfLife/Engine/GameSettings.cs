namespace GameOfLife.Engine;

public static class GameSettings
{
    public const string WindowTitle = "Game Of Life";
    public const int InitialWindowWidth = 800;
    public const int InitialWindowHeight = 600;

    public static float CameraSpeed = 150f;
    public static float CameraZoomSpeed = 2F;
    public static float CameraMinZoom = 0.1f;
    public static float CameraMaxZoom = 5f;
    public const int StartingCameraXOffset = 100;

    public const int BoardSize = 30;
    public const int CellSize = 20;

    public static float GameTicKDuration = 0.5f;
}