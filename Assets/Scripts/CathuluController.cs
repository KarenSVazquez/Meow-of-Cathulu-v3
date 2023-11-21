// CathuluController
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
    // cada que se cumpla la condicion de num de pcn - aparece cathulu
    // Start is called before the first frame update
    void Awake()
    {
        // for recorrer el 
        cathuluSpriteRenderer = GetComponent<SpriteRenderer>();
        /*
                 dialogueImages = new Sprite[catCounting.dialogueImages.Length];
                for (int i = 0; i < catCounting.dialogueImages.Length; i++)
                {
                    dialogueImages[i] = catCounting.dialogueImages[i];

                }
         */
    }

    // Update is called once per frame
    void Update()
    {
        cathuluSpriteRenderer = GetComponent<SpriteRenderer>();
        //  dialogueImages = new Sprite[catCounting.dialogueImages.Length];
        // hay x cada cantidad de npc aparece cathulue etc
        if (catCounting.IsCathuluVisible == true)
        {
            // aparece cathulu + muestra img luego termina en false

            Instantiate(CathuluPrefab, catCounting.NPCPosition, Quaternion.identity);
            ShowDialogueImage();
            catCounting.IsCathuluVisible = false;
        }
        Debug.Log("Longitud de catCounting.dialogueImages: " + catCounting.dialogueImages.Length);
    }

    // los npc van a tener las img que se guardan desde el obj counteing cat y este guarda las img que va a estar con cahtulu
    void ShowDialogueImage()
    {
        // Asegúrate de que haya imágenes en el array
        if (dialogueImages != null && dialogueImages.Length > 0)
        {
            for (int i = 0; i < dialogueImages.Length; i++)
            {
                // Asegúrate de que el índice sea válido
                if (i < dialogueImages.Length)
                {
                    cathuluSpriteRenderer.sprite = dialogueImages[i];
                    Invoke("DestroyNPC", i * imageTime);
                }
            }
        }
        else
        {
            Debug.LogError("asd array???.");
        }
    }


}
