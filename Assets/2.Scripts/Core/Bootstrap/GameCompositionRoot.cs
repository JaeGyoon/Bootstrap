using System.Threading.Tasks;
using UnityEngine;

public sealed class GameCompositionRoot
{
    private IAddressableService addressableService;

    public async Task InitializeAsync()
    {
        await CreateServiceAsync();
    }

    private async Task CreateServiceAsync()
    {
        addressableService = new AddressableService();

        await addressableService.InitializeAsync();

        Debug.Log("모든 서비스 생성 및 초기화 완료");
    }


}
