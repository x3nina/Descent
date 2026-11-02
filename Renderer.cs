namespace Descent;

public class Renderer
{
    private readonly GraphicsDevice _graphicsDevice;

    public Renderer(GraphicsDevice graphicsDevice)
    {
        _graphicsDevice = graphicsDevice;
    }

    public void Draw(SpriteBatch spriteBatch, Sprite playerSprite, Sprite rockSprite, Sprite trapSprite, Texture2D bg)
    {
        _graphicsDevice.Clear(Color.Black);
        spriteBatch.Begin();

        spriteBatch.Draw(bg, Vector2.Zero, Color.White);

        spriteBatch.Draw(
            rockSprite.Texture,
            rockSprite.Position,
            rockSprite.SourceRectangle,
            rockSprite.Color,
            rockSprite.Rotation,
            rockSprite.Origin,
            rockSprite.Scale,
            rockSprite.Effects,
            rockSprite.LayerDepth);

        spriteBatch.Draw(
            trapSprite.Texture,
            trapSprite.Position,
            trapSprite.SourceRectangle,
            trapSprite.Color,
            trapSprite.Rotation,
            trapSprite.Origin,
            trapSprite.Scale,
            trapSprite.Effects,
            trapSprite.LayerDepth);

        spriteBatch.Draw(
            playerSprite.Texture,
            playerSprite.Position,
            playerSprite.SourceRectangle,
            playerSprite.Color,
            playerSprite.Rotation,
            playerSprite.Origin,
            playerSprite.Scale,
            playerSprite.Effects,
            playerSprite.LayerDepth);

        
        spriteBatch.End();
    }
}