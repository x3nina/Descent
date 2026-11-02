using System.Net;
using System.Runtime.CompilerServices;

namespace Descent.Entity;

public class Player : Entity
{
    

    public Player(Vector2 startPosition, Texture2D texture)
        : base(startPosition, maxHealth: 7, sprite: new Sprite(texture, new Rectangle(0, 128, 128, 128)))
    {
        Sprite.CenterOrigin();
        AddFrames();
    }


    private readonly float diagonal = (float) Math.Sin(45f*(Math.PI/180.0f));
    private KeyboardState previousKBState;
    private Vector2 lastDirection;
    private Vector2 lastPosition;
    private TimeSpan dodgeRollStart;
    private bool dodging = false;

    private void AddFrames()
    {
        //private Dictionary<string, Rectangle> addFrames = new Dictionary<string, Rectangle>();
        Sprite.AddFrame("idle", new Rectangle(0, 128, 128, 128));
        Sprite.AddFrame("moving", new Rectangle(128, 128, 128, 128));
        Sprite.AddFrame("dodging", new Rectangle(256, 128, 128, 128));
    }

    public override void Update(GameTime gameTime)
    {
        Speed = 10;
        
        KeyboardState keyboardState = Keyboard.GetState();
        
        // dodge roll
        if (dodging)
        {
            Sprite.Position += lastDirection * 2.0f;
            if ((gameTime.TotalGameTime - dodgeRollStart) >= TimeSpan.FromSeconds(0.3))
            {
                dodging = false;
            }
        }
        else
        {
            if (keyboardState.IsKeyDown(Keys.Space) && previousKBState.IsKeyUp(Keys.Space) && !dodging)
            {
                Sprite.ChangeFrame("dodging");
                dodgeRollStart = gameTime.TotalGameTime;
                Sprite.Position += lastDirection * 1.5f;
                dodging = true;
            }

            // movement WASD
            if(keyboardState.IsKeyDown(Keys.W) && keyboardState.IsKeyDown(Keys.D) && keyboardState.IsKeyUp(Keys.S) && keyboardState.IsKeyUp(Keys.A))
            {
                lastDirection = new Vector2(Speed * diagonal, -Speed * diagonal);
                Sprite.Position += lastDirection;
                Sprite.Effects = SpriteEffects.FlipHorizontally;
            }
            else if(keyboardState.IsKeyDown(Keys.W) && keyboardState.IsKeyDown(Keys.A) && keyboardState.IsKeyUp(Keys.S) && keyboardState.IsKeyUp(Keys.D))
            {
                lastDirection = new Vector2(-Speed * diagonal, -Speed * diagonal);
                Sprite.Position += lastDirection;
                Sprite.Effects = SpriteEffects.None;
            }
            else if(keyboardState.IsKeyDown(Keys.S) && keyboardState.IsKeyDown(Keys.D) && keyboardState.IsKeyUp(Keys.W) && keyboardState.IsKeyUp(Keys.A))
            {
                lastDirection = new Vector2(Speed * diagonal, Speed * diagonal);
                Sprite.Position += lastDirection;
                Sprite.Effects = SpriteEffects.FlipHorizontally;
            }
            else if(keyboardState.IsKeyDown(Keys.S) && keyboardState.IsKeyDown(Keys.A) && keyboardState.IsKeyUp(Keys.W) && keyboardState.IsKeyUp(Keys.D))
            {
                lastDirection = new Vector2(-Speed * diagonal, Speed * diagonal);
                Sprite.Position += lastDirection;
                Sprite.Effects = SpriteEffects.None;
            }
            else if(keyboardState.IsKeyDown(Keys.W) && keyboardState.IsKeyUp(Keys.S))
            {
                lastDirection = new Vector2(0, -Speed);
                Sprite.Position += lastDirection;
            }
            else if(keyboardState.IsKeyDown(Keys.S) && keyboardState.IsKeyUp(Keys.W))
            {
                lastDirection = new Vector2(0, Speed);
                Sprite.Position += lastDirection;
            }
            else if(keyboardState.IsKeyDown(Keys.D) && keyboardState.IsKeyUp(Keys.A))
            {
                lastDirection = new Vector2(Speed, 0);
                Sprite.Position += lastDirection;
                Sprite.Effects = SpriteEffects.FlipHorizontally;
            }
            else if(keyboardState.IsKeyDown(Keys.A) && keyboardState.IsKeyUp(Keys.D))
            {
                lastDirection = new Vector2(-Speed, 0);
                Sprite.Position += lastDirection;
                Sprite.Effects = SpriteEffects.None;
            }
        }
        
        if (Sprite.Position == lastPosition)
        {
            Sprite.ChangeFrame("idle");
        }
        else if (!dodging)
        {
            Sprite.ChangeFrame("moving");
        }
        previousKBState = keyboardState;
        lastPosition = Sprite.Position;
    }
}