namespace Descent.Entity;

public abstract class Entity
{
    public float Speed { get; protected set; }
    public int MaxHealth { get; protected set; }
    public int Health { get; protected set; }
    public bool IsAlive => Health > 0;

    public Sprite Sprite { get; }

    protected Entity(Vector2 startPosition, int maxHealth, Sprite sprite)
    {
        Sprite = sprite;
        Sprite.Position = startPosition;
        MaxHealth = maxHealth;
        Health = maxHealth;

    }

    public void TakeDamage(int amount)
    {
        if (amount > 0)
        {
            Health = Math.Max(0, Health - amount);
        }
    }

    public abstract void Update(GameTime gameTime);
    //public abstract void Draw(SpriteBatch spriteBatch);
}