using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLife : MonoBehaviour
{
    private bool dead = false, enabledCollider = true;
    private Rigidbody2D rb;
    public Text lifeText;
    private string lifetxt = "Vida: ";
    private float life = 100;
    //Animator animator;
    void Start()
    {
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        setLife();
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        string collisionObj = collider.gameObject.tag;
        if (collisionObj == "Enemy" & enabledCollider /*& collider.gameObject.GetComponent<Animator>().GetBool("dead") == false*/)
        {
            WhenCollision();
        }
        else if (collisionObj == "Health" & enabledCollider /*& collider.gameObject.GetComponent<Animator>().GetBool("dead") == false*/)
        {
            life += life == 100 ? 0:25;
            setLife();
            Destroy(collider.gameObject);
        }
    }
    public void WhenCollision()
    {
        if (life > 0)
        {
            life -= 25;
            StartCoroutine(WaitCoroutine());
            //animator.SetBool("damage", true);
            //Instantiate(DeathSound);
        }
        if (life <= 0)
        {
            dead = true; enabledCollider = false;
            //animator.SetBool("dead", dead);
            //Instantiate(GameOverSound);
            //GameObject.Find("Canvas").GetComponent<Scenes>().defeat();
        }
        setLife();
    }
    public void setLife()
    {
        lifeText.text = lifetxt + life.ToString();
    }
    IEnumerator WaitCoroutine()
    {
        rb.GetComponent<playerMovement>().enabled = false;
        Vector2 movement = new Vector2(-3.15f * rb.GetComponent<playerMovement>().facingRight, 5f);
        rb.velocity = movement;
        yield return new WaitForSeconds(0.75f);
        rb.GetComponent<playerMovement>().enabled = true;
    }
}
