namespace EvaPage.Models;

public class Angel
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;          // e.g. "Sachiel"
    public AngelPattern Pattern { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; private set; }
    public int AttackPower { get; set; }
    public Vector2Int Position { get; set; }

    public void TakeDamage(int amount) =>
        throw new NotImplementedException();

    public int Attack(EvaUnit target) =>
        throw new NotImplementedException();

    public bool IsDefeated() => CurrentHealth <= 0;

    public void MoveTo(Vector2Int target) =>
        throw new NotImplementedException();
}