using Zenject;

/// <summary>
/// Photon implementation of session initializer which works on master client.
/// </summary>
public class PhotonMasterClientSessionInitializer : Photon.MonoBehaviour
{
    [Inject]
    private SessionInitializer sessionInitializer;

    private void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        sessionInitializer.ProcessPlayerJoin(newPlayer.UserId);
    }
}
