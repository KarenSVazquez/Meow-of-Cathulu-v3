// Script NPCCatnipsNeeded
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCatnipsNeeded : MonoBehaviour
{
    public int requiredCatnip = 0;
    public bool _satisfied = false;
    public SpriteRenderer catnipImage;
    public Sprite happyFaceSprite;
    public Sprite sadFaceSprite;
    public float destroyDelay = 1.0f;
    public SO_CatCounting catCounting;
    public Sprite[] dialogueImages;
    public bool canInteract = false;


    // Variable para realizar el seguimiento de si ya se restó una vez
    private bool catnipSubtracted = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        catnipImage.sprite = sadFaceSprite;
        canInteract = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        catnipImage.sprite = null;
        canInteract = false;

    }

    void DestroyNPC()
    {
        catCounting.CatNumber += 1; // cada vez que se destruye, suma 1 

        int length = Mathf.Min(dialogueImages.Length, catCounting.dialogueImages.Length);

        for (int i = 0; i < length; i++)
        {
            catCounting.dialogueImages[i] = dialogueImages[i];
        }

        catCounting.IsCathuluVisible = true;
        catCounting.NPCPosition = transform.position; // guarda la posición del NPC
        Destroy(gameObject);
    }

    private void Update()
    {
        CatnipCounter catnipCounterScript = GameObject.FindWithTag("CatnipCounter").GetComponent<CatnipCounter>();
        if (canInteract && Input.GetButtonDown("Activate") && !catnipSubtracted)
        {
            if (catnipCounterScript != null && catnipCounterScript.HasEnoughCatnips(requiredCatnip) && _satisfied == false)
            {
                catnipSubtracted = true;
                catnipCounterScript.SubtractCatnips(requiredCatnip);
                requiredCatnip = 0;
                _satisfied = true;
                Invoke("DestroyNPC", destroyDelay);
               
            }
        }

    }
}
