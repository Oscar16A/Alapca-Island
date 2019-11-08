using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notshitcontroller : MonoBehaviour
{
    public BoxCollider2D box;
    public Rigidbody2D rb;
    public float speed = 10f;
    public float jumpHeight = 10f;
    [SerializeField] private Vector2 velocity;
    [SerializeField] private float xInput;
    private bool jumped;
    private Collider2D[] hits;

    

    void Update()
    {
        jumped = Input.GetButtonDown("Jump");
        xInput = Input.GetAxis("Horizontal");
        // hits = Physics2D.OverlapBoxAll(transform.position, box.size, 0);
        // foreach(Collider2D hit in hits)
        // {
        //     if(hit == box)
        //     {
        //         continue;
        //     }
        //     ColliderDistance2D colliderDistance = hit.Distance(box);

        //     if(colliderDistance.isOverlapped)
        //     {
        //         transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
        //     }
        // }
    }

    void FixedUpdate()
    {
        if(jumped)
        {
            velocity.y = Mathf.Sqrt(2 * Mathf.Abs(Physics2D.gravity.y) * jumpHeight);
        }
        velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;

        velocity.x = xInput * speed;
        rb.velocity = (velocity * Time.fixedDeltaTime);

        
    }
}
