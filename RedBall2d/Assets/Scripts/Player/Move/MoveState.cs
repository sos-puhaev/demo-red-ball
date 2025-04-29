using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : PlayerState
{
    public MoveState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine) {}

    public override void HandleInput(float moveInput, bool jumpPressed)
    {
        player.Move(moveInput);

        if (jumpPressed && player.IsGrounded())
        {
            stateMachine.ChangeState(player.jumpState);
        }
        else if (moveInput == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void Enter()
    {
        base.Enter();
        player.GetComponent<EyesController>().Stretch(0.5f);
    }
}


