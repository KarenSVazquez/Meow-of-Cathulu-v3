using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CatnipCounter : MonoBehaviour
{
    public GameObject thePlayer;
    public int catnipCount = 0;

    void Start()
    {
        thePlayer = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddOneCatnip()
    {
        catnipCount++;
    }
}