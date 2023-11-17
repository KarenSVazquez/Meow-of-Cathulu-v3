using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Text catnipCounterCanvas = GameObject.FindWithTag("CatnipCounterCanvas").GetComponent<Text>();
        catnipCounterCanvas.text = catnipCount.ToString();
    }

    public void AddOneCatnip()
    {
        catnipCount++;
    }

    internal void SubtractCatnips(int requiredCatnip)
    {
        throw new NotImplementedException();
    }

    internal bool HasEnoughCatnips(int requiredCatnip)
    {
        throw new NotImplementedException();
    }
}