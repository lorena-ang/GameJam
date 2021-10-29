using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    bool isHiding;
    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        isHiding = false;
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        if(canMove){
            move = direction * speed;
        }

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

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 10.0f, LayerMask.GetMask("Door"));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up)* 10f, Color.red);        

        if(Input.GetKeyDown(KeyCode.UpArrow) && hit.collider != null)
        {    
            Hide();   
        } 
        if(Input.GetKeyDown(KeyCode.DownArrow) && isHiding){
            Unhide();            
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
        
        if( collision.gameObject.tag == "Ground" )
        {
            animator.SetBool("jump", false);
        }
        if(collision.gameObject.tag == "Dog")
        {
           SceneManager.LoadScene("Winning") ;
        }

    }

    private void Hide()
    {
        // Vector3 position = rb.position;
        // position.y = position.y + 10.0f * Time.fixedDeltaTime * speed;       
        // rb.MovePosition(position);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        isHiding = true;      
        canMove = false;
    }

    private void Unhide()
    {
        // Vector3 position = rb.position;
        // position.y = position.y - 10.0f * Time.fixedDeltaTime * speed;
        // rb.MovePosition(position);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        isHiding = false;
        canMove = true;
        
    }
}
