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
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform horizontalCheck;
    [SerializeField] private bool airControl = false;
    public InputMaster controls;
    [SerializeField] public Rigidbody2D rb;

    private bool isGrounded;
    public bool isFacingRight = true;
    
    private Vector3 m_Velocity = Vector3.zero;
    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() 
    {
        // controls = new InputMaster();
        controls.Player.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        controls.Player.Jump.performed += ctx => Jump();
    }

    void Update() {
        isGrounded = Physics2D.OverlapArea(new Vector2 (transform.position.x - 0.5f, transform.position.y),
            new Vector2 (transform.position.x + 0.5f, transform.position.y - 0.51f), groundLayer);
    }
    public void Move(Vector2 direction) 
    {
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
        if (isGrounded) 
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

    void OnEnable() 
    {
        controls.Enable();
    }

    void OnDisable() 
    {
        controls.Disable();
    }
}
