namespace Descent;

public class Gameplay
{
    private List<Entity.Player> _players = new List<Entity.Player>();
    private PhysicsEngine _physicsEngine = new PhysicsEngine();
    private Level _level = new Level();
    private Renderer _renderer = new Renderer();

    public Gameplay()
    {
        // Ustvarjanje ustreznih igralcev (človeški in UI)
        _players.Add(new Entity.Player());
        //_players.Add(new Entity.Enemies.Enemy());
    }

    public void Update(GameTime gameTime)
    {
        // 1. Posodobitev vseh igralcev (vhodni podatki in UI)
        foreach (var player in _players)
        {
            player.Update(gameTime, _level);
        }

        // 2. Simulacija fizike na sceni
        _physicsEngine.Update(gameTime, _level);

        // 3. Posodobitev objektov na sceni (dodajanje/odstranjevanje)
        _level.Update(gameTime);

        // 4. Apply Game Rules: Preverjanje pogojev za zmago ali poraz
        CheckGameRules();
    }

    private void CheckGameRules()
    {
        // Logika za zmago/poraz
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Izris scene
        _renderer.Draw(spriteBatch, _level);
    }
}