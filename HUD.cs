namespace Descent;

public class HUD
{
	private readonly Texture2D Texture;
	private readonly Rectangle SourceRectangle = new(0, 384, 64, 64);

	public HUD(Texture2D texture)
	{
		Texture = texture;
	}

	public void Draw(SpriteBatch spriteBatch, Entity.Player player)
	{
		int health = player.Health;
        int amountOfHearts;
        bool halfHeart = false;
        if (health % 2 == 0) amountOfHearts = health/2;
        else
        {
            amountOfHearts = health/2;
            halfHeart = true;
        }

		spriteBatch.Begin();

		for (int index = 0; index < amountOfHearts; index++)
		{
			spriteBatch.Draw(
                Texture,
                new Vector2(128 + 64 * index, 92),
                SourceRectangle,
                Color.White);

            if ((index == amountOfHearts-1) && halfHeart)
            {
                spriteBatch.Draw(
                Texture,
                new Vector2(128 + 64 * (index+1), 92),
                new Rectangle(64, 384, 64, 64),
                Color.White);
            }
		}


		spriteBatch.End();
	}

	public void Dispose()
	{
		Texture.Dispose();
	}
}