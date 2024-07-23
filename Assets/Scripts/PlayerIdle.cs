using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdelState : PlayerGroundState
{
    public PlayerIdelState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (xInput != 0)
        {
           stateMachine.ChangeState(player.moveState); 
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
