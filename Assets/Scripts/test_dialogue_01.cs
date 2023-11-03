using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_dialogue_01 : MonoBehaviour
{
    public SpriteRenderer dialogue;
    public Sprite[] dialogueImg;
    public bool firstTime;
    private int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        firstTime = false;
        currentIndex = 0;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" )
        {
            if(firstTime == false)
            {
                currentIndex = 0;
                dialogue.sprite = dialogueImg[currentIndex];
                firstTime = true;
            }
            else
            {
                if (currentIndex < dialogueImg.Length - 1)
                    Debug.Log("entra for?");
                {
                    currentIndex++;
                }
                dialogue.sprite = dialogueImg[currentIndex]; // hasta aca cierra en  1 , hacer for
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogue.sprite = null;
        }
    }
}
