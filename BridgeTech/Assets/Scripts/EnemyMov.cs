using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    Rigidbody2D rb;
    float lastStep = 0f;
    float speed;
    bool side;  //true = walks to left, false = walks to right
    GameObject mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = GameObject.Find("MainCamera");
        speed = -0.5f;
        side = true;
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

        if(rb.position.x <= mainCamera.GetComponent<Transform>().position.x - 10){
            Destroy(gameObject);
        }
    }

    private void SelectSide(){
        if(rb.position.x < -5 ){
            side = false;
            transform.rotation = Quaternion.Euler(0, -180, 0);
            //rb.rotation = 0f;            
        }
        else if(rb.position.x > 5)
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
