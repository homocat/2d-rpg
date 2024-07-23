using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move info")]
    [SerializeField] public float moveSpeed = 12f;
    [SerializeField] public float jumpForce = 12f;

    [Header("Dash info")] 
    [SerializeField] public float dashCooldown;

    public float dashUsageTimer;
    public float dashSpeed;
    public float dashDuration;
    public float dashDir { get; private set; }

    [Header("Collision info")] 
    [SerializeField] public Transform groundCheck; 
    [SerializeField] public float groundCheckDistance;
    [SerializeField] public Transform wallCheck;
    [SerializeField] public float wallCheckDistance;
    [SerializeField] public LayerMask whatIsGround;

    public int facingDir { get; private set; } = 1;
    private bool facingRight = true;
    public float _x;
        
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
    public PlayerDashState dashState { get; private set; }
    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdelState(stateMachine, this, "Idle");
        moveState = new PlayerMoveState(stateMachine, this, "Move");
        jumpState = new PlayerJumpState(stateMachine, this, "Jump");
        airState = new PlayerAirState(stateMachine, this, "Jump");
        dashState = new PlayerDashState(stateMachine, this, "Dash");
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        stateMachine.Initialize(idleState);
    }

    private void Update()
    { 
        _x = rb.velocity.x;
        stateMachine.currentState.Update();
        
        FlipController(); 

        CheckDashInput();
    }

    private void CheckDashInput()
    {
        dashUsageTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.L) && dashUsageTimer < 0)
        {
            dashUsageTimer = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");
            dashDir = Math.Sign(dashDir);
            
            if (dashDir == 0)
                dashDir = facingDir;

            stateMachine.ChangeState(dashState);
        }
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }

    public bool IsGroundDetected() =>
        Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }

    public void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController()
    {
        if (facingRight && _x < 0)
        {
           Flip(); 
        } else if (!facingRight && _x > 0)
        {
           Flip(); 
        }
    }
}