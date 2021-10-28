using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public float speed = 1f;

    public float jumpForce = 10f;
    public Transform feet;
    public LayerMask groundLayers;

    Vector3 scale;
    public float facingRight = 1;

    float move;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        move = direction * speed;

        animator.SetFloat("speed", Mathf.Abs(move));

        if(Input.GetKeyDown("space") && isGrounded() )
        {
            animator.SetBool("jump", true);
            jump();
        }

        scale = transform.localScale;
        if (direction < 0)
        {
            facingRight = scale.x = -1;
            transform.localScale = scale;
        }
        else if(direction > 0)
        {
            facingRight = scale.x = 1;
            transform.localScale = scale;
        }

    }
    private void FixedUpdate() 
    {
        Vector2 movement = new Vector2(move*speed, rb.velocity.y);
        rb.velocity = movement;
    }

    void jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
        // gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    public bool isGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if(groundCheck != null )
        {
            animator.SetBool("jump", true);
            return true;
        }
        return false;

    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if( collision.gameObject.tag == "Ground" ){
            animator.SetBool("jump", false);
        }    
    }
}
