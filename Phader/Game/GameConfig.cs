using Phader.Scenes;
using Raylib_cs;

namespace Phader;
public struct GameConfig
{
    public int WindowWidth;
    public int WindowHeight;
    public string WindowTitle;
    public Scene InitialScene;
    public List<Scene> Scenes;
    public int FPS;
    public Color ClearColor;
}
public class GameConfigBuilder(int windowWidth, int windowHeight, string windowTitle)
{
    private Scene _initialScene = null!;
    private readonly List<Scene> _scenes = [];
    private int _fps = 60;
    private Color _clearColor = Color.Blank;
    public GameConfigBuilder SetFPS(int fps)
    {
        _fps = fps;
        return this;
    }
    public GameConfigBuilder WithInitialScene<T>() where T : Scene, new()
    {
        _initialScene = new T();
        return this;
    }
    public GameConfigBuilder WithScene<T>() where T : Scene, new()
    {
        _scenes.Add(new T());
        return this;
    }
    public GameConfigBuilder SetClearColor(Color clearColor)
    {
        _clearColor = clearColor;
        return this;
    }
    public GameConfig Build()
    {
        return new GameConfig()
        {
            FPS = _fps,
            WindowWidth = windowWidth,
            WindowHeight = windowHeight,
            WindowTitle = windowTitle,
            InitialScene = _initialScene,
            Scenes = _scenes,
            ClearColor = _clearColor
        };
    }
}
