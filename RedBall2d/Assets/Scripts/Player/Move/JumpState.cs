public class JumpState : PlayerState
{
    public JumpState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine) {}

    public override void Enter()
    {
        player.Jump();
    }

    public override void LogicUpdate()
    {
        if (player.IsGrounded() && player.Rigidbody.linearVelocity.y <= 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
