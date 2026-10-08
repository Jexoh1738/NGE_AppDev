namespace EvaPage.Models;

/// <summary>
/// One play session: a pilot, in a unit, against one or more angels.
/// </summary>
public class Mission
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid PilotId { get; set; }
    public Guid EvaUnitId { get; set; }
    public List<Guid> AngelIds { get; private set; } = new();

    public DateTime StartedAt { get; init; } = DateTime.Now;
    public DateTime? EndedAt { get; private set; }
    public MissionResult Result { get; private set; } = MissionResult.InProgress;

    public void AddAngel(Guid angelId) =>
        AngelIds.Add(angelId);

    public void Complete(MissionResult result) =>
        throw new NotImplementedException();

    public TimeSpan? Duration() =>
        EndedAt.HasValue ? EndedAt.Value - StartedAt : null;
}