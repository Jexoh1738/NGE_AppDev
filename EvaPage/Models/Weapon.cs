namespace EvaPage.Models;

public class Weapon
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public WeaponType Type { get; set; }
    public int Damage { get; set; }
    public int Range { get; set; }

    public int Fire(Angel target) =>
        throw new NotImplementedException();

    public bool IsInRange(Vector2Int from, Vector2Int to) =>
        from.DistanceTo(to) <= Range;
}