using System;

/// <summary>
/// Session state data.
/// </summary>
public class StateParameters
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StateParameters"/> class.
    /// </summary>
    /// <param name="stateType">Type of the state.</param>
    public StateParameters(Type stateType)
    {
        StateType = stateType;
    }

    /// <summary>
    /// Gets the type of the state.
    /// </summary>
    public Type StateType
    {
        get;
        private set;
    }
}
