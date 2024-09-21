namespace Diet.WebMVC.Repositories;

public interface IRegimenRepository : IGenericRepository<History>
{
    Task<bool> RegimenBought(string userId,int regimenId);
}