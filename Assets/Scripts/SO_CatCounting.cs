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

        // Asigna el n�mero de obj del canvas
        canvasObjectIndices = new int[numberOfCanvasObjects];

        // �ndices en orden inverso
        for (int i = 0; i < numberOfCanvasObjects; i++)
        {
            canvasObjectIndices[i] = numberOfCanvasObjects - 1 - i;
        }
    }



    // encuentra autom�ticamente objetos del canvas al despertar
    public void FindCanvasObjects()
    {
        canvasObjects = GameObject.FindGameObjectsWithTag("npcSouls");
    }

    public int GetNPCIndex(GameObject npcObject)
    {
        return Array.IndexOf(canvasObjects, npcObject);
    }
}
