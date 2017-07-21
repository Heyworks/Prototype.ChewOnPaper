using System;
using UnityEngine;

public class GameStateController
{
    private readonly Game game;
    private readonly GameState.GameStateFactory stateFactory;

    private GameState currentState;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameStateController"/> class.
    /// </summary>
    /// <param name="stateFactory">The state factory.</param>
    public GameStateController(GameState.GameStateFactory stateFactory, Game game)
    {
        this.stateFactory = stateFactory;
        this.game = game;

        ChangeState(new StateParameters(typeof(LobbyState)));
    }

    /// <summary>
    /// Gets the state of the current.
    /// </summary>
    /// <typeparam name="T">Type of state.</typeparam>
    public T GetCurrentState<T>() where T : GameState
    {
        var state = currentState as T;
        if (state != null)
        {
            return state;
        }

        throw new InvalidOperationException(
            String.Format("Current game state is not valid. Current state type {0}. Required state type {1}",
                currentState.GetType(), typeof(T)));
    }

    /// <summary>
    /// Updates the game data.
    /// </summary>
    /// <param name="gameDto">The game dto.</param>
    public void InitializeGame(GameDTO gameDto)
    {
        game.UpdateGameData(gameDto.PreviousSessionWinner, gameDto.Players);
    }

    /// <summary>
    /// Starts the new session.
    /// </summary>
    /// <param name="session">The session.</param>
    // TODO: a.dezhurko move to GameStateController
    public void StartNewSession(Session session)
    {
        game.CurrentSession = session;

        ChangeState(new StateParameters(typeof(StartState)));
    }

    /// <summary>
    /// Starts the chewing.
    /// </summary>
    /// <param name="chewerId">The chewer identifier.</param>
    public void StartChewing(int chewerId)
    {
        game.CurrentSession.CurrentChewerId = chewerId;
        if (game.CurrentSession.CurrentPlayerRole == PlayerRole.Guesser)
        {
            ChangeState(new StateParameters(typeof(GuessState)));
        }
        else if (chewerId == game.CurrentPlayerId)
        {
            ChangeState(new StateParameters(typeof(ChewState)));
        }
        else
        {
            ChangeState(new StateParameters(typeof(WaitState)));
        }
    }

    /// <summary>
    /// Starts the chewing.
    /// </summary>
    /// <param name="chewerId">The chewer identifier.</param>
    public void FinishChewing(int chewerId)
    {
        if (game.CurrentSession.CurrentPlayerRole == PlayerRole.Chewer && chewerId == game.CurrentPlayerId)
        {
            GetCurrentState<ChewState>().Chew();
        }
    }

    /// <summary>
    /// Finishes the session.
    /// </summary>
    /// <param name="gameDto">The game dto.</param>
    // TODO: a.dezhurko move to GameStateController
    public void FinishSession(GameDTO gameDto)
    {
        game.UpdateGameData(gameDto.PreviousSessionWinner, gameDto.Players);

        ChangeState(new StateParameters(typeof(FinishState)));
    }

    // TODO: a.dezhurko move to GameStateController
    private void ChangeState(StateParameters parameters)
    {
        currentState = stateFactory.Create(parameters);
        currentState.Initialize();

        Debug.Log("Changing state to " + currentState.GetType());
    }
}
