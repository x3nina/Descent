namespace Descent;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private Renderer _renderer;
    private SpriteBatch _spriteBatch;
    private Texture2D _mockup;
    private Texture2D _bg;
    public Entity.Player Player { get; private set; }
    public Obstacle Rock;
    public Trap Trap;
    private HUD _hud;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;
        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _renderer = new Renderer(GraphicsDevice);
        

        _mockup = Content.Load<Texture2D>("assets/mockup");
        _bg = Content.Load<Texture2D>("assets/bg");
        Player = new Entity.Player(new Vector2(_graphics.PreferredBackBufferWidth/2, _graphics.PreferredBackBufferHeight/2), _mockup);
        Rock = new Obstacle(3, 4, _mockup, ObstacleDefinitions.Rock);
        Trap = new Trap(5, 6, _mockup, TrapDefinitions.SpikeTrap);
        _hud = new HUD(_mockup);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Player.Update(gameTime);
        Trap.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _renderer.Draw(_spriteBatch, Player.Sprite, Rock.Sprite, Trap.Sprite, _bg);
        _hud.Draw(_spriteBatch, Player);
        base.Draw(gameTime);
    }

    protected override void UnloadContent()
    {
        _hud.Dispose();
        base.UnloadContent();
    }
}
