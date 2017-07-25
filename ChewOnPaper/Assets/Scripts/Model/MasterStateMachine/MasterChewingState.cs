﻿using System.Collections;
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
    private readonly Paper paper;    
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
    /// <param name="chat">The chat.</param>
    /// <param name="paper">The paper.</param>
    public MasterChewingState(int chewerIndex, MasterState initState, MasterStateMachine masterStateMachine, NetworkSessionSynchronizer networkSessionSynchronizer, Game game, GuessChat chat, Paper paper)
        : base(masterStateMachine, networkSessionSynchronizer, game)
    {
        this.chewerIndex = chewerIndex;
        this.initState = initState;
        this.chat = chat;
        this.paper = paper;
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
        paper.Chewed += Paper_Chewed;
        coroutine = ContextBehaviour.StartCoroutine(ChewingCoroutine());
    }

    /// <summary>
    /// Deactivates this State.
    /// </summary>
    public override void Deactivate()
    {
        base.Deactivate();
        paper.Chewed -= Paper_Chewed;
        chat.NewGuessArrived -= Chat_NewGuessArrived;
    }

    private void Chat_NewGuessArrived(Guess guess)
    {
        CheckAnswer(guess.PlayerId, guess.Word);
    }

    private void Paper_Chewed(ChewEventArgs args)
    {
        FinishChewing();
    }

    private void CheckAnswer(int senderId, string answer)
    {
        if (string.Equals(answer.Trim().ToUpper(), StateMachineContext.SessionData.GuessedWord.Trim().ToUpper()))
        {
            ContextBehaviour.StopCoroutine(coroutine);
            Game.ProcessSessionEnd(senderId, GetPrevChewerId());
            NetworkSessionSynchronizer.FinishSession(Game.ConverToDto());
            ContextBehaviour.StartCoroutine(SwitchToInitState());
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

    private IEnumerator SwitchToInitState()
    {
        yield return new WaitForSeconds(10);

        SwitchToState(initState);
    }

    private IEnumerator ChewingCoroutine()
    {
        yield return new WaitForSeconds(Game.GameRoomSettings.TurnTime);
        FinishChewing();
    }

    private void FinishChewing()
    {
        SwitchToState(NextState);
        NetworkSessionSynchronizer.FinishChewing(chewerIds[chewerIndex]);
    }
}
