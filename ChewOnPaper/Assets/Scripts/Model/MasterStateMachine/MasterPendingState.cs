﻿using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents pending all players state of game state machine.
/// </summary>
public class MasterPendingState : MasterState
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MasterPendingState" /> class.
    /// </summary>
    /// <param name="masterStateMachine">The game state machine.</param>
    /// <param name="networkSessionSynchronizer">The network session synchronizer.</param>
    /// <param name="game">The game.</param>
    /// <param name="nextState">State of the next.</param>
    public MasterPendingState(MasterStateMachine masterStateMachine, NetworkSessionSynchronizer networkSessionSynchronizer, Game game, MasterState nextState)
        : base(masterStateMachine, networkSessionSynchronizer, game, nextState)
    {
    }

    /// <summary>
    /// Acticates this state.
    /// </summary>
    public override void Acticate()
    {
        base.Acticate();
        NetworkSessionSynchronizer.PlayerJoined += NetworkSessionSynchronizer_PlayerJoined;
        CheckJoinedPlayersCount();
    }

    /// <summary>
    /// Deactivates this State.
    /// </summary>
    public override void Deactivate()
    {
        base.Deactivate();
        NetworkSessionSynchronizer.PlayerJoined -= NetworkSessionSynchronizer_PlayerJoined;
    }

    private void NetworkSessionSynchronizer_PlayerJoined()
    {
        CheckJoinedPlayersCount();
    }

    private void CheckJoinedPlayersCount()
    {
        if (PhotonNetwork.room.PlayerCount == Game.GameRoomSettings.MaxPlayers)
        {
            var players = CreatePlayers();
            Game.UpdateGameData(null, players);
            NetworkSessionSynchronizer.InitializeGame(Game.ConverToDto());
            SwitchToState(NextState);
        }
    }

    private List<Player> CreatePlayers()
    {
        //TODO: Move Photon communication to another place.
        var photonPlayers = PhotonNetwork.playerList;
        var players = photonPlayers.Select(photonPlayer => new Player(photonPlayer.ID, photonPlayer.NickName)).ToList();
        return players;
    }
}
