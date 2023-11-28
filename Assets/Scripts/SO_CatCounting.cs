using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Objects", menuName = "CatCounter", order = 0)]
public class SO_CatCounting : ScriptableObject
{
    public int CatNumber;
    public int CatGoal;
    public Sprite[] dialogueImages;
    public bool IsCathuluVisible;
    public Vector3 NPCPosition;
    public int[] canvasObjectIndices;
    public GameObject[] canvasObjects;

    public void InitializeCanvasObjectIndices()
    {
        // cantidad de objetos del canvas
        int numberOfCanvasObjects = canvasObjects.Length;

        // Asigna el número de obj del canvas
        canvasObjectIndices = new int[numberOfCanvasObjects];

        // posicion i comenzando desde el final del array
        for (int i = 0; i < numberOfCanvasObjects; i++)
        {
            canvasObjectIndices[i] = i;
        }
    }


    // encuentra automáticamente objetos del canvas al despertar
    public void FindCanvasObjects()
    {
        canvasObjects = GameObject.FindGameObjectsWithTag("npcSouls");
    }

    public int GetNPCIndex(GameObject npcObject)
    {
        return Array.IndexOf(canvasObjects, npcObject);
    }

    /*
     public void CheckVictoryCondition()
     {
         if (CatNumber >= CatGoal)
         {
             Debug.Log("entra if catgoal??");
             // Se cumplió la condición de victoria, carga la escena de victoria
             FindObjectOfType<LoadScene>().LoadVictoryScene();
         }
     }
     */
}
