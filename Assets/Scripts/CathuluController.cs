using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CathuluController : MonoBehaviour
{
    public SO_CatCounting catCounting;
    public GameObject CathuluPrefab; 
    // cada que se cumpla la condicion de num de pcn - aparece cathulu
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // hay x cada cantidad de npc aparece cathulue etc
        if (catCounting.IsCathuluVisible == true)
        {
            // aparece cathulu + muestra img luego termina en false
            // agregar Invoke(Destroyed) 

            Instantiate(CathuluPrefab, catCounting.NPCPosition, Quaternion.identity);
            catCounting.IsCathuluVisible = false;
        }

    }
}
