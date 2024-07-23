using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
     protected PlayerStateMachine stateMachine;

    protected Player player;

    protected Rigidbody2D rb;
    protected float xInput;

    private string _animBoolName;

    protected float stateTimer;
    
    protected PlayerState(PlayerStateMachine stateMachine, Player player, string animBoolName)
    {
        this.stateMachine = stateMachine;
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
        stateTimer -= Time.deltaTime;
        
        player.anim.SetFloat("yVelocity", rb.velocity.y);
    }

    public virtual void Exit()
    {
        player.anim.SetBool(_animBoolName, false);
    }

}
