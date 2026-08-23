using System.Threading.Tasks;

public interface IHeroDataRepository 
{
    Task<HeroSO> LoadAsync(string id);
}
