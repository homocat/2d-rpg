using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
     protected PlayerStateMachine _stateMachine;

    protected Player player;

    protected Rigidbody2D rb;
    protected float xInput;

    private string _animBoolName;
    
    protected PlayerState(PlayerStateMachine stateMachine, Player player, string animBoolName)
    {
        _stateMachine = stateMachine;
        this.player = player;
        _animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(_animBoolName, true);

        rb = player.rb;
    }

    public virtual void Update()
    {
        xInput = Input.GetAxis("Horizontal"); 
    }

    public virtual void Exit()
    {
        player.anim.SetBool(_animBoolName, false);
    }

}
