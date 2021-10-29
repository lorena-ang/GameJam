using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroImgSwitch : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;
    public GameObject image7;
    int count=1;
    
    // Start is called before the first frame update
    void Start()
    {
        
        image1.SetActive(true);
        image2.SetActive(false);
        image3.SetActive(false);
        image4.SetActive(false);
        image5.SetActive(false);
        image6.SetActive(false);
        image7.SetActive(false);
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
            image4.SetActive(false);
            image5.SetActive(false);
            image6.SetActive(false);
            image7.SetActive(false);
        }
        else if(count == 3){
            image1.SetActive(false);
            image2.SetActive(false);
            image3.SetActive(true);
            image4.SetActive(false);
            image5.SetActive(false);
            image6.SetActive(false);
            image7.SetActive(false);
        }
        else if(count == 4){
            image1.SetActive(false);
            image2.SetActive(false);
            image3.SetActive(false);
            image4.SetActive(true);
            image5.SetActive(false);
            image6.SetActive(false);
            image7.SetActive(false);
        }
        else if(count == 5){
            image1.SetActive(false);
            image2.SetActive(false);
            image3.SetActive(false);
            image4.SetActive(false);
            image5.SetActive(true);
            image6.SetActive(false);
            image7.SetActive(false);
        }
        else if(count == 6){
            image1.SetActive(false);
            image2.SetActive(false);
            image3.SetActive(false);
            image4.SetActive(false);
            image5.SetActive(false);
            image6.SetActive(true);
            image7.SetActive(false);
        }
        else if(count == 7){
            image1.SetActive(false);
            image2.SetActive(false);
            image3.SetActive(false);
            image4.SetActive(false);
            image5.SetActive(false);
            image6.SetActive(false);
            image7.SetActive(true);
        }
        else{
            SceneManager.LoadScene("SampleScene");
        }
    }

}
