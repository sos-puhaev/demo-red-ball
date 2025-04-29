using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D Rigidbody { get; private set; }

    public PlayerStateMachine stateMachine;

    public IdleState idleState;
    public MoveState moveState;
    public JumpState jumpState;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float drag = 2f;
    [SerializeField] float angularDrag = 3f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] LayerMask groundLayer;

    float moveDirection = 0f;
    bool jumpPressed = false;

    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        stateMachine = new PlayerStateMachine();

        idleState = new IdleState(this, stateMachine);
        moveState = new MoveState(this, stateMachine);
        jumpState = new JumpState(this, stateMachine);
    }

    void Start()
    {
        stateMachine.Initialize(idleState);
    }

    void Update()
    {
        float inputMove = 0f;
        bool inputJump = false;

    #if UNITY_EDITOR || UNITY_STANDALONE
        inputMove = Input.GetAxisRaw("Horizontal");
        inputJump = Input.GetButtonDown("Jump");
    #else
        inputMove = moveDirection;
        inputJump = jumpPressed;
    #endif

        stateMachine.CurrentState.HandleInput(inputMove, inputJump);
        stateMachine.CurrentState.LogicUpdate();

        jumpPressed = false;
    }

    void FixedUpdate()
    {

        if (Rigidbody.linearVelocity.x != 0)
        {
            Rigidbody.linearVelocity = new Vector2(Mathf.MoveTowards(Rigidbody.linearVelocity.x, 0, drag * Time.fixedDeltaTime), Rigidbody.linearVelocity.y);
        }

        if (Mathf.Abs(Rigidbody.angularVelocity) > 0)
        {
            Rigidbody.angularVelocity = Mathf.MoveTowards(Rigidbody.angularVelocity, 0, angularDrag * Time.fixedDeltaTime);
        }
    }

    public void Move(float direction)
    {
        Rigidbody.linearVelocity = new Vector2(direction * moveSpeed, Rigidbody.linearVelocity.y);
    }

    public void Rotate(float direction)
    {
        if (direction != 0)
        {
            Rigidbody.AddTorque(-direction * rotationSpeed);
        }
    }

    public void Jump()
    {
        Rigidbody.linearVelocity = new Vector2(Rigidbody.linearVelocity.x, jumpForce);
    }

    public bool IsGrounded()
    {
        Collider2D playerCollider = GetComponent<Collider2D>();
        return Physics2D.IsTouchingLayers(playerCollider, groundLayer);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        IContact contact = collision.collider.GetComponent<IContact>();
        contact?.ApplyContact(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        IContactTrigger contact = collision.GetComponent<IContactTrigger>();
        contact?.ApplyContact(gameObject);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == null) return;
        IContactExit contact = collision.gameObject.GetComponent<IContactExit>();
        contact?.ApplyExitContact(gameObject);
    }

    // Keyboard Mobile
    public void OnMoveLeftButtonDown(BaseEventData data)
    {
        moveDirection = -1f;
        stateMachine.CurrentState.HandleInput(moveDirection, false);
    }

    public void OnMoveRightButtonDown(BaseEventData data)
    {
        moveDirection = 1f;
        stateMachine.CurrentState.HandleInput(moveDirection, false);
    }

    public void OnMoveButtonUp(BaseEventData data)
    {
        moveDirection = 0f;
        stateMachine.CurrentState.HandleInput(moveDirection, false);
    }

    public void OnJumpButtonDown(BaseEventData data)
    {
        stateMachine.CurrentState.HandleInput(moveDirection, true);
    }
}
