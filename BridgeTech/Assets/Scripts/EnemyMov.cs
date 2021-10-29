using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    Rigidbody2D rbOpossum;

    // Start is called before the first frame update
    void Start()
    {
        rbOpossum = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (facingRight())
        {
            // move right
            rbOpossum.velocity = new Vector2(-speed, 0f);
        }
        else
        {
            // move left
            rbOpossum.velocity = new Vector2(speed, 0f);
        }

    }

    private bool facingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Turn
        if (collision.tag == "Enemy")
        {
            transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
        }
    }

    public float getX()
    {
        return transform.localScale.x;
    }
}

/*
public class EnemyMov : MonoBehaviour
{
    Rigidbody2D rb;
    float lastStep = 0f;
    public float speed = 0.1f;
    public bool side = false;  //true = walks to left, false = walks to right
    public float limit = 3;
    GameObject mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        
        SelectSide();
        //Walk();

        //Walk indefinitely
        if (Time.time - lastStep > 0.05f) {
                lastStep = Time.time;                
                GetComponent<Rigidbody2D> ().transform.Translate (speed, 0, 0);                       
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 10.0f, LayerMask.GetMask("Player"));
        if(hit.collider != null && side == true ){
            speed = -0.3f;
            //Debug.Log("Z collide G");
        }
        else{
            speed = -0.1f;
            //Debug.Log("Z NOT collide G");
        }

        // if(rb.position.x <= mainCamera.GetComponent<Transform>().position.x - 10){
        //     Destroy(gameObject);
        // }
    }

    private void SelectSide(){

        if(rb.position.x < -limit ){
            side = false;
            transform.rotation = Quaternion.Euler(0, -180, 0);
            //rb.rotation = 0f;            
        }
        else if(rb.position.x > limit)
        {
            side = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //rb.rotation = -1f;
        }
        
    }

    private void Walk(){
        if (Time.time - lastStep > 0.05f) {
                lastStep = Time.time;
                if(side)
                {
                    GetComponent<Rigidbody2D> ().transform.Translate (speed, 0, 0);
                }
                else
                {
                    GetComponent<Rigidbody2D> ().transform.Translate (speed, 0, 0);
                }

        
        }
    }
}
*/
