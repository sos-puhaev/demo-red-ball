public class IdleState : PlayerState
{
    public IdleState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine) {}

    public override void HandleInput(float moveInput, bool jumpPressed)
    {
        if (jumpPressed && player.IsGrounded())
        {
            stateMachine.ChangeState(player.jumpState);
        }
        else if (moveInput != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }

    public override void Enter()
    {
        base.Exit();
        player.GetComponent<EyesController>().Reset();
    }
}
