namespace Descent;

public sealed record TrapDefinition(Rectangle SourceRectangleUnactive, Rectangle SourceRectangleActive, int Damage);

public static class TrapDefinitions
{
    public static readonly TrapDefinition SpikeTrap =
        new(new Rectangle(0, 0, 128, 128), new Rectangle(128, 0, 128, 128), Damage: 1);
}

public class Trap
{
    public Sprite Sprite { get; }
    public int Row { get; }
    public int Column { get; }
    public TrapDefinition Definition { get; }
    public int Damage => Definition.Damage;
    public bool IsActive { get; set; } = false;

    public Trap(int row, int column, Texture2D texture, TrapDefinition definition)
    {
        Row = row;
        Column = column;
        Definition = definition;
        Sprite = new Sprite(texture, definition.SourceRectangleUnactive)
        {
            Position = new Vector2(Column * 128, (Row * 128) + 92)
        };
        Sprite.AddFrame("active", definition.SourceRectangleActive);
        Sprite.AddFrame("unactive", definition.SourceRectangleUnactive);
    }

    public void Trigger(Entity.Entity target)
    {
        if (IsActive)
        {
            target.TakeDamage(Damage);
        }
    }

    private TimeSpan timer = TimeSpan.Zero;
    public void Update(GameTime gameTime)
    {
        if ((gameTime.TotalGameTime - timer) > TimeSpan.FromSeconds(2))
        {
            timer = gameTime.TotalGameTime;
            IsActive = !IsActive;
            if (IsActive)
            {
                Sprite.ChangeFrame("active");
            }
            else
            {
                Sprite.ChangeFrame("unactive");
            }
        }
    }
}