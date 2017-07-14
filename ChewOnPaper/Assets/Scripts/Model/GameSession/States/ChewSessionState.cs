public class ChewSessionState : GameSessionState
{
    private readonly Paper paper;
    private readonly Toolbox tolbox;

    public ChewSessionState(Paper paper, Toolbox tolbox)
    {
        this.paper = paper;
        this.tolbox = tolbox;
    }

    public override void Initialize()
    {
        tolbox.gameObject.SetActive(true);
    }

    public void Chew()
    {
        paper.Chew(tolbox.CurrentStencil);
        tolbox.NextStencil();
    }
}
