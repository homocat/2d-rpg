using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move info")]
    [SerializeField] public float moveSpeed = 12f;
    [SerializeField] public float jumpForce = 12f;
    
    #region componens

    public Animator anim;


    public Rigidbody2D rb;
    
    #endregion

    #region States 
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdelState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; } 
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdelState(stateMachine, this, "Idle");
        moveState = new PlayerMoveState(stateMachine, this, "Move");
        jumpState = new PlayerJumpState(stateMachine, this, "Jump");
        airState = new PlayerAirState(stateMachine, this, "Jump");
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        
        stateMachine.currentState.Update();
        Debug.Log(stateMachine.currentState);

    }


    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }
}