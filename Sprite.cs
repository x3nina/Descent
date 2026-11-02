namespace Descent;

public class Sprite
{
    public Texture2D Texture { get; }
    public Vector2 Position { get; set; } = Vector2.Zero;
    public Rectangle SourceRectangle { get; set; }
    public Color Color { get; set; } = Color.White;
    public float Rotation { get; set; } = 0.0f;
    public Vector2 Origin { get; set; } = Vector2.Zero;
    public Vector2 Scale { get; set; } = Vector2.One;
    public SpriteEffects Effects { get; set; } = SpriteEffects.None;
    public float LayerDepth { get; set; } = 0.0f;
    public Dictionary<string, Rectangle> Frames { get; } = new();

    /// <summary>
    /// Creates a new sprite using the specified source texture.
    /// </summary>
    /// <param name="texture">The texture to use for this sprite.</param>
    public Sprite(Texture2D texture)
    {
        Texture = texture;
        SourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
    }

    /// <summary>
    /// Creates a new sprite using the specified source texture and region.
    /// </summary>
    /// <param name="texture">The texture to use for this sprite.</param>
    /// <param name="sourceRectangle">The location of this sprite on the texture atlas.</param>
    public Sprite(Texture2D texture, Rectangle sourceRectangle)
    {
        Texture = texture;
        SourceRectangle = sourceRectangle;
    }

    /// <summary>
    /// Sets the origin of this sprite to the center.
    /// </summary>
    public void CenterOrigin()
    {
        Origin = new Vector2(SourceRectangle.Width, SourceRectangle.Height) * 0.5f;
    }

    public void AddFrame(string frameName, Rectangle sourceRectangle)
    {
        Frames.Add(frameName, sourceRectangle); // TODO: add if else to check if successfuly added
    }

    public void AddFrames(Dictionary<string, Rectangle> frames)
    {
        foreach (var k in frames)
        {
            Frames.TryAdd(k.Key, k.Value); // TODO: add if else to check if successfuly added
        }
    }

    public void ChangeFrame(string frameName)
    {
        if (Frames.TryGetValue(frameName, out Rectangle sourceRectangle))
        {
            SourceRectangle = sourceRectangle;
        }
        else
        {
            Console.WriteLine($"frame {frameName} not found");
        }
    }
}