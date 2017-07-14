using UnityEngine;

/// <summary>
/// Represents component which creates and starts game state machine.
/// </summary>
public class GameStateMachinStarter : MonoBehaviour
{
    private void Start()
    {
        if (PhotonNetwork.isMasterClient)
        {
            var stateMachine = new GameStateMachine();
            stateMachine.Start();
        }
    }
}
