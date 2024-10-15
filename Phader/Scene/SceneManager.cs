using Phader.Debug;

namespace Phader.Scenes;
public class SceneManager
{
    private Scene? _currentScene;
    private readonly Dictionary<string, Scene> _scenes = new();

    public void Init(Scene startScene, List<Scene> scenes)
    {
        foreach (var scene in scenes)
        {
            _scenes.Add(scene.Name, scene);
        }
        
        _currentScene = startScene;
        startScene.CreateScene();
        _currentScene.StartScene();
    }

    public void SwitchTo(string name)
    {
        if (_scenes.TryGetValue(name, out var scene))
        {
            if (_currentScene != null && _currentScene.Name != name)
            {
                _currentScene.ShutdownScene();
            }
            else
            {
                Console.Error.WriteLine($"Scene '{name}' already started.");
                return;
            }

            _currentScene = scene;
            if (!scene.Created)
            {
                _currentScene.CreateScene();
            }

            _currentScene.StartScene();
        }
        else
        {
            throw new Exceptions.SceneKeyNotFoundException($"Scene '{name}' not found.");
        }
    }

    internal void Update(float delta)
    {
        _currentScene?.UpdateScene(delta);
    }

    internal void Render()
    {
        _currentScene?.RenderScene();
    }
}
