using WCACompUtils.Models;

namespace WCACompUtils.Services;
public interface ICompetitiorsService
{
    Task<List<Competition>> GetCompetitions();
    Task<List<string>> GetCompetititors(int competitionId);
}
