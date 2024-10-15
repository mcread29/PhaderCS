using Phader;
using Phader.Scenes;
using Raylib_cs;

namespace PhaderCS;
public static class Phader
{
    public static SceneManager Scene { get; } = new();
    private static GameConfig _config;

    public static void Init(GameConfig gameConfig)
    {
        _config = gameConfig;
        Raylib.InitWindow(_config.WindowWidth, _config.WindowHeight, _config.WindowTitle);
    }

    public static void Run()
    {
        Scene.Init(_config.InitialScene, _config.Scenes);

        while (!Raylib.WindowShouldClose())
        {
            Scene.Update(Raylib.GetFrameTime());

            Raylib.BeginDrawing();
            Raylib.ClearBackground(_config.ClearColor);

            // render scene stuff here
            Scene.Render();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}