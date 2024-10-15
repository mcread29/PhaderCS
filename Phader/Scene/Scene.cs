namespace Phader;
public abstract class Scene(string name)
{
    public readonly string Name = name;

    #region User Override Functions
    public abstract void Create();
    public abstract void Start();
    public abstract void PreUpdate(float delta);
    public abstract void PreRender();
    public abstract void Shutdown();
    public abstract void Destroy();

    #endregion

    public bool Created { get; private set; }
    public bool Started { get; private set; }

    private List<GameObject>? _updateList = [];

    #region Lifecycle

    internal void CreateScene()
    {
        Create();
        Created = true;
    }
    internal void StartScene()
    {
        Start();
        Started = true;
    }
    internal void UpdateScene(float delta)
    {
        PreUpdate(delta);
        if (_updateList == null) return;
        foreach (var obj in _updateList)
        {
            obj.Update(delta);
        }
    }

    internal void RenderScene()
    {
        PreRender();
        if (_updateList == null) return;
        foreach (var obj in _updateList)
        {
            obj.Render();
        }
    }

    internal void ShutdownScene()
    {
        Shutdown();
        Started = false;
    }

    internal void DestroyScene()
    {
        Destroy();
        Created = false;
        
        if (_updateList == null) return;
        foreach (var obj in _updateList)
        {
            obj.Destroy();
        }
        _updateList = null;
    }
    #endregion

    protected void AddGameObject(GameObject obj)
    {
        _updateList?.Add(obj);
    }
}
