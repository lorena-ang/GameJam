using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private float life = 100;
    public GameObject v1, v2, v3, v4, v5, v6;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        setLife();
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        string collisionObj = collider.gameObject.tag;
        if (collisionObj == "Enemy")
        {
            WhenCollision();
        }
        else if (collisionObj == "Health")
        {
            life += life == 100 ? 0:20;
            setLife();
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playRecover();
            Destroy(collider.gameObject);
        }
    }
    public void WhenCollision()
    {
        if (life > 0)
        {
            life -= 20;
            StartCoroutine(WaitCoroutine());
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playDamage();
        }
        if (life <= 0)
        {
            StartCoroutine(LostCoroutine());
        }
        setLife();
    }
    IEnumerator WaitCoroutine()
    {
        rb.GetComponent<playerMovement>().enabled = false;
        Vector2 movement = new Vector2(-3.15f * rb.GetComponent<playerMovement>().facingRight, 5f);
        rb.velocity = movement;
        yield return new WaitForSeconds(0.75f);
        rb.GetComponent<playerMovement>().enabled = true;
    }
    IEnumerator LostCoroutine()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playLost();
        rb.GetComponent<playerMovement>().enabled = false;
        Vector2 movement = new Vector2(-3.15f * rb.GetComponent<playerMovement>().facingRight, 5f);
        rb.velocity = movement;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameLost");
    }
    public void setLife()
    {
        if (life == 100)
        {
            v1.SetActive(false);
            v2.SetActive(false);
            v3.SetActive(false);
            v4.SetActive(false);
            v5.SetActive(false);
            v6.SetActive(true);
        }
        else if (life == 80)
        {
            v1.SetActive(false);
            v2.SetActive(false);
            v3.SetActive(false);
            v4.SetActive(false);
            v5.SetActive(true);
            v6.SetActive(false);
        }
        else if (life == 60)
        {
            v1.SetActive(false);
            v2.SetActive(false);
            v3.SetActive(false);
            v4.SetActive(true);
            v5.SetActive(false);
            v6.SetActive(false);
        }
        else if (life == 40)
        {
            v1.SetActive(false);
            v2.SetActive(false);
            v3.SetActive(true);
            v4.SetActive(false);
            v5.SetActive(false);
            v6.SetActive(false);
        }
        else if (life == 20)
        {
            v1.SetActive(false);
            v2.SetActive(true);
            v3.SetActive(false);
            v4.SetActive(false);
            v5.SetActive(false);
            v6.SetActive(false);
        }
        else if (life == 0)
        {
            v1.SetActive(true);
            v2.SetActive(false);
            v3.SetActive(false);
            v4.SetActive(false);
            v5.SetActive(false);
            v6.SetActive(false);
        }
    }
}
