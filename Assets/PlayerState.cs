using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
     protected PlayerStateMachine _stateMachine;

    protected Player _player;

    private string _animBoolName;
    
    public PlayerState(PlayerStateMachine stateMachine, Player player, string animBoolName)
    {
        _stateMachine = stateMachine;
        _player = player;
        _animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
    }

    public virtual void Update()
    {
    }
    public virtual void Exit() {}
}
