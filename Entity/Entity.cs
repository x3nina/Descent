namespace Descent.Entity;

public abstract class Entity
{
    public Vector2 Position;
    public int Health;
    public bool IsAlive => Health > 0;

    public abstract void Update(GameTime gameTime, Level level);
    //public abstract void Draw(SpriteBatch spriteBatch);
}