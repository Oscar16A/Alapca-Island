using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = .05f;
    [SerializeField] private float jumpForce = 400f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private LayerMask groundLayer;
    public InputMaster controls;
    [SerializeField] public Rigidbody2D rb;

    Animator animator;
    private bool isTouchingTile;
    public bool isFacingRight = true;
    
    private Vector3 m_Velocity = Vector3.zero;
    private void Awake() 
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() 
    {
        // controls = new InputMaster();
        controls.Player.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        controls.Player.Jump.performed += ctx => Jump();
    }

    void Update() 
    {
        isTouchingTile = Physics2D.OverlapArea(new Vector2 (transform.position.x - 0.5f, transform.position.y),
            new Vector2 (transform.position.x + 0.5f, transform.position.y - 0.51f), groundLayer);
                    
        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
    }
    public void Move(Vector2 direction) 
    {
        Vector3 targetVelocity = new Vector2(movementSpeed * 10f, rb.velocity.y);

        rb.velocity = new Vector2(direction.x * movementSpeed, rb.velocity.y);

        if (direction.x > 0 && !isFacingRight) 
        {
            Filp();
        }
        else if (direction.x < 0 && isFacingRight) 
        {
            Filp();
        }
        // rb.AddForce(new Vector2(direction.x, 0));
    }

    public void Jump() 
    {
        if (isTouchingTile && IsGrounded()) 
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void Filp() 
    {
        isFacingRight = !isFacingRight;

        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    bool IsGrounded() 
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null) 
        {
            return true;
        }
        return false;
    }

    void OnEnable() 
    {
        controls.Enable();
    }

    void OnDisable() 
    {
        controls.Disable();
    }
}
