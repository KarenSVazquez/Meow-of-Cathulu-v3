// Script CatnipCounter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatnipCounter : MonoBehaviour
{
    public int catnipCount = 0;

    void Update()
    {
        UpdateCatnipCounterUI();
    }

    public bool HasEnoughCatnips(int requiredCatnips)
    {
        return catnipCount >= requiredCatnips;
    }

    public void SubtractCatnips(int amount)
    {
        catnipCount -= amount;
        UpdateCatnipCounterUI();
    }

    void UpdateCatnipCounterUI()
    {
        Text catnipCounterCanvas = GameObject.FindWithTag("CatnipCounterCanvas")?.GetComponent<Text>();
        if (catnipCounterCanvas != null)
        {
            catnipCounterCanvas.text = catnipCount.ToString();
        }
    }
    public void AddOneCatnip()
    {
        catnipCount++;
    }
}
