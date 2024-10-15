using System.Numerics;
using Raylib_cs;

namespace Phader.GameObjects;
public abstract class Shape(string name) : GameObject(name)
{
    public bool Filled { get; private set; } = true;
    public Color FillColor { get; private set; } = Color.Blank;
    public bool Outlined { get; private set; } = false;
    public Color OutlineColor { get; private set; } = Color.Blank;
    public float OutlineThickness { get; private set; } = 1;

    public Shape Fill(Color fillColor)
    {
        Filled = true;
        FillColor = fillColor;
        return this;
    }

    public Shape NoFill()
    {
        Filled = false;
        FillColor = Color.Blank;
        return this;
    }

    public Shape Outline(Color outlineColor, float outlineThickness = 1)
    {
        Outlined = true;
        OutlineColor = outlineColor;
        OutlineThickness = outlineThickness;
        return this;
    }

    public Shape NoOutline()
    {
        Outlined = false;
        OutlineColor = Color.Blank;
        OutlineThickness = 1;
        return this;
    }
}

public class Rectangle(Vector2 size, string name) : Shape(name)
{
    public Rectangle(int width, int height, string name) : this(new Vector2(width, height), name) { }
    public Vector2 Size { get; } = size;

    internal override void Render()
    {
        var worldPosition = GetWorldPosition();
        var rect = new Raylib_cs.Rectangle(worldPosition.X, worldPosition.Y, Size.X, Size.Y);
        if (Filled)
        {
            Raylib.DrawRectanglePro(rect, Vector2.Zero, WorldRotation, FillColor);
        }

        if (Outlined)
        {
            Raylib.DrawRectangleLinesEx(rect, OutlineThickness, OutlineColor);
        }
    }
}
