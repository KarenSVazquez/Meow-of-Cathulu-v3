using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_dialogue_01 : MonoBehaviour
{
    public SpriteRenderer dialogue;
    public Sprite[] dialogueImg;
    public bool firstTime;
    // Start is called before the first frame update
    void Start()
    {
        firstTime = false;


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
                dialogue.sprite = dialogueImg[0];
                firstTime = true;
            }
            else
            {
                dialogue.sprite = dialogueImg[1];
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
