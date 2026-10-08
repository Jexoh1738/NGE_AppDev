namespace EvaPage.Models;

public class Pilot
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Callsign { get; set; } = string.Empty;     // matches ISSUED ID on login
    private string PasswordHash { get; set; } = string.Empty;
    public double SyncRatio { get; private set; }             // 0-100
    public Guid? AssignedUnitId { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public bool VerifyPassword(string input) =>
        throw new NotImplementedException();

    public void AssignUnit(Guid unitId) =>
        AssignedUnitId = unitId;

    public void UnassignUnit() =>
        AssignedUnitId = null;

    public void UpdateSyncRatio(double value) =>
        throw new NotImplementedException();
}