public abstract class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;

    public PlayerState(Player player, PlayerStateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void HandleInput(float moveInput, bool jumpPressed) {}
    public virtual void LogicUpdate() { }
    public virtual void Exit() { }
}
