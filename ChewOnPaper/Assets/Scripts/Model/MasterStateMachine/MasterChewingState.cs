using System.Collections;
using System.Linq;
using UnityEngine;

/// <summary>
/// Represents chewing state of game state machine.
/// </summary>
public class MasterChewingState : MasterState
{
    private readonly int chewerIndex;
    private readonly MasterState initState;
    private readonly GuessChat chat;    
    private Coroutine coroutine;
    private int[] chewerIds;

    /// <summary>
    /// Initializes a new instance of the <see cref="MasterChewingState" /> class.
    /// </summary>
    /// <param name="chewerIndex">Index of the chewer.</param>
    /// <param name="initState">State of the initialize.</param>
    /// <param name="masterStateMachine">The master state machine.</param>
    /// <param name="networkSessionSynchronizer">The network session synchronizer.</param>
    /// <param name="game">The game.</param>
    /// <param name="chat"></param>
    public MasterChewingState(int chewerIndex, MasterState initState, MasterStateMachine masterStateMachine, NetworkSessionSynchronizer networkSessionSynchronizer, Game game, GuessChat chat)
        : base(masterStateMachine, networkSessionSynchronizer, game)
    {
        this.chewerIndex = chewerIndex;
        this.initState = initState;
        this.chat = chat;
    }

    /// <summary>
    /// Acticates this state.
    /// </summary>
    public override void Acticate()
    {
        base.Acticate();
        chewerIds = StateMachineContext.SessionData.PlayerRoles.Where(item => item.Value == PlayerRole.Chewer).Select(item => item.Key).ToArray();
        NetworkSessionSynchronizer.StartChewing(chewerIds[chewerIndex]);
        chat.NewGuessArrived += Chat_NewGuessArrived;
        coroutine = ContextBehaviour.StartCoroutine(ChewingCoroutine());
    }

    /// <summary>
    /// Deactivates this State.
    /// </summary>
    public override void Deactivate()
    {
        base.Deactivate();
        chat.NewGuessArrived -= Chat_NewGuessArrived;
    }

    private void Chat_NewGuessArrived(Guess guess)
    {
        CheckAnswer(guess.PlayerId, guess.Word);
    }
    
    private void CheckAnswer(int senderId, string answer)
    {
        if (string.Equals(answer, StateMachineContext.SessionData.GuessedWord))
        {
            Game.ProcessSessionEnd(senderId, GetPrevChewerId());
            ContextBehaviour.StopCoroutine(coroutine);
            NetworkSessionSynchronizer.FinishSession(senderId, answer);
            SwitchToState(initState);
        }
    }

    private int GetPrevChewerId()
    {
        var prevIndex = chewerIndex - 1;
        if (prevIndex < 0)
        {
            prevIndex = chewerIds.Length - 1;
        }

        return chewerIds[prevIndex];
    }

    private IEnumerator ChewingCoroutine()
    {
        yield return new WaitForSeconds(Game.GameRoomSettings.TurnTime);

        FinishChewing();
    }

    private void FinishChewing()
    {
        NetworkSessionSynchronizer.FinishChewing(chewerIndex);
        SwitchToState(NextState);
    }
}
