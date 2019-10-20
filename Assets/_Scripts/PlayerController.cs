using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.1f;
    [SerializeField] private float jumpForce = 400f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform horizontalCheck;
    [SerializeField] private bool airControl = false;
    public InputMaster controls;
    [SerializeField] public Rigidbody2D rb;

    bool onAir = false;
    private bool grounded;
    public bool facingRightg = true;
    
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


    public void Move(Vector2 direction) 
    {
        rb.velocity = new Vector2(direction.x, rb.velocity.y);
        // rb.AddForce(new Vector2(direction.x, 0));
    }

    public void Jump() 
    {
        if (!onAir) 
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            onAir = true;
        }
        // rb.velocity += Vector2.up * Physics2D.gravity.y * Time.deltaTime;
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
