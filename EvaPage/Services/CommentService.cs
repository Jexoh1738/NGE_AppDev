namespace EvaPage.Services;

public class Comment
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Author { get; init; } = string.Empty;
    public string Text { get; init; } = string.Empty;
    public DateTime PostedAt { get; init; } = DateTime.Now;

    // rater callsign -> stars (1-5). One rating per callsign; re-rating overwrites.
    public Dictionary<string, int> Ratings { get; } = new(StringComparer.OrdinalIgnoreCase);

    public double Average => Ratings.Count == 0 ? 0 : Ratings.Values.Average();
}

/// <summary>
/// Singleton, in-memory store. Data lives only as long as the app is open.
/// Swap the internals for an HttpClient/API later without touching the page.
/// </summary>
public class CommentService
{
    private readonly List<Comment> _comments = new();

    public CommentService()
    {
        Seed("Ayanami-00", "Sync ratio holding steady. No anomalies to report.", -95, ("Ikari-03", 5), ("Soryu-02", 4));
        Seed("Soryu-02", "Simulation results were fine. Some of us actually practiced.", -40, ("Ayanami-00", 3));
        Seed("Ikari-03", "Requesting a second look at the entry plug interface latency.", -12);
    }

    private void Seed(string author, string text, int minutesAgo, params (string rater, int stars)[] ratings)
    {
        var c = new Comment { Author = author, Text = text, PostedAt = DateTime.Now.AddMinutes(minutesAgo) };
        foreach (var (rater, stars) in ratings) c.Ratings[rater] = stars;
        _comments.Add(c);
    }

    public IReadOnlyList<Comment> GetAll() =>
        _comments.OrderByDescending(c => c.PostedAt).ToList();

    public void Add(string author, string text) =>
        _comments.Add(new Comment { Author = author, Text = text });

    /// <returns>false if the rater tried to rate their own comment or the comment doesn't exist.</returns>
    public bool Rate(Guid commentId, string rater, int stars)
    {
        var comment = _comments.FirstOrDefault(c => c.Id == commentId);
        if (comment is null) return false;
        if (string.Equals(comment.Author, rater, StringComparison.OrdinalIgnoreCase)) return false;

        comment.Ratings[rater] = Math.Clamp(stars, 1, 5);
        return true;
    }
}
