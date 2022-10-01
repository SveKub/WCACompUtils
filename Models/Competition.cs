namespace WCACompUtils.Models;

public class CompetitionContainer
{
    public CompetitionData Data { get; set; } = null!;
}

public class CompetitionsContainer
{
    public CompetitionsData Data { get; set; } = null!;
}

public class CompetitionData
{
    public Competition Competition { get; set; } = null!;
}

public class CompetitionsData
{
    public List<Competition> Competitions { get; set; } = null!;
}

public class Competition
{
    public List<Competitor>? Competitors { get; set; }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.MinValue;
}

public class Competitor
{
    public string Name { get; set; } = null!;
    public List<Result> Results { get; set; } = null!;
}

public class Result
{
    public string? Id { get; set; }
    public List<Attempt> Attempts { get; set; } = null!;
}

public class Attempt
{
    public int Result { get; set; }
}
