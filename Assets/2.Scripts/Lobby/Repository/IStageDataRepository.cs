using System.Threading.Tasks;

public interface IStageDataRepository
{
    Task<StageSO> LoadAsync(string id);

    void ClearCache();
}
