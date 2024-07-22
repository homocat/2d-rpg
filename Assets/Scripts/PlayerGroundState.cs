using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    protected PlayerGroundState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.K) && player.IsGroundDetected())
        {
           _stateMachine.ChangeState(player.jumpState); 
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
