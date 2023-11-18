using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CathuluController : MonoBehaviour
{
    public SO_CatCounting catCounting;
    public GameObject CathuluPrefab;
    public Sprite[] dialogueImages;
    private SpriteRenderer cathuluSpriteRenderer;
    public float imageTime = 1.0f;
    public int
     // cada que se cumpla la condicion de num de pcn - aparece cathulu
     // Start is called before the first frame update
     void Awake()
    {
        // for recorrer el 
        dialogueImages = new Sprite[catCounting.dialogueImages.Length];
        for (int i = 0; i < catCounting.dialogueImages.Length; i++)
        {
            dialogueImages[i] = catCounting.dialogueImages[i];

        }
    }

    // Update is called once per frame
    void Update()
    {
        // hay x cada cantidad de npc aparece cathulue etc
        if (catCounting.IsCathuluVisible == true)
        {
            // aparece cathulu + muestra img luego termina en false
            // agregar Invoke(Destroyed) 
           // ShowDialogueImage();
            Invoke("ShowDialogueImage", imageTime);

            Instantiate(CathuluPrefab, catCounting.NPCPosition, Quaternion.identity);
            catCounting.IsCathuluVisible = false;
        }

    }
    void ShowDialogueImage()
    {
        
            for (int i = 0; i < dialogueImages.Length; i++)
        {
            cathuluSpriteRenderer.sprite = dialogueImages[i];
           

        }

    }
}
