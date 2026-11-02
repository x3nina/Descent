namespace Descent;

public sealed record ObstacleDefinition(Rectangle SourceRectangle, bool BlocksMovement);

public static class ObstacleDefinitions
{
    public static readonly ObstacleDefinition Rock =
        new(new Rectangle(256, 0, 128, 128), BlocksMovement: true);

    // public static readonly ObstacleDefinition MossyRock =
    //     new(new Rectangle(128, 0, 128, 128), BlocksMovement: true);

}

public class Obstacle
{
    public Sprite Sprite { get; }
    public int Row { get; }
    public int Column { get; }
    public ObstacleDefinition Definition { get; }
    public bool BlocksMovement => Definition.BlocksMovement;

    public Obstacle(int row, int column, Texture2D texture, ObstacleDefinition definition)
    {
        Row = row;
        Column = column;
        Definition = definition;
        Sprite = new Sprite(texture, definition.SourceRectangle)
        {
            Position = new Vector2(Column * 128, (Row * 128) + 92)
        };
    }
}