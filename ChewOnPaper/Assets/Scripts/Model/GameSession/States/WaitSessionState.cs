public class WaitSessionState : GameSessionState
{
    private readonly Toolbox tolbox;

    public WaitSessionState(Toolbox tolbox)
    {
        this.tolbox = tolbox;
    }

    public override void Initialize()
    {
        tolbox.gameObject.SetActive(false);
    }
}
