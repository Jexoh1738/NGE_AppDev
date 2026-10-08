namespace EvaPage.Models;

public class EvaUnit
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;        // e.g. "Unit-01"
    public int MaxHealth { get; set; } = 100;
    public int CurrentHealth { get; private set; } = 100;
    public int AtFieldStrength { get; set; }
    public UnitStatus Status { get; private set; } = UnitStatus.Docked;

    public Guid? PilotId { get; set; }                       // currently assigned pilot
    public List<Weapon> Equipment { get; private set; } = new();
    public Vector2Int Position { get; set; }

    public void TakeDamage(int amount) =>
        throw new NotImplementedException();

    public void Heal(int amount) =>
        throw new NotImplementedException();

    public void EquipWeapon(Weapon weapon) =>
        throw new NotImplementedException();

    public bool UnequipWeapon(Guid weaponId) =>
        throw new NotImplementedException();

    public void MoveTo(Vector2Int target) =>
        throw new NotImplementedException();

    public bool IsDestroyed() => CurrentHealth <= 0;
}