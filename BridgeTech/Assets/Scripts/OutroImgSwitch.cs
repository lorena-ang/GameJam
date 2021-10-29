using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroImgSwitch : MonoBehaviour
{
    
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    int count=1;
    // Start is called before the first frame update
    void Start()
    {
        image1.SetActive(true);
        image2.SetActive(false);
        image3.SetActive(false);
        image4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttonClick(){
        count++;
        imageSwitcher();
    }
    void imageSwitcher()
    {
        
        if(count == 2){
            image1.SetActive(false);
            image2.SetActive(true);
            image3.SetActive(false);
        }
        else if(count == 3){
            image1.SetActive(false);
            image2.SetActive(false);
            image3.SetActive(true);
        }
        else if(count == 4){
            //load another scene
            image3.SetActive(false);
            image4.SetActive(true);
        }else{
            SceneManager.LoadScene("GameWon");
        }
    }
}
