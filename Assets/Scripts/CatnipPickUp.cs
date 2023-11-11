using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CatnipPickUp : MonoBehaviour
{
    public GameObject catnipCounter;
    public bool hasBeenExecuted = false;

    void Start()
    {
        catnipCounter = GameObject.FindWithTag("CatnipCounter");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" & !hasBeenExecuted)
        {
            hasBeenExecuted = true;
            catnipCounter.GetComponent<CatnipCounter>().AddOneCatnip();
        }
    }

    /*void OnDisable()
    {
        GameObject thePlayer = GameObject.FindWithTag("Player");
        thePlayer.GetComponent<CatnipCounter>().AddOneCatnip();
    }*/
}

