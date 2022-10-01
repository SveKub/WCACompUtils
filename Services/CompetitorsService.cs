using System.Net.Http.Json;
using WCACompUtils.Models;
namespace WCACompUtils.Services;

public class CompetitorsService: ICompetitiorsService
{
    private readonly HttpClient _httpClient;
    public CompetitorsService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<List<Competition>> GetCompetitions()
    {
        var result = await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress, new
        {
            operationName = "Competitions",
            variables = new
            {
                from = DateTime.Now.Date.ToString("yyyy-MM-dd")
            },
            query = @$"query Competitions($from: Date!) 
                        {{
                            competitions(from: $from) 
                            {{ 
                                id name startDate endDate 
                            }}
                        }}"
        });
        var competitionsContainer = await result.Content.ReadFromJsonAsync<CompetitionsContainer>();
        if (competitionsContainer != null && competitionsContainer.Data != null && competitionsContainer.Data.Competitions.Any())
            return competitionsContainer.Data.Competitions.ToList();
        else
            return await Task.FromResult(new List<Competition>());
    }

    public async Task<List<string>> GetCompetititors(int competitionId)
    {
        var result = await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress, new
        {
            operationName = "Competition",
            variables = new
            {
                competitionId = competitionId
            },
            query = $"query  Competition($competitionId:  ID!)  {{    competition(id:  $competitionId)    {{ id name startDate endDate competitors  {{  name   results {{  id attempts {{ result }} }}  }}  }}  }} "
        });
        var competitionContainer = await result.Content.ReadFromJsonAsync<CompetitionContainer>();
        if (competitionContainer != null && competitionContainer.Data != null && competitionContainer.Data.Competition != null && competitionContainer.Data.Competition.Competitors.Any())
            return competitionContainer.Data.Competition.Competitors.Select(c => c.Name).ToList();
        return await Task.FromResult(new List<string>());
    }
}
