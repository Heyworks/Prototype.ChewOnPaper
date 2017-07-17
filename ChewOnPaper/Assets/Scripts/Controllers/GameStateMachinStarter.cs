using UnityEngine;
using Zenject;

/// <summary>
/// Represents component which creates and starts game state machine.
/// </summary>
public class GameStateMachinStarter : MonoBehaviour
{
    [Inject]
    private GameStateMachine gameStateMachine;

    private void Start()
    {
        if (PhotonNetwork.isMasterClient)
        {
            gameStateMachine.Start();
        }
    }
}
