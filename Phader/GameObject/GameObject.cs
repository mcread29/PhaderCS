using System.Numerics;

namespace Phader;

public class GameObject(string name = "GameObject")
{
    public string Name { get; } = name;
    protected Vector2 _position = new Vector2(0, 0);
    public Vector2 Scale { get; } = Vector2.One;
    public float Rotation { get; } = 0;
    public float WorldRotation => Rotation + Parent?.WorldRotation ?? 0;
    public GameObject? Parent { get; private set; }
    public List<GameObject> Children { get; } = [];
    public bool Visible { get; } = true;

    public GameObject AddChild(GameObject child)
    {
        child.Parent = this;
        Children.Add(child);
        return child;
    }

    public void SetPosition(Vector2 position)
    {
        _position = position;
    }

    public Vector2 GetPosition()
    {
        return _position;
    }

    public Vector2 GetWorldPosition()
    {
        var worldPosition = new Vector2(_position.X, _position.Y);
        if (Parent != null)
        {
            worldPosition += Parent.GetWorldPosition();
        }
        return worldPosition;
    }

    public virtual void Update(float delta) { }
    internal virtual void Render() { }
    public virtual void Destroy() { }
}
